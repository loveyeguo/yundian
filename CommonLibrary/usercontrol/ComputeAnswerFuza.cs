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
    public partial class ComputeAnswerFuza : UserControl
    {
        public delegate void AddOrRemoveDelegate(int index, CommonEnum.AddRemoveType type);
        public event AddOrRemoveDelegate eventAddOrRemove;
        private string title = string.Empty;
        public int index;
        public CommonEnum.Questionnum num;
        /// <summary>
        /// 控件是否显示
        /// </summary>
        public bool IsVisiable = false;
        public ComputeAnswerFuza()
        {
            InitializeComponent();
        }
        public ComputeAnswerFuza(int i, CommonEnum.Questionnum num)
        {
            InitializeComponent();
            this.index = i;
            this.num = num;
        }
        private void btnOpenKuaiji_Click(object sender, EventArgs e)
        {
            FormComputeTree tree = new FormComputeTree();
            tree.setValueHander = SetKuaijikumu;
            tree.ShowDialog();
        }
        private void SetKuaijikumu(string str)
        {
            this.txtKuaijikemu.Text = str;
        }
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (eventAddOrRemove != null)
            {
                eventAddOrRemove(index, CommonEnum.AddRemoveType.加);
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            if (eventAddOrRemove != null)
            {
                eventAddOrRemove(index, CommonEnum.AddRemoveType.减);
            }
        }
    }
}
