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
    public partial class Formdxt : BaseForm
    {
        private bool isErrorNote = false;
        public Formdxt()
        {
            InitializeComponent();
            Init();
        }
        public Formdxt(string where, bool iserror)
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
                dxt dxt = new dxt(tableAllQuestion,isErrorNote);
                paneldxt.Controls.Clear();
                paneldxt.Controls.Add(dxt);
                dxt.Dock = DockStyle.Fill;
            }
        }
        private DataTable GetAllSingleQuestion()
        {
            string sql = "select * from questionSingle ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += where;
            }
            return db.Select(sql);
        }

        private void Formdxt_Load(object sender, EventArgs e)
        {

        }

    }
}
