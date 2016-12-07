using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;

namespace AccountingApplication.usercontrol
{
    public partial class ExamAnli : BaseExamForm
    {
        DataRow question = null;
        public ExamAnli()
        {
            InitializeComponent();
        }
        public ExamAnli(DataRow row)
        {
            InitializeComponent();
            this.question = row;
            BindRadioClick();
            ShowQuestion();
        }
        private void BindRadioClick()
        {
            cba.Click += new EventHandler(radioBtn_CheckedChange);
            cbb.Click += new EventHandler(radioBtn_CheckedChange);
            cbc.Click += new EventHandler(radioBtn_CheckedChange);
            cbd.Click += new EventHandler(radioBtn_CheckedChange);
        }
        public void radioBtn_CheckedChange(object sender, EventArgs e)
        {
            answer = "";
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
                        answer += (ck.Text);
                    }
                }
            }
        }
        private void ShowQuestion()
        {
            if (question == null)
            {
                MessageBox.Show("此索引没有题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //lblTitle.Text = question["title"].ToString();
         //   webBrowser1.DocumentText = "<html><body style=\"background-color:rgb(221, 241, 250)\"><p>" + question["title"].ToString() + "</p></html>";
            webBrowser1.DocumentText = ContentShow.GetTile(question["title"].ToString(), ContentShow.ColorBrowser.针对考试题目);
            lbla.Text = question["a"].ToString();
            lblb.Text = question["b"].ToString();
            lblc.Text = question["c"].ToString();
            lbld.Text = question["d"].ToString();
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
