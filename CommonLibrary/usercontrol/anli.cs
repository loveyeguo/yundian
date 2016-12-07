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
    public partial class anli : UserControl
    {
        DataTable allQuestion = new DataTable();
        int currentIndex = -1;
        int maxIndex = 0;
        DataRow currentRow = null;
        string currentSelectCheck = null;
        public anli(DataTable allQuestion)
        {
            InitializeComponent();
            this.allQuestion = allQuestion;
            // RandomDataTable();
            maxIndex = allQuestion.Rows.Count - 1;
            if (!CommonIsReg.IsReg)
            {
                if (maxIndex > 0)
                {
                    maxIndex = 0;
                }
            }
            ShowQuestion();
        }
        private void btnrandom_Click(object sender, EventArgs e)
        {
            ShowQuestion();

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
            if (stringbz != stringyour)
            {
                model.score = "0";
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
            //lblTitle.Text = currentRow["title"].ToString();
            //webBrowser1.Navigate(currentRow["title"].ToString().Trim());
            webBrowser1.DocumentText = ContentShow.GetTile(currentRow["title"].ToString(), ContentShow.ColorBrowser.针对普通题目);

            //  "<html><body style=\"background-color:rgb(249,249,249)\"><p>" + + "</p></html>";
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
            //webBrowser1.Navigate(currentRow["title"].ToString().Trim());
            //  webBrowser1.DocumentText = "<html><body style=\"background-color:rgb(249,249,249)\"><p>" + currentRow["title"].ToString() + "</p></html>";
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
            // lblTitle.Select(0, 0);
        }



        private void btnPrev_Click(object sender, EventArgs e)
        {
            ShowQuestionLast();
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
