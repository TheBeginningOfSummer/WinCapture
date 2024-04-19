namespace WinCapture
{
    partial class CaptureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BTN复制句柄 = new Button();
            LB句柄 = new Label();
            BTN句柄 = new Button();
            MS菜单 = new MenuStrip();
            TSM运行 = new ToolStripMenuItem();
            TSM开始 = new ToolStripMenuItem();
            TSM停止 = new ToolStripMenuItem();
            TSM显示 = new ToolStripMenuItem();
            TSM显示当前捕捉 = new ToolStripMenuItem();
            TSM设置 = new ToolStripMenuItem();
            TSM窗口设置 = new ToolStripMenuItem();
            TSTX偏移 = new ToolStripTextBox();
            TSTY偏移 = new ToolStripTextBox();
            MS菜单.SuspendLayout();
            SuspendLayout();
            // 
            // BTN复制句柄
            // 
            BTN复制句柄.Location = new Point(169, 28);
            BTN复制句柄.Name = "BTN复制句柄";
            BTN复制句柄.Size = new Size(60, 23);
            BTN复制句柄.TabIndex = 8;
            BTN复制句柄.Text = "复制";
            BTN复制句柄.UseVisualStyleBackColor = true;
            BTN复制句柄.Click += BTN复制句柄_Click;
            // 
            // LB句柄
            // 
            LB句柄.AutoSize = true;
            LB句柄.Location = new Point(54, 31);
            LB句柄.Name = "LB句柄";
            LB句柄.Size = new Size(32, 17);
            LB句柄.TabIndex = 7;
            LB句柄.Text = "句柄";
            // 
            // BTN句柄
            // 
            BTN句柄.FlatAppearance.BorderColor = Color.White;
            BTN句柄.FlatAppearance.MouseDownBackColor = Color.LightGray;
            BTN句柄.FlatAppearance.MouseOverBackColor = Color.LightGray;
            BTN句柄.FlatStyle = FlatStyle.Flat;
            BTN句柄.Font = new Font("Microsoft YaHei UI", 5F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            BTN句柄.Location = new Point(10, 26);
            BTN句柄.Margin = new Padding(1);
            BTN句柄.Name = "BTN句柄";
            BTN句柄.Padding = new Padding(1);
            BTN句柄.Size = new Size(40, 30);
            BTN句柄.TabIndex = 6;
            BTN句柄.Text = "拖拽到目标";
            BTN句柄.UseVisualStyleBackColor = true;
            BTN句柄.MouseDown += BTN句柄_MouseDown;
            BTN句柄.MouseMove += BTN句柄_MouseMove;
            BTN句柄.MouseUp += BTN句柄_MouseUp;
            // 
            // MS菜单
            // 
            MS菜单.BackColor = Color.Transparent;
            MS菜单.Items.AddRange(new ToolStripItem[] { TSM运行, TSM显示, TSM设置 });
            MS菜单.Location = new Point(0, 0);
            MS菜单.Name = "MS菜单";
            MS菜单.Size = new Size(234, 25);
            MS菜单.TabIndex = 12;
            MS菜单.Text = "menuStrip1";
            // 
            // TSM运行
            // 
            TSM运行.DropDownItems.AddRange(new ToolStripItem[] { TSM开始, TSM停止 });
            TSM运行.Name = "TSM运行";
            TSM运行.Size = new Size(44, 21);
            TSM运行.Text = "运行";
            // 
            // TSM开始
            // 
            TSM开始.Name = "TSM开始";
            TSM开始.Size = new Size(100, 22);
            TSM开始.Text = "开始";
            TSM开始.Click += TSM开始_Click;
            // 
            // TSM停止
            // 
            TSM停止.Name = "TSM停止";
            TSM停止.Size = new Size(100, 22);
            TSM停止.Text = "停止";
            TSM停止.Click += TSM停止_Click;
            // 
            // TSM显示
            // 
            TSM显示.DropDownItems.AddRange(new ToolStripItem[] { TSM显示当前捕捉 });
            TSM显示.Name = "TSM显示";
            TSM显示.Size = new Size(44, 21);
            TSM显示.Text = "显示";
            // 
            // TSM显示当前捕捉
            // 
            TSM显示当前捕捉.Name = "TSM显示当前捕捉";
            TSM显示当前捕捉.Size = new Size(148, 22);
            TSM显示当前捕捉.Text = "显示捕捉窗口";
            TSM显示当前捕捉.Click += TSM显示当前捕捉_Click;
            // 
            // TSM设置
            // 
            TSM设置.DropDownItems.AddRange(new ToolStripItem[] { TSM窗口设置 });
            TSM设置.Name = "TSM设置";
            TSM设置.Size = new Size(44, 21);
            TSM设置.Text = "设置";
            // 
            // TSM窗口设置
            // 
            TSM窗口设置.DropDownItems.AddRange(new ToolStripItem[] { TSTX偏移, TSTY偏移 });
            TSM窗口设置.Name = "TSM窗口设置";
            TSM窗口设置.Size = new Size(180, 22);
            TSM窗口设置.Text = "窗口设置";
            TSM窗口设置.Click += TSM窗口设置_Click;
            // 
            // TSTX偏移
            // 
            TSTX偏移.Name = "TSTX偏移";
            TSTX偏移.Size = new Size(100, 23);
            TSTX偏移.Text = "-8";
            TSTX偏移.ToolTipText = "X偏移";
            // 
            // TSTY偏移
            // 
            TSTY偏移.Name = "TSTY偏移";
            TSTY偏移.Size = new Size(100, 23);
            TSTY偏移.Text = "-30";
            TSTY偏移.ToolTipText = "Y偏移";
            // 
            // CaptureForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(234, 81);
            Controls.Add(BTN复制句柄);
            Controls.Add(LB句柄);
            Controls.Add(BTN句柄);
            Controls.Add(MS菜单);
            MainMenuStrip = MS菜单;
            Name = "CaptureForm";
            Text = "CaptureForm";
            FormClosing += CaptureForm_FormClosing;
            MS菜单.ResumeLayout(false);
            MS菜单.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BTN复制句柄;
        private Label LB句柄;
        private Button BTN句柄;
        private MenuStrip MS菜单;
        private ToolStripMenuItem TSM运行;
        private ToolStripMenuItem TSM开始;
        private ToolStripMenuItem TSM停止;
        private ToolStripMenuItem TSM设置;
        private ToolStripMenuItem TSM窗口设置;
        private ToolStripTextBox TSTX偏移;
        private ToolStripTextBox TSTY偏移;
        private ToolStripMenuItem TSM显示;
        private ToolStripMenuItem TSM显示当前捕捉;
    }
}