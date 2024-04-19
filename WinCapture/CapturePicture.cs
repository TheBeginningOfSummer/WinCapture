using Microsoft.IO;
using OpenCvSharp;
using System.Diagnostics;
using System.Threading.Channels;

namespace WinCapture
{
    public class CapturePicture
    {
        #region 窗口图片捕捉参数
        //设备DeviceContent
        private IntPtr windowDc;
        //内存DeviceContent
        private IntPtr memoryDc;
        //位图位置
        static IntPtr bitsPtr;
        //图片句柄
        private IntPtr bitmap;
        //之前的图片句柄
        private IntPtr preBitmap;
        //图片大小
        private int width;
        private int height;
        //private Rectangle bitmapRectangle;
        #endregion

        public bool IsRun = false;
        public bool IsShow = false;
        static readonly RecyclableMemoryStreamManager streamManager = new();
        MemoryStream? cache;
        readonly BoundedChannelOptions boundedOptions = new(100) { FullMode = BoundedChannelFullMode.Wait };
        public Channel<Bitmap> bitmapChannel;
        public Channel<Stream> streamChannel;
        public Action<Bitmap>? UpdatePicture;
        Task? capturing;
        Task? show;

        public CapturePicture()
        {
            bitmapChannel = Channel.CreateBounded<Bitmap>(boundedOptions);
            streamChannel = Channel.CreateBounded<Stream>(boundedOptions);
        }

        #region 图片捕获方法
        /// <summary>
        /// 创建设备DC
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        public void CreateDC(IntPtr hwnd)
        {
            //设备上下文
            windowDc = Win32.GetWindowDC(hwnd);
            //内存设备上下文
            memoryDc = Win32.CreateCompatibleDC(windowDc);
        }
        /// <summary>
        /// 清除设备DC
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        public void ClearDC(IntPtr hwnd)
        {
            //if (bitmap.Equals(IntPtr.Zero))
            //{
            //    return;
            //}
            //删除用过的对象
            Win32.SelectObject(memoryDc, preBitmap);
            Win32.DeleteObject(bitmap);
            Win32.DeleteDC(memoryDc);
            Win32.ReleaseDC(hwnd, windowDc);
        }
        /// <summary>
        /// 在内存创建位图
        /// </summary>
        /// <param name="dc">设备上下文</param>
        /// <param name="bitmapInfo">位图结构体</param>
        /// <param name="width">位图宽</param>
        /// <param name="height">位图高</param>
        /// <returns>位图句柄</returns>
        public static IntPtr CreateCompatibleBitmap(IntPtr dc, Win32Types.BitmapInfo bitmapInfo, int width, int height)
        {
            bitmapInfo.bmiHeader.Init();
            bitmapInfo.bmiHeader.biWidth = width;
            bitmapInfo.bmiHeader.biHeight = height;
            bitmapInfo.bmiHeader.biPlanes = 1;
            bitmapInfo.bmiHeader.biBitCount = 24;
            bitmapInfo.bmiHeader.biSizeImage = (uint)(width * height);
            bitmapInfo.bmiHeader.biCompression = (uint)Win32Const.BitmapCompressionMode.BI_RGB;
            //创建设备无关的位图
            var bitmap = Win32.CreateDIBSection(dc, ref bitmapInfo, (uint)Win32Const.DibColorMode.DIB_RGB_COLORS,
                out bitsPtr, IntPtr.Zero, 0);
            return bitmap;
        }
        /// <summary>
        /// 设置内存中的位图
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="bitmapInfo">位图结构体</param>
        /// <returns>窗口信息获取是否成功</returns>
        public bool GetDCBitmap(IntPtr hwnd, Win32Types.BitmapInfo bitmapInfo, int mode = 0)
        {
            if (mode == 0)
            {
                if (!Win32.GetClientRect(hwnd, out Rectangle bitmapRectangle)) return false;
                width = bitmapRectangle.Width;
                height = bitmapRectangle.Height;
            }
            else if (mode == 1)
            {
                if (!Win32.GetWindowRect(hwnd, out Rectangle bitmapRectangle)) return false;
                width = bitmapRectangle.Width;
                height = bitmapRectangle.Height;
            }
            else
            {
                return false;
            }
            //创建一个位图
            bitmap = CreateCompatibleBitmap(memoryDc, bitmapInfo, width, height);
            //将设备图像指定到位图中
            preBitmap = Win32.SelectObject(memoryDc, bitmap);
            //将源中的位块指定到内存设备DC中
            return Win32.BitBlt(memoryDc, 0, 0, width, height, windowDc, 0, 0,
                (uint)Win32Const.RasterOperationMode.SRCCOPY);
        }
        #endregion

        public static void StartTask(Task? task, Action action)
        {
            if (task == null)
            {
                task = new Task(action);
            }
            else
            {
                task.Wait();
                task = new Task(action);
            }
            task.Start();
        }

        public async Task Capturing(IntPtr hwnd, int fps)
        {
            IsRun = true;
            CreateDC(hwnd);
            bitmapChannel = Channel.CreateBounded<Bitmap>(boundedOptions);
            Win32Types.BitmapInfo bitmapInfo = new() { bmiHeader = new Win32Types.BitmapInfoHeader() };
            while (IsRun)
            {
                if (GetDCBitmap(hwnd, bitmapInfo))
                {
                    if (fps <= 0 || fps > 1000)
                        Thread.Sleep(40);
                    else
                        Thread.Sleep(1000 / fps);
                    Bitmap image = Image.FromHbitmap(bitmap);
                    UpdatePicture?.Invoke(image);
                    await bitmapChannel.Writer.WriteAsync(image);
                    Win32.DeleteObject(bitmap);
                }
                else break;
            }
            bitmapChannel.Writer.Complete();
            ClearDC(hwnd);
            Cv2.DestroyAllWindows();
        }

        public async Task ShowCpatured(string windowName, int delay = 20)
        {
            IsShow = true;
            while (await bitmapChannel.Reader.WaitToReadAsync())
            {
                if (bitmapChannel.Reader.TryRead(out var image))
                {
                    Cv2.WaitKey(delay);
                    Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(image);
                    Cv2.ImShow(windowName, mat);
                    image.Dispose();
                    mat.Release();
                    Debug.WriteLine(bitmapChannel.Reader.Count);
                }
                if (!IsShow) break;
            }
            Cv2.DestroyAllWindows();
        }

        public void CaptureStart(IntPtr hwnd, int fps = 25)
        {
            IsRun = false;
            StartTask(capturing, async () => await Capturing(hwnd, fps));
        }

        public void ShowCpaturedStart(string windowName, int delay = 20)
        {
            IsShow = false;
            StartTask(show, async () => await ShowCpatured(windowName, delay));
        }

    }
}
