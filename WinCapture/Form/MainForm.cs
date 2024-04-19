using System.Text;

namespace WinCapture
{
    public partial class MainForm : Form
    {
        readonly List<CaptureForm> captureForms = [];

        public MainForm()
        {
            InitializeComponent();
            MS�˵�.Items.Add(new ToolStripSeparator());
        }

        private void TSM���_Click(object sender, EventArgs e)
        {
            CaptureForm captureForm = new()
            {
                MdiParent = this
            };
            captureForm.Show();
            captureForms.Add(captureForm);
        }

        private void TSMˮƽ_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void TSM��ֱ_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TSM���_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TSMȫ���ر�_Click(object sender, EventArgs e)
        {
            foreach (CaptureForm captureForm in captureForms)
            {
                captureForm.Close();
            }
            captureForms.Clear();
        }
    }


}
