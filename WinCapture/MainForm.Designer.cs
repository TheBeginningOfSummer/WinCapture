namespace WinCapture
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PB图片 = new PictureBox();
            MS菜单 = new MenuStrip();
            TSM添加 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)PB图片).BeginInit();
            MS菜单.SuspendLayout();
            SuspendLayout();
            // 
            // PB图片
            // 
            PB图片.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PB图片.Location = new Point(12, 27);
            PB图片.Name = "PB图片";
            PB图片.Size = new Size(760, 402);
            PB图片.TabIndex = 4;
            PB图片.TabStop = false;
            // 
            // MS菜单
            // 
            MS菜单.Items.AddRange(new ToolStripItem[] { TSM添加 });
            MS菜单.Location = new Point(0, 0);
            MS菜单.Name = "MS菜单";
            MS菜单.Size = new Size(784, 25);
            MS菜单.TabIndex = 5;
            MS菜单.Text = "menuStrip1";
            // 
            // TSM添加
            // 
            TSM添加.Name = "TSM添加";
            TSM添加.Size = new Size(44, 21);
            TSM添加.Text = "添加";
            TSM添加.Click += TSM添加_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 441);
            Controls.Add(PB图片);
            Controls.Add(MS菜单);
            MainMenuStrip = MS菜单;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WinCapture";
            ((System.ComponentModel.ISupportInitialize)PB图片).EndInit();
            MS菜单.ResumeLayout(false);
            MS菜单.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox PB图片;
        private MenuStrip MS菜单;
        private ToolStripMenuItem TSM添加;
    }
}
