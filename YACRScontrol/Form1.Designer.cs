namespace YACRScontrol
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.runSessionPanel = new System.Windows.Forms.Panel();
            this.expandBtn = new System.Windows.Forms.Button();
            this.addTimeBtn = new System.Windows.Forms.Button();
            this.close2 = new System.Windows.Forms.Button();
            this.QuID = new System.Windows.Forms.Label();
            this.numberLabel = new System.Windows.Forms.Label();
            this.captionLabel = new System.Windows.Forms.Label();
            this.graphBtn = new System.Windows.Forms.Button();
            this.newQuBtn = new System.Windows.Forms.Button();
            this.sessionList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sessionDetailPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.maxMessagelengthEdt = new System.Windows.Forms.MaskedTextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.allowTeacherQuChk = new System.Windows.Forms.CheckBox();
            this.ublogRoomSel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.allowQuReviewChk = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.defaultQuActiveSecs = new System.Windows.Forms.MaskedTextBox();
            this.questionModeSel = new System.Windows.Forms.ComboBox();
            this.questionModeLabel = new System.Windows.Forms.Label();
            this.visibleChk = new System.Windows.Forms.CheckBox();
            this.allowGuestsChk = new System.Windows.Forms.CheckBox();
            this.courseIdentifierEdt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleEdt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.newSessionBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DefaultQuSel = new System.Windows.Forms.ComboBox();
            this.versionTxt = new System.Windows.Forms.Label();
            this.runSessionPanel.SuspendLayout();
            this.sessionDetailPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // runSessionPanel
            // 
            this.runSessionPanel.Controls.Add(this.expandBtn);
            this.runSessionPanel.Controls.Add(this.addTimeBtn);
            this.runSessionPanel.Controls.Add(this.close2);
            this.runSessionPanel.Controls.Add(this.QuID);
            this.runSessionPanel.Controls.Add(this.numberLabel);
            this.runSessionPanel.Controls.Add(this.captionLabel);
            this.runSessionPanel.Controls.Add(this.graphBtn);
            this.runSessionPanel.Controls.Add(this.newQuBtn);
            this.runSessionPanel.Location = new System.Drawing.Point(1, 1);
            this.runSessionPanel.Name = "runSessionPanel";
            this.runSessionPanel.Size = new System.Drawing.Size(202, 44);
            this.runSessionPanel.TabIndex = 1;
            this.runSessionPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.runSessionPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.runSessionPanel_MouseClick);
            this.runSessionPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.runSessionPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // expandBtn
            // 
            this.expandBtn.Location = new System.Drawing.Point(43, 34);
            this.expandBtn.Name = "expandBtn";
            this.expandBtn.Size = new System.Drawing.Size(36, 10);
            this.expandBtn.TabIndex = 13;
            this.expandBtn.UseVisualStyleBackColor = true;
            this.expandBtn.Click += new System.EventHandler(this.expandBtn_Click);
            // 
            // addTimeBtn
            // 
            this.addTimeBtn.Location = new System.Drawing.Point(23, 0);
            this.addTimeBtn.Name = "addTimeBtn";
            this.addTimeBtn.Size = new System.Drawing.Size(14, 14);
            this.addTimeBtn.TabIndex = 12;
            this.addTimeBtn.UseVisualStyleBackColor = true;
            this.addTimeBtn.Click += new System.EventHandler(this.addTimeBtn_Click);
            // 
            // close2
            // 
            this.close2.Image = global::YACRScontrol.Properties.Resources.stop;
            this.close2.Location = new System.Drawing.Point(3, 0);
            this.close2.Name = "close2";
            this.close2.Size = new System.Drawing.Size(14, 14);
            this.close2.TabIndex = 11;
            this.close2.UseVisualStyleBackColor = true;
            this.close2.Click += new System.EventHandler(this.close2_Click);
            // 
            // QuID
            // 
            this.QuID.AutoSize = true;
            this.QuID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuID.Location = new System.Drawing.Point(3, 17);
            this.QuID.Name = "QuID";
            this.QuID.Size = new System.Drawing.Size(39, 20);
            this.QuID.TabIndex = 5;
            this.QuID.Text = "Q99";
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberLabel.Location = new System.Drawing.Point(117, 3);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(20, 24);
            this.numberLabel.TabIndex = 4;
            this.numberLabel.Text = "0";
            this.numberLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.runSessionPanel_MouseClick);
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.Location = new System.Drawing.Point(118, 25);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(60, 13);
            this.captionLabel.TabIndex = 3;
            this.captionLabel.Text = "Responses";
            this.captionLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.runSessionPanel_MouseClick);
            // 
            // graphBtn
            // 
            this.graphBtn.Enabled = false;
            this.graphBtn.Image = ((System.Drawing.Image)(resources.GetObject("graphBtn.Image")));
            this.graphBtn.Location = new System.Drawing.Point(81, 0);
            this.graphBtn.Name = "graphBtn";
            this.graphBtn.Size = new System.Drawing.Size(36, 35);
            this.graphBtn.TabIndex = 2;
            this.graphBtn.UseVisualStyleBackColor = true;
            this.graphBtn.Click += new System.EventHandler(this.graphBtn_Click);
            // 
            // newQuBtn
            // 
            this.newQuBtn.Enabled = false;
            this.newQuBtn.Image = ((System.Drawing.Image)(resources.GetObject("newQuBtn.Image")));
            this.newQuBtn.Location = new System.Drawing.Point(43, 0);
            this.newQuBtn.Name = "newQuBtn";
            this.newQuBtn.Size = new System.Drawing.Size(36, 35);
            this.newQuBtn.TabIndex = 1;
            this.newQuBtn.UseVisualStyleBackColor = true;
            this.newQuBtn.Click += new System.EventHandler(this.newQuBtn_Click);
            // 
            // sessionList
            // 
            this.sessionList.FormattingEnabled = true;
            this.sessionList.Location = new System.Drawing.Point(12, 77);
            this.sessionList.Name = "sessionList";
            this.sessionList.Size = new System.Drawing.Size(242, 277);
            this.sessionList.TabIndex = 2;
            this.sessionList.SelectedValueChanged += new System.EventHandler(this.OnSelectSession);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sessions";
            // 
            // sessionDetailPanel
            // 
            this.sessionDetailPanel.Controls.Add(this.label9);
            this.sessionDetailPanel.Controls.Add(this.label8);
            this.sessionDetailPanel.Controls.Add(this.maxMessagelengthEdt);
            this.sessionDetailPanel.Controls.Add(this.cancelBtn);
            this.sessionDetailPanel.Controls.Add(this.OKBtn);
            this.sessionDetailPanel.Controls.Add(this.allowTeacherQuChk);
            this.sessionDetailPanel.Controls.Add(this.ublogRoomSel);
            this.sessionDetailPanel.Controls.Add(this.label7);
            this.sessionDetailPanel.Controls.Add(this.allowQuReviewChk);
            this.sessionDetailPanel.Controls.Add(this.label6);
            this.sessionDetailPanel.Controls.Add(this.label5);
            this.sessionDetailPanel.Controls.Add(this.defaultQuActiveSecs);
            this.sessionDetailPanel.Controls.Add(this.questionModeSel);
            this.sessionDetailPanel.Controls.Add(this.questionModeLabel);
            this.sessionDetailPanel.Controls.Add(this.visibleChk);
            this.sessionDetailPanel.Controls.Add(this.allowGuestsChk);
            this.sessionDetailPanel.Controls.Add(this.courseIdentifierEdt);
            this.sessionDetailPanel.Controls.Add(this.label3);
            this.sessionDetailPanel.Controls.Add(this.titleEdt);
            this.sessionDetailPanel.Controls.Add(this.label2);
            this.sessionDetailPanel.Enabled = false;
            this.sessionDetailPanel.Location = new System.Drawing.Point(269, 64);
            this.sessionDetailPanel.Name = "sessionDetailPanel";
            this.sessionDetailPanel.Size = new System.Drawing.Size(398, 290);
            this.sessionDetailPanel.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(146, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "characters";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Max length";
            // 
            // maxMessagelengthEdt
            // 
            this.maxMessagelengthEdt.Location = new System.Drawing.Point(93, 207);
            this.maxMessagelengthEdt.Mask = "000";
            this.maxMessagelengthEdt.Name = "maxMessagelengthEdt";
            this.maxMessagelengthEdt.Size = new System.Drawing.Size(50, 20);
            this.maxMessagelengthEdt.TabIndex = 17;
            this.maxMessagelengthEdt.TextChanged += new System.EventHandler(this.settingChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(312, 264);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 16;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(231, 264);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 15;
            this.OKBtn.Text = "Create";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // allowTeacherQuChk
            // 
            this.allowTeacherQuChk.AutoSize = true;
            this.allowTeacherQuChk.Location = new System.Drawing.Point(93, 233);
            this.allowTeacherQuChk.Name = "allowTeacherQuChk";
            this.allowTeacherQuChk.Size = new System.Drawing.Size(228, 17);
            this.allowTeacherQuChk.TabIndex = 14;
            this.allowTeacherQuChk.Text = "Allow anonymous questions for the teacher";
            this.allowTeacherQuChk.UseVisualStyleBackColor = true;
            this.allowTeacherQuChk.Visible = false;
            this.allowTeacherQuChk.CheckedChanged += new System.EventHandler(this.settingChanged);
            // 
            // ublogRoomSel
            // 
            this.ublogRoomSel.FormattingEnabled = true;
            this.ublogRoomSel.Items.AddRange(new object[] {
            "None",
            "Full class"});
            this.ublogRoomSel.Location = new System.Drawing.Point(93, 180);
            this.ublogRoomSel.Name = "ublogRoomSel";
            this.ublogRoomSel.Size = new System.Drawing.Size(295, 21);
            this.ublogRoomSel.TabIndex = 13;
            this.ublogRoomSel.SelectedIndexChanged += new System.EventHandler(this.settingChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Microblogging";
            // 
            // allowQuReviewChk
            // 
            this.allowQuReviewChk.AutoSize = true;
            this.allowQuReviewChk.Location = new System.Drawing.Point(93, 157);
            this.allowQuReviewChk.Name = "allowQuReviewChk";
            this.allowQuReviewChk.Size = new System.Drawing.Size(139, 17);
            this.allowQuReviewChk.TabIndex = 11;
            this.allowQuReviewChk.Text = "Allow review of answers";
            this.allowQuReviewChk.UseVisualStyleBackColor = true;
            this.allowQuReviewChk.CheckedChanged += new System.EventHandler(this.settingChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(146, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "seconds.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Default time limit";
            // 
            // defaultQuActiveSecs
            // 
            this.defaultQuActiveSecs.Location = new System.Drawing.Point(93, 131);
            this.defaultQuActiveSecs.Mask = "000";
            this.defaultQuActiveSecs.Name = "defaultQuActiveSecs";
            this.defaultQuActiveSecs.Size = new System.Drawing.Size(50, 20);
            this.defaultQuActiveSecs.TabIndex = 8;
            this.defaultQuActiveSecs.TextChanged += new System.EventHandler(this.settingChanged);
            // 
            // questionModeSel
            // 
            this.questionModeSel.FormattingEnabled = true;
            this.questionModeSel.Items.AddRange(new object[] {
            "Teacher led (one question at a time)",
            "Student paced"});
            this.questionModeSel.Location = new System.Drawing.Point(93, 104);
            this.questionModeSel.Name = "questionModeSel";
            this.questionModeSel.Size = new System.Drawing.Size(295, 21);
            this.questionModeSel.TabIndex = 7;
            this.questionModeSel.SelectedIndexChanged += new System.EventHandler(this.questionModeSel_SelectedIndexChanged);
            // 
            // questionModeLabel
            // 
            this.questionModeLabel.AutoSize = true;
            this.questionModeLabel.Location = new System.Drawing.Point(4, 107);
            this.questionModeLabel.Name = "questionModeLabel";
            this.questionModeLabel.Size = new System.Drawing.Size(78, 13);
            this.questionModeLabel.TabIndex = 6;
            this.questionModeLabel.Text = "Question mode";
            // 
            // visibleChk
            // 
            this.visibleChk.AutoSize = true;
            this.visibleChk.Location = new System.Drawing.Point(93, 81);
            this.visibleChk.Name = "visibleChk";
            this.visibleChk.Size = new System.Drawing.Size(208, 17);
            this.visibleChk.TabIndex = 5;
            this.visibleChk.Text = "Display on user\'s available sessions list";
            this.visibleChk.UseVisualStyleBackColor = true;
            this.visibleChk.CheckStateChanged += new System.EventHandler(this.settingChanged);
            // 
            // allowGuestsChk
            // 
            this.allowGuestsChk.AutoSize = true;
            this.allowGuestsChk.Location = new System.Drawing.Point(93, 58);
            this.allowGuestsChk.Name = "allowGuestsChk";
            this.allowGuestsChk.Size = new System.Drawing.Size(176, 17);
            this.allowGuestsChk.TabIndex = 4;
            this.allowGuestsChk.Text = "Allow guest users (without login)";
            this.allowGuestsChk.UseVisualStyleBackColor = true;
            this.allowGuestsChk.CheckStateChanged += new System.EventHandler(this.settingChanged);
            // 
            // courseIdentifierEdt
            // 
            this.courseIdentifierEdt.Location = new System.Drawing.Point(93, 32);
            this.courseIdentifierEdt.Name = "courseIdentifierEdt";
            this.courseIdentifierEdt.Size = new System.Drawing.Size(294, 20);
            this.courseIdentifierEdt.TabIndex = 3;
            this.courseIdentifierEdt.TextChanged += new System.EventHandler(this.settingChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Course Identifier";
            // 
            // titleEdt
            // 
            this.titleEdt.Location = new System.Drawing.Point(93, 6);
            this.titleEdt.Name = "titleEdt";
            this.titleEdt.Size = new System.Drawing.Size(294, 20);
            this.titleEdt.TabIndex = 1;
            this.titleEdt.TextChanged += new System.EventHandler(this.settingChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Title";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(98, 48);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 5;
            this.startBtn.Text = "Start session";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // newSessionBtn
            // 
            this.newSessionBtn.Location = new System.Drawing.Point(179, 48);
            this.newSessionBtn.Name = "newSessionBtn";
            this.newSessionBtn.Size = new System.Drawing.Size(75, 23);
            this.newSessionBtn.TabIndex = 6;
            this.newSessionBtn.Text = "New session";
            this.newSessionBtn.UseVisualStyleBackColor = true;
            this.newSessionBtn.Click += new System.EventHandler(this.newSessionBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Default question type";
            // 
            // DefaultQuSel
            // 
            this.DefaultQuSel.FormattingEnabled = true;
            this.DefaultQuSel.Location = new System.Drawing.Point(205, 19);
            this.DefaultQuSel.Name = "DefaultQuSel";
            this.DefaultQuSel.Size = new System.Drawing.Size(128, 21);
            this.DefaultQuSel.TabIndex = 9;
            this.DefaultQuSel.SelectedIndexChanged += new System.EventHandler(this.OnDefaultQuChanged);
            // 
            // versionTxt
            // 
            this.versionTxt.AutoSize = true;
            this.versionTxt.Location = new System.Drawing.Point(359, 1);
            this.versionTxt.Name = "versionTxt";
            this.versionTxt.Size = new System.Drawing.Size(42, 13);
            this.versionTxt.TabIndex = 11;
            this.versionTxt.Text = "Version";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 363);
            this.Controls.Add(this.versionTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DefaultQuSel);
            this.Controls.Add(this.newSessionBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.sessionDetailPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sessionList);
            this.Controls.Add(this.runSessionPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "YACRS control";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.Shown += new System.EventHandler(this.OnShown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.runSessionPanel.ResumeLayout(false);
            this.runSessionPanel.PerformLayout();
            this.sessionDetailPanel.ResumeLayout(false);
            this.sessionDetailPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel runSessionPanel;
        private System.Windows.Forms.ListBox sessionList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel sessionDetailPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox titleEdt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox questionModeSel;
        private System.Windows.Forms.Label questionModeLabel;
        private System.Windows.Forms.CheckBox visibleChk;
        private System.Windows.Forms.CheckBox allowGuestsChk;
        private System.Windows.Forms.TextBox courseIdentifierEdt;
        private System.Windows.Forms.CheckBox allowQuReviewChk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox defaultQuActiveSecs;
        private System.Windows.Forms.CheckBox allowTeacherQuChk;
        private System.Windows.Forms.ComboBox ublogRoomSel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox maxMessagelengthEdt;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button newSessionBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DefaultQuSel;
        private System.Windows.Forms.Button newQuBtn;
        private System.Windows.Forms.Button graphBtn;
        private System.Windows.Forms.Label captionLabel;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Label QuID;
        private System.Windows.Forms.Button close2;
        private System.Windows.Forms.Button addTimeBtn;
        private System.Windows.Forms.Label versionTxt;
        private System.Windows.Forms.Button expandBtn;
    }
}

