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
    public partial class dxts : UserControl
    {
        DataTable allQuestion = new DataTable();
        int currentIndex = -1;
        int maxIndex = 0;
        DataRow currentRow = null;
        string currentSelectCheck = null;
        private bool isErrorNote = false;
        public dxts(DataTable allQuestion, bool iserror)
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
            ShowQuestion();
            ShowSCText();
        }
        private void btnrandom_Click(object sender, EventArgs e)
        {
            ShowQuestion();
            ShowSCText();
        }

        private void btnjiexi_Click(object sender, EventArgs e)
        {
            getCheckbox();
            Modeldajx model = new Modeldajx();
            model.bzAnswer = currentRow["answer"].ToString().Trim();
            if (currentSelectCheck == null)
            {
                currentSelectCheck = "";
            }
            model.analysis = currentRow["analysis"].ToString();
            char[] bz = model.bzAnswer.ToCharArray();
            char[] your = currentSelectCheck.Trim().ToCharArray();
            Array.Sort(bz);
            Array.Sort(your);
            string stringbz = new string(bz);
            string stringyour = new string(your);
            model.yourAnswer = stringyour;
            if (stringbz.ToLower().Trim() != stringyour.ToLower().Trim())
            {
                model.score = "0";
                //
                //收藏到错题集
                ShouCangHelper sc = new ShouCangHelper(ShouCangHelper.ShouCangTimu.多选题, Convert.ToInt32(currentRow["KeyId"].ToString()));
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
            ClearCheckbox();
            currentIndex++;
            if (currentIndex > maxIndex)
            {
                MessageBox.Show("题目已做完", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentIndex--;
                return;
            }
            currentRow = allQuestion.Rows[currentIndex];
            webBrowser1.DocumentText = ContentShow.GetTile(currentRow["title"].ToString(), ContentShow.ColorBrowser.针对普通题目);
            //  lblTitle.Text = currentRow["title"].ToString();
            //lblTitle.Text = "";
            lbla.Text = currentRow["a"].ToString();
            lblb.Text = currentRow["b"].ToString();
            lblc.Text = currentRow["c"].ToString();
            lbld.Text = currentRow["d"].ToString();
            lbltm.Text = "第" + (currentIndex + 1) + "题(共" + (maxIndex + 1) + "题）";
        }
        private void ShowQuestionLast()
        {
            ClearCheckbox();
            currentIndex--;
            if (currentIndex < 0)
            {
                MessageBox.Show("已经是第一题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentIndex++;
                return;
            }
            currentRow = allQuestion.Rows[currentIndex];
            //lblTitle.Text = currentRow["title"].ToString();
            webBrowser1.DocumentText = ContentShow.GetTile(currentRow["title"].ToString(), ContentShow.ColorBrowser.针对普通题目);
            //lblTitle.Text = "";
            lbla.Text = currentRow["a"].ToString();
            lblb.Text = currentRow["b"].ToString();
            lblc.Text = currentRow["c"].ToString();
            lbld.Text = currentRow["d"].ToString();
            lbltm.Text = "第" + (currentIndex + 1) + "题(共" + (maxIndex + 1) + "题）";
        }
        private void getCheckbox()
        {
            currentSelectCheck = null;
            //遍历窗体上所有控件
            foreach (Control ctr in this.Controls)
            {
                //判断该控件是不是CheckBox
                if (ctr is CheckBox)
                {
                    //将ctr转换成CheckBox并赋值给ck
                    CheckBox ck = ctr as CheckBox;
                    if (ck.Checked)
                    {
                        currentSelectCheck += (ck.Text);
                    }
                }

            }

        }
        private void ClearCheckbox()
        {
            //遍历窗体上所有控件
            foreach (Control ctr in this.Controls)
            {
                //判断该控件是不是CheckBox
                if (ctr is CheckBox)
                {
                    //将ctr转换成CheckBox并赋值给ck
                    CheckBox ck = ctr as CheckBox;
                    ck.Checked = false;
                }
            }
        }

        private void dxts_Load(object sender, EventArgs e)
        {

        }
        private void ShowSCText()
        {

            ShouCangHelper sc = new ShouCangHelper
               (ShouCangHelper.ShouCangTimu.多选题, Convert.ToInt32(currentRow["KeyId"]));
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
              (ShouCangHelper.ShouCangTimu.多选题, Convert.ToInt32(currentRow["KeyId"]));
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
                (ShouCangHelper.ShouCangTimu.多选题, Convert.ToInt32(currentRow["KeyId"]));
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

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

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
