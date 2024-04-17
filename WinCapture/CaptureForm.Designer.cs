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
            BTN停止 = new Button();
            LB标题 = new Label();
            BTN复制句柄 = new Button();
            LB句柄 = new Label();
            BTN句柄 = new Button();
            BTN开始 = new Button();
            SuspendLayout();
            // 
            // BTN停止
            // 
            BTN停止.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BTN停止.Location = new Point(78, 126);
            BTN停止.Name = "BTN停止";
            BTN停止.Size = new Size(60, 23);
            BTN停止.TabIndex = 10;
            BTN停止.Text = "停止";
            BTN停止.UseVisualStyleBackColor = true;
            BTN停止.Click += BTN停止_Click;
            // 
            // LB标题
            // 
            LB标题.AutoSize = true;
            LB标题.Location = new Point(68, 19);
            LB标题.MaximumSize = new Size(200, 60);
            LB标题.Name = "LB标题";
            LB标题.Size = new Size(32, 17);
            LB标题.TabIndex = 9;
            LB标题.Text = "标题";
            // 
            // BTN复制句柄
            // 
            BTN复制句柄.Location = new Point(183, 78);
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
            LB句柄.Location = new Point(68, 81);
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
            BTN句柄.Location = new Point(12, 12);
            BTN句柄.Name = "BTN句柄";
            BTN句柄.Size = new Size(40, 30);
            BTN句柄.TabIndex = 6;
            BTN句柄.Text = "+";
            BTN句柄.UseVisualStyleBackColor = true;
            BTN句柄.MouseDown += BTN句柄_MouseDown;
            BTN句柄.MouseMove += BTN句柄_MouseMove;
            BTN句柄.MouseUp += BTN句柄_MouseUp;
            // 
            // BTN开始
            // 
            BTN开始.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BTN开始.Location = new Point(12, 126);
            BTN开始.Name = "BTN开始";
            BTN开始.Size = new Size(60, 23);
            BTN开始.TabIndex = 11;
            BTN开始.Text = "开始";
            BTN开始.UseVisualStyleBackColor = true;
            BTN开始.Click += BTN开始_Click;
            // 
            // CaptureForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 161);
            Controls.Add(BTN开始);
            Controls.Add(BTN停止);
            Controls.Add(LB标题);
            Controls.Add(BTN复制句柄);
            Controls.Add(LB句柄);
            Controls.Add(BTN句柄);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CaptureForm";
            Text = "CaptureForm";
            FormClosing += CaptureForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTN停止;
        private Label LB标题;
        private Button BTN复制句柄;
        private Label LB句柄;
        private Button BTN句柄;
        private Button BTN开始;
    }
}