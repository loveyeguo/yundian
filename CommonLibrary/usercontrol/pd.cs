using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccountingApplication.model;
using AccountingApplication.showform;
using AccountingApplication.Bll;
using CommonLibrary;

namespace AccountingApplication.usercontrol
{
    public partial class pd : UserControl
    {
        DataTable allQuestion = new DataTable();
        int currentIndex = -1;
        int maxIndex = 0;
        DataRow currentRow = null;
        string currentSelectRadio = null;
        private bool isErrorNote = false;
        public pd(DataTable allQuestion, bool iserror)
        {
            isErrorNote = iserror;
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
            this.allQuestion = allQuestion;
         //   RandomDataTable();
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
            rbttrue.Click += new EventHandler(radioBtn_CheckedChange);
            rbtfalse.Click += new EventHandler(radioBtn_CheckedChange);
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
                currentSelectRadio = "无";
            }
            if(currentSelectRadio.Trim() == "正确")
            {
                model.yourAnswer="对";
            }
            else if (currentSelectRadio.Trim() == "错误")
            {
                model.yourAnswer = "错";
            }
            else
            {
                model.yourAnswer = "无";
            }
            model.analysis = currentRow["analysis"].ToString();
            if (model.yourAnswer.Trim().ToLower() != model.bzAnswer.Trim().ToLower())
            {
                model.score = "0";
                //收藏到错题集
                ShouCangHelper sc = new ShouCangHelper(ShouCangHelper.ShouCangTimu.判断题, Convert.ToInt32(currentRow["KeyId"].ToString()));
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
        private void SetAnswerFalse()
        {
            rbttrue.Checked = false;
            rbtfalse.Checked = false;
            currentSelectRadio = "无";
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
          //  lblTitle.Text = currentRow["title"].ToString();
            webBrowser1.DocumentText = ContentShow.GetTile(currentRow["title"].ToString(), ContentShow.ColorBrowser.针对普通题目);
            lbltm.Text = "第" + (currentIndex + 1) + "题(共" + (maxIndex + 1) + "题）";
        }
        private void ShowQuestionPrev()
        {
            currentIndex--;
            if (currentIndex <0)
            {
                MessageBox.Show("已经是第一题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentIndex++;
                return;
            }
            currentRow = allQuestion.Rows[currentIndex];
          //  lblTitle.Text = currentRow["title"].ToString();
            webBrowser1.DocumentText = ContentShow.GetTile(currentRow["title"].ToString(), ContentShow.ColorBrowser.针对普通题目);
            lbltm.Text = "第" + (currentIndex + 1) + "题(共" + (maxIndex + 1) + "题）";

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
        private void ShowSCText()
        {
            SetAnswerFalse();
            ShouCangHelper sc = new ShouCangHelper
               (ShouCangHelper.ShouCangTimu.判断题, Convert.ToInt32(currentRow["KeyId"])); 
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
              (ShouCangHelper.ShouCangTimu.判断题, Convert.ToInt32(currentRow["KeyId"]));
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
                (ShouCangHelper.ShouCangTimu.判断题, Convert.ToInt32(currentRow["KeyId"]));
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

        private void pd_Load(object sender, EventArgs e)
        {

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            ShowQuestionPrev();
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
