namespace YACRScontrol
{
    partial class graphDisplay
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
            this.backBtn = new System.Windows.Forms.Button();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.quWebInfo = new System.Windows.Forms.WebBrowser();
            this.compareChk = new System.Windows.Forms.CheckBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backBtn.Location = new System.Drawing.Point(3, 410);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 0;
            this.backBtn.Text = "<<";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // forwardBtn
            // 
            this.forwardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.forwardBtn.Location = new System.Drawing.Point(84, 410);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(75, 23);
            this.forwardBtn.TabIndex = 1;
            this.forwardBtn.Text = ">>";
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.Click += new System.EventHandler(this.forwardBtn_Click);
            // 
            // quWebInfo
            // 
            this.quWebInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quWebInfo.Location = new System.Drawing.Point(13, 29);
            this.quWebInfo.MinimumSize = new System.Drawing.Size(20, 20);
            this.quWebInfo.Name = "quWebInfo";
            this.quWebInfo.Size = new System.Drawing.Size(737, 375);
            this.quWebInfo.TabIndex = 2;
            this.quWebInfo.Visible = false;
            // 
            // compareChk
            // 
            this.compareChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.compareChk.AutoSize = true;
            this.compareChk.Location = new System.Drawing.Point(165, 414);
            this.compareChk.Name = "compareChk";
            this.compareChk.Size = new System.Drawing.Size(179, 17);
            this.compareChk.TabIndex = 3;
            this.compareChk.Text = "Compare with previous response";
            this.compareChk.UseVisualStyleBackColor = true;
            this.compareChk.CheckedChanged += new System.EventHandler(this.compareChk_CheckedChanged);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(12, 3);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(0, 13);
            this.titleLabel.TabIndex = 4;
            // 
            // graphDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(762, 435);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.compareChk);
            this.Controls.Add(this.quWebInfo);
            this.Controls.Add(this.forwardBtn);
            this.Controls.Add(this.backBtn);
            this.Name = "graphDisplay";
            this.Text = "graphDisplay";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.Move += new System.EventHandler(this.graphDisplay_Resize);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.graphDisplay_FormClosing);
            this.Resize += new System.EventHandler(this.graphDisplay_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.WebBrowser quWebInfo;
        private System.Windows.Forms.CheckBox compareChk;
        private System.Windows.Forms.Label titleLabel;

    }
}