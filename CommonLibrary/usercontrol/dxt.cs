using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AccountingApplication.model;
using AccountingApplication.showform;
using AccountingApplication.Bll;
using CommonLibrary;

namespace AccountingApplication.usercontrol
{
    public partial class dxt : UserControl
    {
        DataTable allQuestion = new DataTable();
        int currentIndex = -1;
        int maxIndex = 0;
        DataRow currentRow = null;
        string currentSelectRadio = null;
        private bool isErrorNote = false;

        public dxt(DataTable allQuestion, bool iserror)
        {
            isErrorNote = iserror;
            InitializeComponent();
            this.allQuestion = allQuestion;
            RandomDataTable();
            maxIndex = allQuestion.Rows.Count - 1;
            if (!CommonIsReg.IsReg)
            {
                if (maxIndex > 7)
                {
                    maxIndex = 7;
                }
            }
            BindRadioClick();
            ShowQuestion();
            ShowSCText();
        }
        private void BindRadioClick()
        {
            rbta.Click += new EventHandler(radioBtn_CheckedChange);
            rbtb.Click += new EventHandler(radioBtn_CheckedChange);
            rbtc.Click += new EventHandler(radioBtn_CheckedChange);
            rbtd.Click += new EventHandler(radioBtn_CheckedChange);
        }
        private void btnrandom_Click(object sender, EventArgs e)
        {
            ShowQuestion();
            ShowSCText();
        }

        private void btnjiexi_Click(object sender, EventArgs e)
        {
            Modeldajx model = new Modeldajx();
            model.bzAnswer = currentRow["answer"].ToString().Trim();
            if (currentSelectRadio == null)
            {
                currentSelectRadio = "未选择";
            }
            model.yourAnswer = currentSelectRadio.Trim();
            model.analysis = currentRow["analysis"].ToString();
            if (model.yourAnswer.Trim().ToLower() != model.bzAnswer.Trim().ToLower())
            {
                model.score = "0";

                //收藏到错题集
                ShouCangHelper sc = new ShouCangHelper(ShouCangHelper.ShouCangTimu.单选题, Convert.ToInt32(currentRow["KeyId"].ToString()));
                sc.AddErrorTable();
            }
            else
            {
                model.score = currentRow["score"].ToString();
            }
            Formdxdxpd f = new Formdxdxpd(model);
            f.ShowDialog();
        }
        private void RandomDataTable()
        {
            allQuestion = allQuestion.AsEnumerable().OrderBy(d => Guid.NewGuid()).CopyToDataTable();
        }
        private void ShowQuestion()
        {
            currentIndex++;
            if (currentIndex > maxIndex)
            {
                MessageBox.Show("题目已做完", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentIndex--;
                return;
            }
            currentRow = allQuestion.Rows[currentIndex];
            //currentRow = allQuestion.Select("KeyId=581")[0];
            webBrowser1.DocumentText = ContentShow.GetTile(currentRow["title"].ToString(), ContentShow.ColorBrowser.针对普通题目);
            //   lblTitle.Text = currentRow["title"].ToString();
            //lblTitle.Text = "";
            lbla.Text = currentRow["a"].ToString();
            lblb.Text = currentRow["b"].ToString();
            lblc.Text = currentRow["c"].ToString();
            lbld.Text = currentRow["d"].ToString();
            lbltm.Text = "第" + (currentIndex + 1) + "题(共" + (maxIndex + 1) + "题）";
        }
        private void ShowQuestionLast()
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                MessageBox.Show("已经是第一题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentIndex++;
                return;
            }
            currentRow = allQuestion.Rows[currentIndex];
            //   lblTitle.Text = currentRow["title"].ToString();
            webBrowser1.DocumentText = ContentShow.GetTile(currentRow["title"].ToString(), ContentShow.ColorBrowser.针对普通题目);
            //lblTitle.Text = "";
            lbla.Text = currentRow["a"].ToString();
            lblb.Text = currentRow["b"].ToString();
            lblc.Text = currentRow["c"].ToString();
            lbld.Text = currentRow["d"].ToString();
            lbltm.Text = "第" + (currentIndex + 1) + "题(共" + (maxIndex + 1) + "题）";
        }
        private void SetAnswerFalse()
        {
            rbta.Checked = false;
            rbtb.Checked = false;
            rbtc.Checked = false;
            rbtd.Checked = false;
            currentSelectRadio = "无";
        }
        //RadioButton新事件
        public void radioBtn_CheckedChange(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }
            currentSelectRadio = (((RadioButton)sender).Text.ToString());
        }

        private void dxt_Load(object sender, EventArgs e)
        {

        }
        private void ShowSCText()
        {
            SetAnswerFalse();
            ShouCangHelper sc = new ShouCangHelper
               (ShouCangHelper.ShouCangTimu.单选题, Convert.ToInt32(currentRow["KeyId"]));
            if (isErrorNote)
            {
                if (sc.IsAlreadyCuotiji())
                {
                    btnsc.Text = "移除";
                }
                else
                {
                    btnsc.Text = "恢复";
                }
            }
            else
            {
                if (sc.IsAlreadyShouCang())
                {
                    btnsc.Text = "取消收藏(&S)";
                }
                else
                {
                    btnsc.Text = "收藏(&S)";
                }
            }

        }

        private void btnsc_Click(object sender, EventArgs e)
        {
            if (isErrorNote)
            {
                ShouCangHelper sc = new ShouCangHelper
              (ShouCangHelper.ShouCangTimu.单选题, Convert.ToInt32(currentRow["KeyId"]));
                if (btnsc.Text == "移除")
                {
                    sc.DelErrorTable();
                }
                else
                {
                    sc.AddErrorTable();
                }
            }
            else
            {
                ShouCangHelper sc = new ShouCangHelper
                (ShouCangHelper.ShouCangTimu.单选题, Convert.ToInt32(currentRow["KeyId"]));
                if (btnsc.Text == "收藏(&S)")
                {
                    sc.AddGoodTable();
                }
                else
                {
                    sc.DelGoodTable();
                }
            }
            ShowSCText();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            ShowQuestionLast();
            ShowSCText();
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Document.Window.Error += Window_Error;
        }
        void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            e.Handled = true;
        }

    }
}
