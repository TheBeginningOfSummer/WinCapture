using System.Text;

namespace WinCapture
{
    public partial class CaptureForm : Form
    {
        private bool isMouseDown = false;
        private int hwnd = 0;
        private readonly StringBuilder name = new(256);

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
                Win32.GetCursorPos(out System.Drawing.Point pos);
                hwnd = Win32.WindowFromPoint(pos);
                Win32.GetWindowText(hwnd, name, 256);
                LB句柄.Text = $"句柄 {hwnd}";
                Text = $"{name}";
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

        private void CaptureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cp.IsRun = false;
            cp.IsShow = false;
        }

        private void TSM开始_Click(object sender, EventArgs e)
        {
            if (TSM窗口设置.Checked)
            {
                if (int.TryParse(TSTX偏移.Text, out int x) && int.TryParse(TSTY偏移.Text, out int y))
                {
                    cp.CaptureStart(hwnd, 25, x, y);
                }
            }
            else
            {
                cp.CaptureStart(hwnd);
            }
        }

        private void TSM停止_Click(object sender, EventArgs e)
        {
            cp.IsRun = false;
            cp.IsShow = false;
        }

        private void TSM显示当前捕捉_Click(object sender, EventArgs e)
        {
            if (TSM显示当前捕捉.Checked)
            {
                cp.IsShow = false;
            }
            else
            {
                if (name.Length == 0) name.Append("Window");
                cp.ShowCpaturedStart($"{name}", 25);
            }
            TSM显示当前捕捉.Checked = !TSM显示当前捕捉.Checked;
        }

        private void TSM窗口设置_Click(object sender, EventArgs e)
        {
            TSM窗口设置.Checked = !TSM窗口设置.Checked;
        }
    }
}
