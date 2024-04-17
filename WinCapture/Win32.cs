using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace WinCapture;

public class Win32
{
    [DllImport("user32.dll")]
    public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);
    [DllImport("User32.dll", SetLastError = true)]
    public static extern IntPtr FindWindow(string? className, string windowName);
    [DllImport("user32.dll")]
    //[return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetWindowRect(IntPtr hWnd, out Rectangle rect);
    [DllImport("user32.dll")]
    public static extern bool GetClientRect(IntPtr hWnd, out Rectangle rect);
    [DllImport("user32.dll")]
    public static extern int GetCursorPos(out Point pos);
    [DllImport("user32.dll")]
    public static extern int WindowFromPoint(Point point);
    [DllImport("user32.dll")]
    public static extern int GetWindowText(int hwnd, StringBuilder sb, int maxCount);
    [DllImport("user32.dll")]
    public static extern int GetClassName(int hwnd, StringBuilder sb, int maxCount);
    [DllImport("user32.dll", EntryPoint = "SendMessageA")]
    public static extern int SendMessage(int hwnd, int msg, IntPtr wParam, IntPtr lParam);
    [DllImport("user32.dll", EntryPoint = "GetWindowDC")]
    public static extern IntPtr GetWindowDC(IntPtr hWnd);

    [DllImport("gdi32.dll")]
    public static extern IntPtr CreateCompatibleDC(IntPtr hDc);
    [DllImport("gdi32.dll")]
    public static extern IntPtr CreateCompatibleBitmap(IntPtr hDc, int nWidth, int nHeight);
    [DllImport("gdi32.dll")]
    public static extern bool DeleteDC(IntPtr hDc);
    [DllImport("user32.dll")]
    public static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);
    [DllImport("gdi32.dll")]
    public static extern IntPtr SelectObject(IntPtr hDc, IntPtr hObject);
    [DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);
    [DllImport("gdi32.dll")]
    public static extern IntPtr CreateDIBSection(IntPtr hdc, ref Win32Types.BitmapInfo bmi,
            uint usage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);
    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern bool BitBlt(
            IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight,
            IntPtr hObjectSource, int nXSrc, int nYSrc, uint dwRop);
}

public class Win32Const
{
    public enum DibColorMode : uint
    {
        DIB_RGB_COLORS = 0x00,
        DIB_PAL_COLORS = 0x01,
        DIB_PAL_INDICES = 0x02
    }

    public enum BitmapCompressionMode : uint
    {
        BI_RGB = 0,
        BI_RLE8 = 1,
        BI_RLE4 = 2,
        BI_BITFIELDS = 3,
        BI_JPEG = 4,
        BI_PNG = 5,
    }

    public enum RasterOperationMode : uint
    {
        SRCCOPY = 0x00CC0020,
        SRCPAINT = 0x00EE0086,
        SRCAND = 0x008800C6,
        SRCINVERT = 0x00660046,
        SRCERASE = 0x00440328,
        NOTSRCCOPY = 0x00330008,
        NOTSRCERASE = 0x001100A6,
        MERGECOPY = 0x00C000CA,
        MERGEPAINT = 0x00BB0226,
        PATCOPY = 0x00F00021,
        PATPAINT = 0x00FB0A09,
        PATINVERT = 0x005A0049,
        DSTINVERT = 0x00550009,
        BLACKNESS = 0x00000042,
        WHITENESS = 0x00FF0062,
        CAPTUREBLT = 0x40000000 //only if WinVer >= 5.0.0 (see wingdi.h)
    }

    public enum PrintWindowMode : uint
    {
        [Description("Only the client area of the window is copied to hdcBlt. By default, the entire window is copied.")]
        PW_CLIENTONLY = 0x00000001,

        [Description("works on windows that use DirectX or DirectComposition")]
        PW_RENDERFULLCONTENT = 0x00000002
    }
}

public sealed class Win32Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int Left;    //最左坐标
        public int Top;     //最上坐标
        public int Right;   //最右坐标
        public int Bottom;  //最下坐标

        public int Width => Right - Left;
        public int Height => Bottom - Top;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct BitmapFileHeader
    {
        public ushort bfType;
        public uint bfSize;
        public ushort bfReserved1;
        public ushort bfReserved2;
        public uint bfOffBits;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BitmapInfoHeader
    {
        public uint biSize;
        public int biWidth;
        public int biHeight;
        public ushort biPlanes;
        public ushort biBitCount;
        public uint biCompression;
        public uint biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public uint biClrUsed;
        public uint biClrImportant;

        public void Init()
        {
            biSize = (uint)Marshal.SizeOf(this);
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RgbQuad
    {
        public byte rgbBlue;
        public byte rgbGreen;
        public byte rgbRed;
        public byte rgbReserved;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BitmapInfo
    {
        public BitmapInfoHeader bmiHeader;
        public RgbQuad bmiColors;
    }
}
