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
                if (URLEdt.Text.Length > 14)
                {
                    string outurl;
                    messageEdt.Text = YACRSSession.Instance.SetAndCheckURL(URLEdt.Text, out outurl);
                    if (!URLEdt.Text.Equals(outurl))
                        URLEdt.Text = outurl;
                }
                UsernameEdt.Text = Properties.Settings.Default.username;// "http://localhost/yacrs/yacrs/";
            }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            messageEdt.ForeColor = Color.Black;
            messageEdt.Text = "Logging in";
            if (YACRSSession.Instance.AttemptLogin(UsernameEdt.Text, PasswordEdt.Text))
            {
                DialogResult = DialogResult.OK;
                if (!File.Exists(configPath))
                {
                    Properties.Settings.Default.username = UsernameEdt.Text;
                    Properties.Settings.Default.Save();
                }
                Close();
            }
            else
            {
                messageEdt.BackColor = SystemColors.Control;
                messageEdt.ForeColor = Color.Red;
                messageEdt.Text = YACRSSession.Instance.LastError;
                PasswordEdt.Text = "";
            }
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
            }
        }

        private void OnUsernameChanged(object sender, EventArgs e)
        {
            if ((UsernameEdt.Text.Length > 0) && (PasswordEdt.Text.Length > 0))
                OKBtn.Enabled = true;
            else
                OKBtn.Enabled = false;
        }

        private void OnPasswordChanged(object sender, EventArgs e)
        {
            if ((UsernameEdt.Text.Length > 0) && (PasswordEdt.Text.Length > 0))
                OKBtn.Enabled = true;
            else
                OKBtn.Enabled = false;
        }

        private void OnActivated(object sender, EventArgs e)
        {
            if (YACRSSession.Instance.ServerOK)
            {
                if (UsernameEdt.Text.Length > 0)
                {
                    PasswordEdt.Focus();
                }
                else
                {
                    UsernameEdt.Focus();
                }
            }
            else
                URLEdt.Focus();
        }
    }
}
