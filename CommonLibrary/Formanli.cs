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
    public partial class Formanli : BaseForm
    {
        public Formanli()
        {
            InitializeComponent();
            Init();
        }
        public Formanli(string where)
        {
            this.where = where;
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            tableAllQuestion = GetAllSingleQuestion();
            if (IsExitData())
            {
                anli dxt = new anli(tableAllQuestion);
                panel.Controls.Clear();
                panel.Controls.Add(dxt);
                dxt.Dock = DockStyle.Fill;
            }
        }
        private DataTable GetAllSingleQuestion()
        {
            string sql = "select * from questionAnalyse ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += where;
            }
            return db.Select(sql);
        }
    }
}
