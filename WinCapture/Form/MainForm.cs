using System.Text;

namespace WinCapture
{
    public partial class MainForm : Form
    {
        readonly List<CaptureForm> captureForms = [];

        public MainForm()
        {
            InitializeComponent();
            MS菜单.Items.Add(new ToolStripSeparator());
        }

        private void TSM添加_Click(object sender, EventArgs e)
        {
            CaptureForm captureForm = new()
            {
                MdiParent = this
            };
            captureForm.Show();
            captureForms.Add(captureForm);
        }

        private void TSM水平_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void TSM垂直_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TSM层叠_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TSM全部关闭_Click(object sender, EventArgs e)
        {
            foreach (CaptureForm captureForm in captureForms)
            {
                captureForm.Close();
            }
            captureForms.Clear();
        }
    }


}
