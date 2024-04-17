using System.Text;

namespace WinCapture
{
    public partial class CaptureForm : Form
    {
        private bool isMouseDown = false;
        private int hwnd = 0;
        private StringBuilder name = new(256);

        readonly CapturePicture cp = new();

        public CaptureForm()
        {
            InitializeComponent();
        }

        private void BTN句柄_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            Cursor = Cursors.Cross;
        }

        private void BTN句柄_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Win32.GetCursorPos(out Point pos);
                hwnd = Win32.WindowFromPoint(pos);
                Win32.GetWindowText(hwnd, name, 256);
                LB句柄.Text = $"句柄 {hwnd}";
                LB标题.Text = $"标题 {name}";
            }
        }

        private void BTN句柄_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            Cursor = Cursors.Default;
        }

        private void BTN复制句柄_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(hwnd.ToString());
        }

        private void BTN开始_Click(object sender, EventArgs e)
        {
            cp.IsRun = false; Thread.Sleep(200);
            Task.Run(() => cp.CaptureStart(hwnd, true));
        }

        private void BTN停止_Click(object sender, EventArgs e)
        {
            cp.IsRun = false;
        }

        private void CaptureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cp.IsRun = false;
        }
    }
}
