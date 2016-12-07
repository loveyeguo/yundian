using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using CommonLibrary;

namespace AccountingApplication
{
    public class BaseForm : Form
    {
        protected SQLiteHelper db = new SQLiteHelper();
        protected DataTable tableAllQuestion = null;
        protected string where = string.Empty;

        public bool IsExitData()
        {
            if (tableAllQuestion == null || tableAllQuestion.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }
    }
}
