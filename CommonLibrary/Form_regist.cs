using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;
using System.Diagnostics;
namespace AccountingApplication
{
    public partial class Form_regist : Form
    {
        EncryptClass reg = new EncryptClass();
        CheckMember check = new CheckMember();
        public Form_regist()
        {
            InitializeComponent();
        }

        private void Form_regist_Load(object sender, EventArgs e)
        {
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnActive.Enabled = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string reg = txtReg.Text.Trim();
            if (string.IsNullOrEmpty(reg))
            {
                MessageBox.Show("请输入激活码");

                return;
            }
            if (!CheckMember.Ping("60.205.26.33"))
            {
                MessageBox.Show("连接服务器失败，请检测网络或关闭防火墙");
                return;
            }
            CommonLibrary.CheckReg.WebServiceExamSoapClient c = new CommonLibrary.CheckReg.WebServiceExamSoapClient();
            string result = c.CheckReg(reg);
            WebServiceReturn wsr = JSONhelper.ConvertToObject<WebServiceReturn>(result);
            if (wsr.result == "success")
            {
                CheckMember cm = new CheckMember();
                cm.WriteReg(reg, wsr.ActivationTime);
                System.Windows.Forms.MessageBox.Show("激活成功！系统将重新启动", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            else
            {
                MessageBox.Show(wsr.msg);
            }
        }
       

        public class WebServiceReturn
        {
            public string result { get; set; }
            public string msg { get; set; }
            public DateTime ActivationTime { get; set; }
        }
        private void btnActive_Click(object sender, EventArgs e)
        {
            btnActive.Enabled = false;
            if (backgroundWorker1.IsBusy)
            {
                System.Windows.Forms.MessageBox.Show("当前线程正忙 请等待线程结束或重新打开程序");
                return;
            }
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://wpa.qq.com/msgrd?v=3&amp;uin=3225004487&amp;site=qq&amp;menu=yes");

        }


    }
}
