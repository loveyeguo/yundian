using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountingApplication
{
    public partial class FormComputeTree : Form
    {
        public delegate void SetKuaijikemu(string value);
        public SetKuaijikemu setValueHander;
        public  string select = string.Empty;
        public FormComputeTree()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.select))
            {
                MessageBox.Show("请选择科目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (setValueHander != null)
            {
                setValueHander(select);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag != "根节点")
            {
                this.select = treeView1.SelectedNode.Text;
            }
        }
    }
}
