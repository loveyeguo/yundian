using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccountingApplication.model;
using CommonLibrary;

namespace AccountingApplication.showform
{
    public partial class Formdxdxpd : Form
    {
        Modeldajx model = null;
        public Formdxdxpd(Modeldajx model)
        {
            this.model = model;
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            btdf.Text = model.score;
            bzda.Text = model.bzAnswer.ToUpper();
            ndda.Text = model.yourAnswer.ToUpper();
          //  pfjx.Text = "  " + model.analysis;
            webBrowser1.DocumentText = ContentShow.GetTile(model.analysis, ContentShow.ColorBrowser.针对考试题目);
            if (string.IsNullOrEmpty(model.score) || model.score == "0")
            {
                this.pictureBoxAnswer.ImageLocation = @"image/error.png";
            }
            else
            {
                this.pictureBoxAnswer.ImageLocation = @"image/right.png";
            }
        }

        private void Formdxdxpd_Load(object sender, EventArgs e)
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
