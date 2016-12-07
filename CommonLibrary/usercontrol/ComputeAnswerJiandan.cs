using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountingApplication.usercontrol
{
    public partial class ComputeAnswerJiandan : UserControl
    {
        public CommonEnum.Questionnum num;
        public ComputeAnswerJiandan()
        {
            InitializeComponent();
        }
        public ComputeAnswerJiandan(CommonEnum.Questionnum num)
        {
            InitializeComponent();
            this.num = num;
        }
        private void txtJiandan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }  
        }
    }
}
