using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;
using AccountingApplication.usercontrol;

namespace AccountingApplication
{
    public partial class Formpd : BaseForm
    {
        private bool isErrorNote = false;
        public Formpd()
        {
            InitializeComponent();
            Init();
        }
        public Formpd(string where, bool iserror)
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
                pd dxt = new pd(tableAllQuestion, isErrorNote);
                panel.Controls.Clear();
                panel.Controls.Add(dxt);
                dxt.Dock = DockStyle.Fill;
            }
        }
        private DataTable GetAllSingleQuestion()
        {
            string sql = "select * from questionJudge ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += where;
            }
            return db.Select(sql);
        }
    }
}
