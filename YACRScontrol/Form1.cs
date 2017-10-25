using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Reflection;

using System.Diagnostics; // to allow stopwatch for checking server response time

namespace YACRScontrol
{
    public partial class Form1 : Form
    {
        private int moveXoffset;
        private int moveYoffset;
        private int startHeight;
        private int startWidth;
        private bool moving;
        private bool moved;
        private bool updatingSettings;
        private bool inSession;
        private bool inQuestion;
        private bool showSessionID;
        private bool expanded;
        public enum formState { nodata, unchanged, changed, unsaved }
        private formState state;
        graphDisplay myGraphCtrl;

        public Form1()
        {
            InitializeComponent();
            state = formState.nodata;
            showSessionID = false;
            close2.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            if (inSession)
            {
                //Stopwatch t = new Stopwatch();
                //t.Start();
                this.TopMost = true;
                updateInfoDisplay(false);
                //t.Stop();
                //numberLabel.Text = "dbg:"+t.ElapsedMilliseconds.ToString();
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void updateInfoDisplay(bool getFullInfo)
        {           
            cls_questionResponseInfo ri = YACRSSession.Instance.questionInfo(getFullInfo);
            if (ri != null)
            {
                if (ri.M_id > 0)
                {
                    QuID.Text = ri.M_questiontype; // Field name needs changed in XML to correct this odd var name.
                    if (ri.M_timeToGo != null)
                    {
                        addTimeBtn.Enabled = true;
                        captionLabel.Text = "Time (#resp)";
                        numberLabel.Text = ri.M_timeToGo.ToString() + " (" + ri.M_responseCount.ToString() + ")";
                        if (ri.M_timeToGo == 0)
                        {
                            YACRSSession.Instance.stopQuestion();
                            setInQuestion(false);
                        }
                    }
                    else
                    {
                        addTimeBtn.Enabled = false;
                        captionLabel.Text = "#resp/#users";
                        numberLabel.Text = ri.M_responseCount.ToString() + " / " + ri.M_totalUsers.ToString();
                    }
                    if ((myGraphCtrl != null) && (myGraphCtrl.Visible))
                        myGraphCtrl.setData(ri);
                    if (!inQuestion)
                        setInQuestion(true);
                }
                else
                {
                    if (showSessionID)
                    {
                        QuID.Text = "";
                        ShowSessionID();
                    }
                    else
                    {
                        QuID.Text = YACRSSession.Instance.Detail.M_id.ToString();
                        captionLabel.Text = "active/total";
                        numberLabel.Text = ri.M_activeUsers.ToString() + " / " + ri.M_totalUsers.ToString();
                        if (inQuestion)
                            setInQuestion(false);
                    }
                }
            }
            else
            {
                ShowSessionID();
            }
        }



        private void OnPaint(object sender, PaintEventArgs e)
        {
            if (inSession)
                e.Graphics.DrawRectangle(Pens.Black, 0, 0, Width - 2, Height - 2);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            moved = false;
            moveXoffset = e.X;
            moveYoffset = e.Y;            
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                moved = true;
                Point location = new Point(this.Left + e.X - moveXoffset, this.Top + e.Y - moveYoffset);
                this.Location = location;
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var version = Assembly.GetEntryAssembly().GetName().Version;
                var buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(
                TimeSpan.TicksPerDay * version.Build + // days since 1 January 2000
                TimeSpan.TicksPerSecond * 2 * version.Revision));
                Assembly assem = Assembly.GetEntryAssembly();
                AssemblyName assemName = assem.GetName();
                Version ver = assemName.Version;
                versionTxt.Text = assemName.Name+ " "+version.Major.ToString()+"."+version.Minor.ToString()+ ", Build date " + buildDateTime.ToShortDateString();
            }
            catch (Exception ex)
            {
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            loginForm lform = new loginForm();
            DialogResult result = lform.ShowDialog();
            if (result != DialogResult.OK)
                Close();
            else
            {
                if (YACRSSession.Instance.CourseIdSupported)
                    courseIdentifierEdt.Enabled = true;
                else
                    courseIdentifierEdt.Enabled = false;
                int DefaultQuSelID = 0;
                foreach (cls_globalQuType qt in YACRSSession.Instance.AvailableQus)
                {
                    DefaultQuSel.Items.Add(qt);
                    if (qt.M_id == Properties.Settings.Default.defaultQuID)
                        DefaultQuSelID = DefaultQuSel.Items.Count - 1;
                }
                if (DefaultQuSel.Items.Count > 0)
                {

                    DefaultQuSel.SelectedIndex = DefaultQuSelID;
                }
                RefreshList();
                enableAppropriateComponents();
            }
        }

        private void RefreshList()
        {
            List<cls_sessionInfo> sessions = YACRSSession.Instance.getSessionList();
            if (sessions != null)
            {
                sessionList.Items.Clear();
                foreach (cls_sessionInfo s in sessions)
                {
                    sessionList.Items.Add(s);
                    if ((YACRSSession.Instance.Detail != null) && (YACRSSession.Instance.Detail.M_id == s.M_id))
                        sessionList.SelectedIndex = sessionList.Items.Count - 1;
                    else if (Properties.Settings.Default.sessionID == s.M_id)
                        sessionList.SelectedIndex = sessionList.Items.Count - 1;
                }
            }
        }

        private void OnSelectSession(object sender, EventArgs e)
        {
            cls_sessionInfo si = (cls_sessionInfo)sessionList.SelectedItem;
            if (si != null)
            {
                YACRSSession.Instance.getSessionDetail(si.M_id);
                state = formState.unchanged;
                updateSessionEditFields();
            }
            enableAppropriateComponents();
        }

        private void updateSessionEditFields()
        {
            updatingSettings = true;
            if (YACRSSession.Instance.Detail != null)
            {
                titleEdt.Text = YACRSSession.Instance.Detail.M_title;
                //courseIDEdt.Text = sd.M_c
                allowGuestsChk.Checked = YACRSSession.Instance.Detail.M_allowGuests;
                visibleChk.Checked = YACRSSession.Instance.Detail.M_visible;
                questionModeSel.SelectedIndex = (int)YACRSSession.Instance.Detail.M_questionMode;
                defaultQuActiveSecs.Text = YACRSSession.Instance.Detail.M_defaultQuActiveSecs.ToString();
                allowQuReviewChk.Checked = YACRSSession.Instance.Detail.M_allowQuReview;
                ublogRoomSel.SelectedIndex = (int)YACRSSession.Instance.Detail.M_ublogRoom;
                maxMessagelengthEdt.Text = YACRSSession.Instance.Detail.M_maxMessagelength.ToString();
                allowTeacherQuChk.Checked = YACRSSession.Instance.Detail.M_allowTeacherQu;
                courseIdentifierEdt.Text = YACRSSession.Instance.Detail.M_courseIdentifier;
                ShowSessionID();
                sessionDetailPanel.Enabled = true;
            }
            else
            {
                titleEdt.Text = "";
                //courseIDEdt.Text = sd.M_c
                allowGuestsChk.Checked = false;
                visibleChk.Checked = true;
                questionModeSel.SelectedIndex = 0;
                defaultQuActiveSecs.Text = "120";
                allowQuReviewChk.Checked = false;
                ublogRoomSel.SelectedIndex = 0;
                maxMessagelengthEdt.Text = "140";
                allowTeacherQuChk.Checked = false;
                sessionDetailPanel.Enabled = false;
            }
            updatingSettings = false;
        }

        private void ShowSessionID()
        {
            if (YACRSSession.Instance.Detail.M_id > 0)
            {
                captionLabel.Text = "Session ID";
                numberLabel.Text = YACRSSession.Instance.Detail.M_id.ToString();
            }
            else
            {
                captionLabel.Text = "";
                numberLabel.Text = "";
            }
        }

        private void questionModeSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (questionModeSel.SelectedIndex == 0)
            {
                questionModeLabel.BackColor = SystemColors.Control;
                questionModeLabel.ForeColor = Color.Black;
            }
            else
            {
                questionModeLabel.BackColor = SystemColors.Control;
                questionModeLabel.ForeColor = Color.Red;
            }
            settingChanged(sender, e);
        }

        private void newSessionBtn_Click(object sender, EventArgs e)
        {
            YACRSSession.Instance.newSession();
            state = formState.unsaved;
            updateSessionEditFields();
            enableAppropriateComponents();
        }

        private void settingChanged(object sender, EventArgs e)
        {
            if (!updatingSettings)
            {
                if (state == formState.unchanged)
                {
                    state = formState.changed;
                    enableAppropriateComponents();
                }
            }
        }

        private void enableAppropriateComponents()
        {
            switch (state)
            {
                case formState.nodata:
                    sessionList.Enabled = true;
                    sessionDetailPanel.Enabled = false;
                    newSessionBtn.Enabled = true;
                    startBtn.Enabled = false;
                    OKBtn.Enabled = false;
                    cancelBtn.Enabled = false;
                    OKBtn.Text = "Create";
                    break;
                case formState.unchanged:
                    sessionList.Enabled = true;
                    sessionDetailPanel.Enabled = true;
                    newSessionBtn.Enabled = true;
                    if ((YACRSSession.Instance.Detail.M_questionMode == cls_sessionDetail.qmode.teacherled)&&(DefaultQuSel.SelectedIndex >= 0))
                        startBtn.Enabled = true;
                    else
                        startBtn.Enabled = false;
                    OKBtn.Enabled = false;
                    cancelBtn.Enabled = false;
                    OKBtn.Text = "Update";
                    break;
                case formState.changed:
                    sessionList.Enabled = false;
                    sessionDetailPanel.Enabled = true;
                    newSessionBtn.Enabled = false;
                    startBtn.Enabled = false;
                    OKBtn.Enabled = true;
                    cancelBtn.Enabled = true;
                    OKBtn.Text = "Update";
                    break;
                case formState.unsaved:
                    sessionList.Enabled = false;
                    sessionDetailPanel.Enabled = true;
                    newSessionBtn.Enabled = false;
                    startBtn.Enabled = false;
                    if(titleEdt.Text.Length > 0)
                        OKBtn.Enabled = true;
                    else
                        OKBtn.Enabled = true;
                    cancelBtn.Enabled = true;
                    OKBtn.Text = "Create";
                    break;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (state == formState.unsaved)
            {
                state = formState.nodata;
                enableAppropriateComponents();
            }
            else
            {
                updateSessionEditFields();
                state = formState.unchanged;
                enableAppropriateComponents();
            }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            YACRSSession.Instance.Detail.M_title = titleEdt.Text;
            //sd.M_c = courseIDEdt.Text
            YACRSSession.Instance.Detail.M_allowGuests = allowGuestsChk.Checked;
            YACRSSession.Instance.Detail.M_visible = visibleChk.Checked;
            YACRSSession.Instance.Detail.M_questionMode = (cls_sessionDetail.qmode)questionModeSel.SelectedIndex;
            YACRSSession.Instance.Detail.M_defaultQuActiveSecs = int.Parse(defaultQuActiveSecs.Text);
            YACRSSession.Instance.Detail.M_allowQuReview = allowQuReviewChk.Checked;
            YACRSSession.Instance.Detail.M_ublogRoom = (cls_sessionDetail.ublogmode)ublogRoomSel.SelectedIndex;
            YACRSSession.Instance.Detail.M_maxMessagelength = int.Parse(maxMessagelengthEdt.Text);
            YACRSSession.Instance.Detail.M_allowTeacherQu = allowTeacherQuChk.Checked;
            YACRSSession.Instance.Detail.M_courseIdentifier = courseIdentifierEdt.Text;
            if (YACRSSession.Instance.updateSession() > 0)
                state = formState.unchanged;
            else
                state = formState.nodata;
            RefreshList();
            enableAppropriateComponents();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            YACRSSession.Instance.DefaultQuID = ((cls_globalQuType)DefaultQuSel.SelectedItem).M_id;
            Properties.Settings.Default.defaultQuID = YACRSSession.Instance.DefaultQuID;
            cls_sessionInfo si = (cls_sessionInfo)sessionList.SelectedItem;
            Properties.Settings.Default.sessionID = si.M_id;
            Properties.Settings.Default.Save();
            YACRSSession.Instance.StartSession();
            newQuBtn.Enabled = true;
            graphBtn.Enabled = true;
            close2.Enabled = true;
            this.TopMost = true;
            startHeight = this.Height;
            startWidth = this.Width;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = runSessionPanel.Width + 3;
            this.Height = runSessionPanel.Height + 3;
            inSession = true;
            timer1.Enabled = true;
        }

        private void newQuBtn_Click(object sender, EventArgs e)
        {
            if (!inQuestion)
            {
                YACRSSession.Instance.startNewQuestion(new PointF(this.Left, this.Top));
                setInQuestion(true);
            }
            else
            {
                YACRSSession.Instance.stopQuestion();
                setInQuestion(false);
            }
        }

        private void setInQuestion(bool value)
        {
            if (value == true)
            {
                newQuBtn.Image = (Image)Properties.Resources.ResourceManager.GetObject("stop");
                //graphBtn.Enabled = false;
            }
            else
            {
                newQuBtn.Image = (Image)Properties.Resources.ResourceManager.GetObject("qmark");
                if (YACRSSession.Instance.LastQuInstanceID > 0)
                {
                    graphBtn.Enabled = true;
                    if (YACRSSession.Instance.LastQuInstanceID > 0)
                    {
                        graphBtn.Enabled = true;
                        if ((myGraphCtrl != null)&&(myGraphCtrl.Visible))
                            myGraphCtrl.showLatest();
                    }
                }
            }
            inQuestion = value;
        }

        private void runSessionPanel_MouseClick(object sender, MouseEventArgs e)
        {
            cls_questionResponseInfo ri = YACRSSession.Instance.questionInfo(true);
            if ((ri != null)&&(ri.M_id == 0)&&(!moved)&&(inSession))
            {
                showSessionID = !showSessionID;
                updateInfoDisplay(true);
            }
        }

        private void graphBtn_Click(object sender, EventArgs e)
        {
            if((myGraphCtrl == null)||(myGraphCtrl.IsDisposed))
                myGraphCtrl = new graphDisplay();
            myGraphCtrl.Show();
            myGraphCtrl.TopMost = true;
            //disp.WindowState = FormWindowState.Maximized;
        }

        private void close2_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            inSession = false;
            timer1.Enabled = false;
            showSessionID = true;
            newQuBtn.Enabled = false;
            graphBtn.Enabled = false;
            close2.Enabled = false;
            updateInfoDisplay(true);
            this.Width = startWidth;
            this.Height = startHeight;
        }

        private void OnDefaultQuChanged(object sender, EventArgs e)
        {
            if ((inSession)&&(expanded))
            {
                YACRSSession.Instance.DefaultQuID = ((cls_globalQuType)DefaultQuSel.SelectedItem).M_id;
                expandBtn_Click(sender, e);
            }
        }

        private void addTimeBtn_Click(object sender, EventArgs e)
        {
            YACRSSession.Instance.addTime();
        }

        private void expandBtn_Click(object sender, EventArgs e)
        {
            if (inSession)
            {
                if (expanded)
                {
                    this.Width = runSessionPanel.Width + 3;
                }
                else
                {
                    this.Width = runSessionPanel.Width + 140;
                }
                expanded = !expanded;
            }
        }
    }
}
