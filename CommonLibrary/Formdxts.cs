using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AccountingApplication.usercontrol;
using CommonLibrary;

namespace AccountingApplication
{
    public partial class Formdxts : BaseForm
    {
        private bool isErrorNote = false;
        public Formdxts()
        {
            InitializeComponent();
            Init();
        }
        public Formdxts(string where, bool iserror)
        {
            this.where = where;
            this.isErrorNote = iserror;
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            tableAllQuestion = GetAllSingleQuestion();
            if (IsExitData())
            {
                dxts dxt = new dxts(tableAllQuestion, isErrorNote);
                panel.Controls.Clear();
                panel.Controls.Add(dxt);
                dxt.Dock = DockStyle.Fill;
            }
        }
        private DataTable GetAllSingleQuestion()
        {
            string sql = "select * from questionMultiple ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += where;
            }
            return db.Select(sql);
        }
    }
}
