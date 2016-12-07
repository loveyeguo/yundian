using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;

namespace AccountingApplication
{
    public partial class FormHaotsc : Form
    {
        SQLiteHelper db = new SQLiteHelper("error.dll");
        public FormHaotsc()
        {
            InitializeComponent();
        }

        void thisFormClosed(object sender, FormClosedEventArgs e)
        {
            BindData();
            this.Show();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            DataTable table = db.Select("select questionID from goodTable where subject='" + Subject.SName + "' and questionType='questionSingle'");
            if (table == null || table.Rows.Count == 0)
            {
                MessageBox.Show("没有题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string where = string.Empty;
            foreach (DataRow item in table.Rows)
            {
                where += item["questionID"] + ",";
            }
            where = where.TrimEnd(',');
            this.Hide();
            Formdxt dxt = new Formdxt(" where KeyId in(" + where + ")", false);
            if (dxt.IsExitData())
            {
                dxt.FormClosed += new FormClosedEventHandler(thisFormClosed);
                dxt.Show();
            }
            else
            {
                MessageBox.Show("没有数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Show();
            }
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            DataTable table = db.Select("select questionID from goodTable where subject='" + Subject.SName + "' and questionType='questionMultiple'");
            if (table == null || table.Rows.Count == 0)
            {
                MessageBox.Show("没有题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string where = string.Empty;
            foreach (DataRow item in table.Rows)
            {
                where += item["questionID"] + ",";
            }
            where = where.TrimEnd(',');
            this.Hide();
            Formdxts dxt = new Formdxts(" where KeyId in(" + where + ")", false);
            if (dxt.IsExitData())
            {
                dxt.FormClosed += new FormClosedEventHandler(thisFormClosed);
                dxt.Show();
            }
            else
            {
                MessageBox.Show("没有数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Show();
            }
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            DataTable table = db.Select("select questionID from goodTable where subject='" + Subject.SName + "' and questionType='questionJudge'");
            if (table == null || table.Rows.Count == 0)
            {
                MessageBox.Show("没有题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string where = string.Empty;
            foreach (DataRow item in table.Rows)
            {
                where += item["questionID"] + ",";
            }
            where = where.TrimEnd(',');
            this.Hide();
            Formpd dxt = new Formpd(" where KeyId in(" + where + ")",false);
            if (dxt.IsExitData())
            {
                dxt.FormClosed += new FormClosedEventHandler(thisFormClosed);
                dxt.Show();
            }
            else
            {
                MessageBox.Show("没有数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Show();
            }
        }

        private void FormHaotsc_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            label_dx.Text = "共收录 " + db.ExecuteScalar("select count(*) from goodTable where subject='" + Subject.SName + "' and questionType='questionSingle'").ToString() + " 题";
            label_duox.Text = "共收录 " + db.ExecuteScalar("select count(*) from goodTable where subject='" + Subject.SName + "' and questionType='questionMultiple'").ToString() + " 题";
            label_pd.Text = "共收录 " + db.ExecuteScalar("select count(*) from goodTable where subject='" + Subject.SName + "' and questionType='questionJudge'").ToString() + " 题";
        }
    }
}
