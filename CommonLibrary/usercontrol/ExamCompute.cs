using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccountingApplication;
using AccountingApplication.usercontrol;

namespace CommonLibrary.usercontrol
{
    public partial class ExamCompute : BaseExamForm
    {
        DataRow question = null;
        public ExamCompute()
        {
            InitializeComponent();
        }
        public ExamCompute(DataRow row)
        {
            InitializeComponent();  
            this.question = row;
            ShowQuestion();
        }
        public void radioBtn_CheckedChange(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }
            answer = (((RadioButton)sender).Text.ToString().Trim());
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

        private void ShowQuestion()
        {
            if (question==null)
            {
                MessageBox.Show("没有题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            flowLayoutPanel1.Controls.Clear();
            pictureBoxTitle.ImageLocation = @"计算分析题/" + question["title"].ToString().Trim();
            string answer1Type = question["answer1Type"].ToString().Trim();
            string answer2Type = question["answer2Type"].ToString().Trim();
            string answer3Type = question["answer3Type"].ToString().Trim();
            string answer4Type = question["answer4Type"].ToString().Trim();
            string answer5Type = question["answer5Type"].ToString().Trim();
            CreateControls(CommonEnum.Questionnum.问题1, answer1Type, 1);
            CreateControls(CommonEnum.Questionnum.问题2, answer2Type, 6);
            CreateControls(CommonEnum.Questionnum.问题3, answer3Type, 11);
            CreateControls(CommonEnum.Questionnum.问题4, answer4Type, 16);
            CreateControls(CommonEnum.Questionnum.问题5, answer5Type, 21);
        }

    }
}
