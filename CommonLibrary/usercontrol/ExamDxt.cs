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
    public partial class ExamDxt : BaseExamForm
    {
        DataRow question = null;

        public ExamDxt()
        {
            InitializeComponent();
        }
        public ExamDxt(DataRow row)
        {
            InitializeComponent();  
            this.question = row;
            BindRadioClick();
            ShowQuestion();
        }
        private void BindRadioClick()
        {
            rbta.Click += new EventHandler(radioBtn_CheckedChange);
            rbtb.Click += new EventHandler(radioBtn_CheckedChange);
            rbtc.Click += new EventHandler(radioBtn_CheckedChange);
            rbtd.Click += new EventHandler(radioBtn_CheckedChange);
        }
        public void radioBtn_CheckedChange(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }
            answer = (((RadioButton)sender).Text.ToString().Trim());
        }
        private void ShowQuestion()
        {
            if (question == null)
            {
                MessageBox.Show("此索引没有题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
         //   lblTitle.Text = question["title"].ToString();
            webBrowser1.DocumentText = ContentShow.GetTile(question["title"].ToString(), ContentShow.ColorBrowser.针对考试题目);
            lbla.Text = question["a"].ToString();
            lblb.Text = question["b"].ToString();
            lblc.Text = question["c"].ToString();
            lbld.Text = question["d"].ToString();
        }

        private void ExamDxt_Load(object sender, EventArgs e)
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
