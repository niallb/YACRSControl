using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace YACRScontrol
{
    public partial class loginForm : Form
    {
        private string configPath;
        private int ticks;

        public loginForm()
        {
            InitializeComponent();
            configPath = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf(".")) + ".cfg";
            if (File.Exists(configPath))
            {
                URLEdt.Text = File.ReadAllText(configPath).Trim();
            }
            else
            {
                URLEdt.Text = Properties.Settings.Default.ServerURL;// "http://localhost/yacrs/yacrs/";
            }
            if (URLEdt.Text.Length > 14)
            {
                string outurl;
                messageEdt.Text = YACRSSession.Instance.SetAndCheckURL(URLEdt.Text, out outurl);
                if (!URLEdt.Text.Equals(outurl))
                    URLEdt.Text = outurl;
                if (YACRSSession.Instance.ServerOK)
                {
                    OKBtn.Enabled = true;
                }
            }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            messageEdt.ForeColor = Color.Black;
            messageEdt.Text = "Reqesting login code";
            string url = YACRSSession.Instance.InitiateLogin();
            {
                //MessageBox.Show(url);
                System.Diagnostics.Process.Start(url);
                ticks = 0;
                loginTimer.Start();
            }

            //if (YACRSSession.Instance.AttemptLogin(UsernameEdt.Text, PasswordEdt.Text))
            //{
            //    DialogResult = DialogResult.OK;
            //    if (!File.Exists(configPath))
            //    {
            //        Properties.Settings.Default.username = UsernameEdt.Text;
            //        Properties.Settings.Default.Save();
            //    }
            //    Close();
            //}
            //else
            //{
            //    messageEdt.BackColor = SystemColors.Control;
            //    messageEdt.ForeColor = Color.Red;
            //    messageEdt.Text = YACRSSession.Instance.LastError;
            //}
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnURLEditDone(object sender, EventArgs e)
        {
            messageEdt.ForeColor = Color.Black;
            string outurl;
            messageEdt.Text = YACRSSession.Instance.SetAndCheckURL(URLEdt.Text, out outurl);
            URLEdt.Text = outurl;
            if (YACRSSession.Instance.ServerOK)
            {
                Properties.Settings.Default.ServerURL = URLEdt.Text;
                Properties.Settings.Default.Save();
                OKBtn.Enabled = true;
            }
        }

        private void OnPasswordChanged(object sender, EventArgs e)
        {
                OKBtn.Enabled = true;
        }

        private void OnActivated(object sender, EventArgs e)
        {
            if (YACRSSession.Instance.ServerOK)
            {
                    OKBtn.Focus();
            }
            else
                URLEdt.Focus();
        }

        private void loginTimer_Tick(object sender, EventArgs e)
        {
            string msg;
            ticks++;
            if(ticks==300)
            {
                messageEdt.Text = "Timed out";
                loginTimer.Stop();
            }
            if(YACRSSession.Instance.CheckLoginStatus(out msg))
            {
                loginTimer.Stop();
                messageEdt.Text = msg;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                messageEdt.Text = msg;
            }
        }

        private void URLEdt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                SendKeys.Send("{TAB}");
        }
    }
}
