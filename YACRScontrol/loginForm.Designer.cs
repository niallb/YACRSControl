namespace YACRScontrol
{
    partial class loginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.URLEdt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UsernameEdt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PasswordEdt = new System.Windows.Forms.TextBox();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.messageEdt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server URL";
            // 
            // URLEdt
            // 
            this.URLEdt.Location = new System.Drawing.Point(79, 10);
            this.URLEdt.Name = "URLEdt";
            this.URLEdt.Size = new System.Drawing.Size(303, 20);
            this.URLEdt.TabIndex = 1;
            this.URLEdt.Leave += new System.EventHandler(this.OnURLEditDone);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // UsernameEdt
            // 
            this.UsernameEdt.Location = new System.Drawing.Point(79, 38);
            this.UsernameEdt.Name = "UsernameEdt";
            this.UsernameEdt.Size = new System.Drawing.Size(135, 20);
            this.UsernameEdt.TabIndex = 3;
            this.UsernameEdt.TextChanged += new System.EventHandler(this.OnUsernameChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // PasswordEdt
            // 
            this.PasswordEdt.Location = new System.Drawing.Point(79, 66);
            this.PasswordEdt.Name = "PasswordEdt";
            this.PasswordEdt.PasswordChar = '*';
            this.PasswordEdt.Size = new System.Drawing.Size(135, 20);
            this.PasswordEdt.TabIndex = 5;
            this.PasswordEdt.TextChanged += new System.EventHandler(this.OnPasswordChanged);
            // 
            // OKBtn
            // 
            this.OKBtn.Enabled = false;
            this.OKBtn.Location = new System.Drawing.Point(225, 64);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 6;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(307, 64);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // messageEdt
            // 
            this.messageEdt.Location = new System.Drawing.Point(225, 38);
            this.messageEdt.Name = "messageEdt";
            this.messageEdt.ReadOnly = true;
            this.messageEdt.Size = new System.Drawing.Size(157, 20);
            this.messageEdt.TabIndex = 8;
            this.messageEdt.TabStop = false;
            // 
            // loginForm
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(387, 98);
            this.Controls.Add(this.messageEdt);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.PasswordEdt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UsernameEdt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.URLEdt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connect to a YACRS server and login";
            this.Activated += new System.EventHandler(this.OnActivated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox URLEdt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsernameEdt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PasswordEdt;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox messageEdt;
    }
}