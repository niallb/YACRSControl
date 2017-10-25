using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YACRScontrol
{
    public partial class graphDisplay : Form
    {
        private Dictionary<String, int> theData;
        private Dictionary<String, bool> showAsCorrect;
        private Dictionary<String, int> prevData;
        private List<int> quids;
        private int cqid;
        private string title;

        public graphDisplay()
        {
            InitializeComponent();
            showLatest();
        }

        private int getLatestID()
        {
            quids = YACRSSession.Instance.getSessionQuestionIDs();
            if (quids.Count > 0)
            {
                return quids[quids.Count - 1];
            }
            else
            {
                return 0;
            }
        }

        public void showLatest()
        {
            cqid = getLatestID();
            cls_questionResponseInfo ri = YACRSSession.Instance.questionInfo(cqid);
            setData(ri);
        }

        public void setData(cls_questionResponseInfo ri)
        {
            compareChk.Checked = false;
            compareChk.Enabled = false;
            prevData = null;
            if (ri != null)
            {
                cqid = ri.M_id;
                quids = YACRSSession.Instance.getSessionQuestionIDs();
                int cqidx = quids.IndexOf(cqid) + 1;
                this.Text = "Question " + cqidx.ToString() + " of " + quids.Count.ToString();
                title = ri.M_questiontype;
                Dictionary<string, int> data = new Dictionary<string, int>();
                Dictionary<string, bool> sc = new Dictionary<string, bool>();
                foreach (cls_optionInfo oi in ri.M_optionInfo)
                {
                    data.Add(oi.M_title, oi.M_count);
                    if((oi.M_isCorrect != null)&&(oi.M_isCorrect == true))
                        sc.Add(oi.M_title, true);
                    else
                        sc.Add(oi.M_title, false);
                }
                theData = data;
                showAsCorrect = sc;
                //if ((theData.Count == 0)&&(this.Visible))
                if ((ri.M_displayURL != null) && (ri.M_displayURL != ""))
                {
                    quWebInfo.Visible = true;
                    titleLabel.Text = title;
                    theData.Clear();
                    try
                    {
                        quWebInfo.Navigate(YACRSSession.Instance.baseURL + ri.M_displayURL);
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("Navigate on null object?");
                    }
                }
                else if ((theData.Count == 0)&&(this.Visible))
                {
                    quWebInfo.Visible = true;
                    titleLabel.Text = title;
                    if ((YACRSSession.Instance.serverMajorVer == 0) && (YACRSSession.Instance.serverMinorVer <= 4))
                        quWebInfo.Navigate(YACRSSession.Instance.baseURL + "wordwall.php?qiID=" + cqid.ToString());
                    else
                        quWebInfo.Navigate(YACRSSession.Instance.baseURL + "displayResponses.php?sessionID=" + YACRSSession.Instance.Detail.M_id.ToString() + "&qiID=" + cqid.ToString() + "&width=" + quWebInfo.Width.ToString() + "&height=" + quWebInfo.Height.ToString(), null, null, "Cookie: " + YACRSSession.Instance.loginCookie + "\r\n");
                }
                else
                {
                    quWebInfo.Visible = false;
                    titleLabel.Text = "";
                }
                backBtn.Enabled = false;
                forwardBtn.Enabled = false;
                if ((quids != null) && (quids.Count > 1))
                {
                    if (cqid != quids[0])
                        backBtn.Enabled = true;
                    if (cqid != quids[quids.Count - 1])
                        forwardBtn.Enabled = true;
                }
                // See if compare is valid
                if (cqidx > 1) // cqidx is for display, so starts at 1
                {
                    cls_questionResponseInfo prevri = YACRSSession.Instance.questionInfo(quids[cqidx-2]);
                    if ((ri.M_responseCount > 0) && (prevri.M_responseCount > 0) && (ri.M_optionInfo.Count == prevri.M_optionInfo.Count))
                    {
                        compareChk.Enabled = true;
                        prevData = new Dictionary<string, int>();
                        foreach (cls_optionInfo oi in prevri.M_optionInfo)
                        {
                            prevData.Add(oi.M_title, oi.M_count);
                        }
                    }
                }

            }
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            int textHeight = Height / 15;
            Font txtFont = new Font(FontFamily.GenericSansSerif, textHeight, FontStyle.Bold, GraphicsUnit.Pixel);
            bool doingCompare = ((compareChk.Checked) && (prevData != null) && (prevData.Count == theData.Count));
            
            if (theData != null)
            {
                if (theData.Count > 0)
                {

                    // calculate sizes
                    int colWidth = ClientSize.Width / (theData.Count + 2);
                    int maxval = 1;
                    foreach (KeyValuePair<string, int> dp in theData)
                    {
                        maxval = (dp.Value > maxval) ? dp.Value : maxval;
                    }
                    if (doingCompare)
                    {
                        foreach (KeyValuePair<string, int> dp in prevData)
                        {
                            maxval = (dp.Value > maxval) ? dp.Value : maxval;
                        }
                    }
                    if (maxval > 15)
                    {
                        int roundup = maxval % 10 == 0 ? 0: 10;
                        maxval = ((int)(maxval / 10)) * 10 + roundup;
                    }
                    int baseline = ClientSize.Height - 2 * textHeight - backBtn.Height;
                    float heightMultiplier = ((ClientSize.Height - backBtn.Height) - (4 * textHeight)) / maxval;
                    e.Graphics.DrawLine(Pens.Black, colWidth, baseline, colWidth * (theData.Count + 1), baseline);
                    //$graph->line($colWidth, $baseLine, $colWidth * ($colCount+1), $baseLine);
                    e.Graphics.DrawLine(Pens.Black, colWidth, baseline, colWidth, baseline - (heightMultiplier * maxval));
                    //$graph->line($colWidth, $baseLine, $colWidth, $baseLine - ($hightMultiplier * $maxval));
                    e.Graphics.DrawLine(Pens.Black, colWidth - 5, baseline - (heightMultiplier * maxval), colWidth, baseline - (heightMultiplier * maxval));
                    //$graph->line($colWidth-5, $baseLine - ($hightMultiplier * $maxval), $colWidth, $baseLine - ($hightMultiplier * $maxval));
                    SizeF stringSize = e.Graphics.MeasureString(maxval.ToString(), txtFont);
                    int lxpos = colWidth - (int)stringSize.Width - 10;
                    //$lxpos = $colWidth - getTextWidth($maxval, 5) - 10;
                    int lypos = (int)(baseline - (heightMultiplier * maxval) - (stringSize.Height / 2));
                    //$lypos =  $baseLine - ($hightMultiplier * $maxval) - (getTextHeight($maxval, 5)/2);
                    e.Graphics.DrawString(maxval.ToString(), txtFont, Brushes.Black, lxpos, lypos);
                    //$graph->string(5, $lxpos, $lypos, $maxval);

                    e.Graphics.DrawString(title, txtFont, Brushes.Black, lxpos, lypos - stringSize.Height);

                    int colPos = 0;
                    foreach (KeyValuePair<string, int> dp in theData)
                    {
                        colPos += colWidth;
                        int colCentre = colPos + colWidth / 2;
                        stringSize = e.Graphics.MeasureString(dp.Key, txtFont);
                        lxpos = colCentre - (int)(stringSize.Width / 2);
                        lypos = baseline + textHeight / 4;
                        e.Graphics.DrawString(dp.Key, txtFont, Brushes.Black, lxpos, lypos);
                        Brush br;
                        if (showAsCorrect[dp.Key])
                            br = Brushes.Green;
                        else
                            br = Brushes.Blue;
                        if (doingCompare)
                        {
                            if (dp.Value > 0)
                            {
                                e.Graphics.FillRectangle(br, colPos+colWidth/2, baseline - heightMultiplier * dp.Value, colWidth/2 - 1, heightMultiplier * dp.Value);
                            }
                            int pv;
                            if (prevData.TryGetValue(dp.Key, out pv))
                            {
                                e.Graphics.FillRectangle(Brushes.Red, colPos, baseline - heightMultiplier * pv, colWidth / 2 - 1, heightMultiplier * pv);
                            }
                        }
                        else
                        {
                            if (dp.Value > 0)
                            {
                                e.Graphics.FillRectangle(br, colPos, baseline - heightMultiplier * dp.Value, colWidth - 1, heightMultiplier * dp.Value);

                            }
                        }
                        //e.Graphics.DrawString(dp.Key, txtFont, Brushes.Black, leftPos, basePos*0.2f);
                    }
                }
                else
                {
                    if (quWebInfo.Visible == false)
                    {
                        e.Graphics.DrawString("This response can not be displayed", txtFont, Brushes.Black, 20, 20);
                    }
                }
            }
            else
            {
                e.Graphics.DrawString("No response data", txtFont, Brushes.Black, 20, 20);
            }
        }

        private void graphDisplay_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void graphDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
           Properties.Settings.Default.GraphPos = new Point(this.Left, this.Top);
           Properties.Settings.Default.GraphSize = this.Size;
           Properties.Settings.Default.Save();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            quids = YACRSSession.Instance.getSessionQuestionIDs();
            int nidx = quids.IndexOf(cqid) - 1;
            if(nidx >= 0)
                cqid = quids[nidx];
            cls_questionResponseInfo ri = YACRSSession.Instance.questionInfo(cqid);
            setData(ri);
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            quids = YACRSSession.Instance.getSessionQuestionIDs();
            int nidx = quids.IndexOf(cqid) + 1;
            if ((nidx >= 0)&&(nidx < quids.Count))
                cqid = quids[nidx];
            cls_questionResponseInfo ri = YACRSSession.Instance.questionInfo(cqid);
            setData(ri);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            this.Left = Properties.Settings.Default.GraphPos.X;
            this.Top = Properties.Settings.Default.GraphPos.Y;
            this.Size = Properties.Settings.Default.GraphSize;

        }

        private void compareChk_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
