using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CommonLibrary
{
    public partial class FormSwt : Form
    {
        public FormSwt()
        {
            InitializeComponent();
        }
        string selectindex = "1";
        private void VerifySelect()
        {
            if (radioButton1.Checked)
            {
                selectindex = "1";
            }
            if (radioButton2.Checked)
            {
                selectindex = "2";
            }
            if (radioButton3.Checked)
            {
                selectindex = "3";
            }
            if (radioButton4.Checked)
            {
                selectindex = "4";
            }
           
            AppconfigOperate operate = new AppconfigOperate();
            operate.SetValue(Application.StartupPath + "/mbdatafiles/WindowsApplication.exe.config", "Paper", selectindex);
        }
        /// <summary>
        /// 进入测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            VerifySelect();
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.WorkingDirectory = Application.StartupPath + "\\mbdatafiles\\";    //要启动程序路径
            p.StartInfo.FileName = "WindowsApplication.exe";//需要启动的程序名   
            p.StartInfo.Arguments = "kjsw";
            p.Start();
            this.WindowState = FormWindowState.Minimized;
        }


    }
}
