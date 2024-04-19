using System.ComponentModel;

namespace WinCapture
{
    public class ControlEX
    {
        public partial class WaterTST : ToolStripTextBox
        {
            private readonly Label waterText = new();

            public WaterTST()
            {
                waterText.BorderStyle = BorderStyle.None;
                waterText.Enabled = false;
                waterText.BackColor = Color.White;
                waterText.AutoSize = false;
                waterText.Top = 1;
                waterText.Left = 2;
                waterText.FlatStyle = FlatStyle.System;
            }

            [Category("扩展属性"), Description("显示的提示信息")]
            public string WaterText
            {
                get { return waterText.Text; }
                set { waterText.Text = value; }
            }

            //public override string Text
            //{
            //    get { return base.Text; }
            //    set
            //    {
            //        waterText.Visible = value == string.Empty;
            //        base.Text = value;
            //    }
            //}

            protected override void OnTextChanged(EventArgs e)
            {
                waterText.Visible = base.Text == string.Empty;
                base.OnTextChanged(e);
            }

            protected override void OnMouseDown(MouseEventArgs e)
            {
                waterText.Visible = false;
                base.OnMouseDown(e);
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                waterText.Visible = base.Text == string.Empty;
                base.OnMouseLeave(e);
            }

        }
    }
}
