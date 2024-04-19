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
            MS菜单 = new MenuStrip();
            TSM添加 = new ToolStripMenuItem();
            TSM窗口 = new ToolStripMenuItem();
            TSM水平 = new ToolStripMenuItem();
            TSM垂直 = new ToolStripMenuItem();
            TSM层叠 = new ToolStripMenuItem();
            TSM全部关闭 = new ToolStripMenuItem();
            MS菜单.SuspendLayout();
            SuspendLayout();
            // 
            // MS菜单
            // 
            MS菜单.Items.AddRange(new ToolStripItem[] { TSM添加, TSM窗口, TSM全部关闭 });
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
            // TSM窗口
            // 
            TSM窗口.DropDownItems.AddRange(new ToolStripItem[] { TSM水平, TSM垂直, TSM层叠 });
            TSM窗口.Name = "TSM窗口";
            TSM窗口.Size = new Size(44, 21);
            TSM窗口.Text = "窗口";
            // 
            // TSM水平
            // 
            TSM水平.Name = "TSM水平";
            TSM水平.Size = new Size(100, 22);
            TSM水平.Text = "水平";
            TSM水平.Click += TSM水平_Click;
            // 
            // TSM垂直
            // 
            TSM垂直.Name = "TSM垂直";
            TSM垂直.Size = new Size(100, 22);
            TSM垂直.Text = "垂直";
            TSM垂直.Click += TSM垂直_Click;
            // 
            // TSM层叠
            // 
            TSM层叠.Name = "TSM层叠";
            TSM层叠.Size = new Size(100, 22);
            TSM层叠.Text = "层叠";
            TSM层叠.Click += TSM层叠_Click;
            // 
            // TSM全部关闭
            // 
            TSM全部关闭.Name = "TSM全部关闭";
            TSM全部关闭.Size = new Size(68, 21);
            TSM全部关闭.Text = "全部关闭";
            TSM全部关闭.Click += TSM全部关闭_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 441);
            Controls.Add(MS菜单);
            IsMdiContainer = true;
            MainMenuStrip = MS菜单;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WinCapture";
            MS菜单.ResumeLayout(false);
            MS菜单.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip MS菜单;
        private ToolStripMenuItem TSM添加;
        private ToolStripMenuItem TSM窗口;
        private ToolStripMenuItem TSM水平;
        private ToolStripMenuItem TSM垂直;
        private ToolStripMenuItem TSM层叠;
        private ToolStripMenuItem TSM全部关闭;
    }
}
