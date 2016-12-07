using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccountingApplication.usercontrol;
using CommonLibrary;
namespace AccountingApplication
{
    public partial class FormCompute : BaseForm
    {
        int currentIndex = -1;
        int maxIndex = 0;
        DataRow currentRow = null;
        public FormCompute()
        {
            InitializeComponent();
        }
        public FormCompute(string where)
        {
            this.where = where;
            InitializeComponent();
        }
        private DataTable GetAllSingleQuestion()
        {
            string sql = "select * from questionCompute ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += where;
            }
            return db.Select(sql);
        }
        private void RandomDataTable()
        {
            tableAllQuestion = tableAllQuestion.AsEnumerable().OrderBy(d => Guid.NewGuid()).CopyToDataTable();
        }
        private void Init()
        {
            tableAllQuestion = GetAllSingleQuestion();
            RandomDataTable();
            maxIndex = tableAllQuestion.Rows.Count - 1;
            if (!CommonIsReg.IsReg)
            {
                if (maxIndex > 0)
                {
                    maxIndex = 0;
                }
            }
            if (!IsExitData())
            {
                MessageBox.Show("当前没有计算分析题");
                return;
            }
        }

        void fuza_eventAddOrRemove(int index, CommonEnum.AddRemoveType type)
        {
            Control[] arr = flowLayoutPanel1.Controls.Find("ComputeAnswerFuza", false);
            if (type == CommonEnum.AddRemoveType.加)
            {
                foreach (Control item in arr)
                {
                    ComputeAnswerFuza fuza = item as ComputeAnswerFuza;
                    if (fuza.index == index + 1)
                    {
                        fuza.IsVisiable = true;
                        fuza.Show();

                    }
                }
            }
            else if (type == CommonEnum.AddRemoveType.减)
            {
                foreach (Control item in arr)
                {
                    if ((item as ComputeAnswerFuza).index == index)
                    {
                        (item as ComputeAnswerFuza).IsVisiable = false;
                        item.Hide();

                    }
                }
            }
        }
        private void CreateFuza(CommonEnum.Questionnum num, int startIndex)
        {
            for (int i = startIndex; i <= startIndex + 4; i++)
            {
                ComputeAnswerFuza fuza = new ComputeAnswerFuza(i, num);
                fuza.eventAddOrRemove += new ComputeAnswerFuza.AddOrRemoveDelegate(fuza_eventAddOrRemove);
                if (i == startIndex)
                {
                    fuza.lblTimuxuhao.Text = "(" + Convert.ToInt32(num) + ")";
                    fuza.btnremove.Enabled = false;
                    fuza.IsVisiable = true;
                }
                else
                {
                    fuza.Hide();
                    fuza.IsVisiable = false;
                }
                flowLayoutPanel1.Controls.Add(fuza);
            }
        }
        private void CreateJiandan(CommonEnum.Questionnum num)
        {
            ComputeAnswerJiandan jiandan = new ComputeAnswerJiandan(num);
            jiandan.lblTimuxuhao.Text = "(" + Convert.ToInt32(num) + ")";
            flowLayoutPanel1.Controls.Add(jiandan);
        }
        private void CreateControls(CommonEnum.Questionnum num, string answerType, int startIndex)
        {
            if (answerType == "复杂")
            {
                CreateFuza(num, startIndex);
            }
            else if (answerType == "简单")
            {
                CreateJiandan(num);
            }
        }

        private void btnjiexi_Click(object sender, EventArgs e)
        {
           
        }

        private void ShowNextQuestion()
        {
            currentIndex++;
            if (currentIndex > maxIndex)
            {
                MessageBox.Show("题目已做完", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentIndex--;
                return;
            }
            flowLayoutPanel1.Controls.Clear();
            currentRow = tableAllQuestion.Rows[currentIndex];
            pictureBoxTitle.ImageLocation = @"计算分析题/" + currentRow["title"].ToString().Trim();
            string answer1Type = currentRow["answer1Type"].ToString();
            string answer2Type = currentRow["answer2Type"].ToString();
            string answer3Type = currentRow["answer3Type"].ToString();
            string answer4Type = currentRow["answer4Type"].ToString();
            string answer5Type = currentRow["answer5Type"].ToString();
            CreateControls(CommonEnum.Questionnum.问题1, answer1Type, 1);
            CreateControls(CommonEnum.Questionnum.问题2, answer2Type, 6);
            CreateControls(CommonEnum.Questionnum.问题3, answer3Type, 11);
            CreateControls(CommonEnum.Questionnum.问题4, answer4Type, 16);
            CreateControls(CommonEnum.Questionnum.问题5, answer5Type, 21);
            lbltm.Text = "第" + (currentIndex + 1) + "题(共" + (maxIndex + 1) + "题）";
        }
        private void ShowPrevQuestion()
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                MessageBox.Show("已经是第一题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentIndex++;
                return;
            }
            flowLayoutPanel1.Controls.Clear();
            currentRow = tableAllQuestion.Rows[currentIndex];
            pictureBoxTitle.ImageLocation = @"计算分析题/" + currentRow["title"].ToString().Trim();
            string answer1Type = currentRow["answer1Type"].ToString();
            string answer2Type = currentRow["answer2Type"].ToString();
            string answer3Type = currentRow["answer3Type"].ToString();
            string answer4Type = currentRow["answer4Type"].ToString();
            string answer5Type = currentRow["answer5Type"].ToString();
            CreateControls(CommonEnum.Questionnum.问题1, answer1Type, 1);
            CreateControls(CommonEnum.Questionnum.问题2, answer2Type, 6);
            CreateControls(CommonEnum.Questionnum.问题3, answer3Type, 11);
            CreateControls(CommonEnum.Questionnum.问题4, answer4Type, 16);
            CreateControls(CommonEnum.Questionnum.问题5, answer5Type, 21);
            lbltm.Text = "第" + (currentIndex + 1) + "题(共" + (maxIndex + 1) + "题）";
        }
        private void btnprev_Click(object sender, EventArgs e)
        {
           
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
           
        }

        private void btnshouc_Click(object sender, EventArgs e)
        {

        }

        private void FormCompute_Load(object sender, EventArgs e)
        {
            Init();
            ShowNextQuestion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModelComputeJiexi jiexi = new ModelComputeJiexi();
            jiexi.biaozhundaan1 = currentRow["answer1"].ToString().Trim();
            jiexi.biaozhundaan2 = currentRow["answer2"].ToString().Trim();
            jiexi.biaozhundaan3 = currentRow["answer3"].ToString().Trim();
            jiexi.biaozhundaan4 = currentRow["answer4"].ToString().Trim();
            jiexi.biaozhundaan5 = currentRow["answer5"].ToString().Trim();
            jiexi.jiexi = currentRow["analysis"].ToString().Trim();
            Control[] arr = flowLayoutPanel1.Controls.Find("ComputeAnswerFuza", false);
            foreach (Control item in arr)
            {
                ComputeAnswerFuza fuza = item as ComputeAnswerFuza;
                if (fuza.IsVisiable == false)
                {
                    continue;
                }
                switch (fuza.num)
                {
                    case CommonEnum.Questionnum.问题1:
                        jiexi.answer1 += (fuza.cbbjd.SelectedItem == null ? "" : fuza.cbbjd.SelectedItem.ToString().Trim()) + "#" + fuza.txtKuaijikemu.Text.Trim() + "#" + fuza.txtNumber.Text.Trim() + "*";
                        break;
                    case CommonEnum.Questionnum.问题2:
                        jiexi.answer2 += (fuza.cbbjd.SelectedItem == null ? "" : fuza.cbbjd.SelectedItem.ToString().Trim()) + "#" + fuza.txtKuaijikemu.Text.Trim() + "#" + fuza.txtNumber.Text.Trim() + "*";
                        break;
                    case CommonEnum.Questionnum.问题3:
                        jiexi.answer3 += (fuza.cbbjd.SelectedItem == null ? "" : fuza.cbbjd.SelectedItem.ToString().Trim()) + "#" + fuza.txtKuaijikemu.Text.Trim() + "#" + fuza.txtNumber.Text.Trim() + "*";
                        break;
                    case CommonEnum.Questionnum.问题4:
                        jiexi.answer4 += (fuza.cbbjd.SelectedItem == null ? "" : fuza.cbbjd.SelectedItem.ToString().Trim()) + "#" + fuza.txtKuaijikemu.Text.Trim() + "#" + fuza.txtNumber.Text.Trim() + "*";
                        break;
                    case CommonEnum.Questionnum.问题5:
                        jiexi.answer5 += (fuza.cbbjd.SelectedItem == null ? "" : fuza.cbbjd.SelectedItem.ToString().Trim()) + "#" + fuza.txtKuaijikemu.Text.Trim() + "#" + fuza.txtNumber.Text.Trim() + "*";
                        break;
                }
            }

            arr = flowLayoutPanel1.Controls.Find("ComputeAnswerJiandan", false);
            foreach (Control item in arr)
            {
                ComputeAnswerJiandan fuza = item as ComputeAnswerJiandan;
                switch (fuza.num)
                {
                    case CommonEnum.Questionnum.问题1:
                        jiexi.answer1 += fuza.txtJiandan.Text.Trim();
                        break;
                    case CommonEnum.Questionnum.问题2:
                        jiexi.answer2 += fuza.txtJiandan.Text.Trim();
                        break;
                    case CommonEnum.Questionnum.问题3:
                        jiexi.answer3 += fuza.txtJiandan.Text.Trim();
                        break;
                    case CommonEnum.Questionnum.问题4:
                        jiexi.answer4 += fuza.txtJiandan.Text.Trim();
                        break;
                    case CommonEnum.Questionnum.问题5:
                        jiexi.answer5 += fuza.txtJiandan.Text.Trim();
                        break;
                }
            }
            jiexi.answer1 = jiexi.answer1.TrimEnd('*');
            jiexi.answer2 = jiexi.answer2.TrimEnd('*');
            jiexi.answer3 = jiexi.answer3.TrimEnd('*');
            jiexi.answer4 = jiexi.answer4.TrimEnd('*');
            jiexi.answer5 = jiexi.answer5.TrimEnd('*');
            ShowJiexi sjx = new ShowJiexi(jiexi);
            sjx.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowPrevQuestion();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowNextQuestion();
        }
    }
}
