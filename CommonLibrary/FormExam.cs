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
using AccountingApplication.model;
using AccountingApplication.showform;
using System.Diagnostics;
using AccountingApplication.Bll;
using CommonLibrary.usercontrol;

namespace AccountingApplication
{
    public partial class FormExam : Form
    {
        SQLiteHelper db = new SQLiteHelper();
        /// <summary>
        /// 当前题目类型
        /// </summary>
        public enum questionType
        {
            单选题,
            多选题,
            判断题,
            计算分析题,
            案例分析题
        }
        private static int remainSeconds = 3600;
        DataTable tableDxt = new DataTable();
        DataTable tableDxts = new DataTable();
        DataTable tablePdt = new DataTable();
        DataTable tableCompute = new DataTable();
        DataTable tableAnli = new DataTable();
        string paperName = string.Empty;
        int sumDxt, sumDxts, sumPdt, sumCompute, sumAnli = 0;
        /// <summary>
        /// 当前题目索引 总共62(电算化为30,财经法规为70)
        /// </summary>
        int currentIndex = 1;
        /// <summary>
        /// 上一道题目索引
        /// </summary>
        int lastIndex = 0;
        /// <summary>
        /// 标记题目索引
        /// </summary>
        int biaojiIndex = 0;
        /// <summary>
        /// 取消标记题目索引
        /// </summary>
        int quxiaobiaojiIndex = 0;
        /// <summary>
        /// 当前数据行
        /// </summary>
        DataRow currentRow = null;
        /// <summary>
        /// 当前题目类型
        /// </summary>
        questionType currentType = 0;
        /// <summary>
        /// 记录考生答案
        /// </summary>
        string[] answers = new string[71];
        /// <summary>
        /// 记录当前答案
        /// </summary>
        string currentAnswer = string.Empty;
        int paperIndex = 0;
        public FormExam()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
        }
        public FormExam(string paperName)
        {
            InitializeComponent();
            this.paperName = paperName;
        }
        public FormExam(string paperName,int paperIndex)
        {
            InitializeComponent();
            this.paperName = paperName;
            this.paperIndex = paperIndex;
        }

        private void timerExam_Tick(object sender, EventArgs e)
        {
            int minute;   // 当前的分钟
            int second;   // 秒

            // 如果还有剩余时间，就显示剩余的分钟和秒数
            if (remainSeconds > 0)
            {
                remainSeconds--;
                minute = remainSeconds / 60;
                second = remainSeconds % 60;
                lblTimer.Text = string.Format("{0:00}:{1:00}", minute, second);
            }
            // 否则，就提示交卷
            else
            {
                timerExam.Stop();
                JiaoJuan();
            }
        }

        private void InitAllQuestion()
        {
            tableDxt = db.Select("select * from questionSingle where subject='" + Subject.SName + "' and paper='" + this.paperName + "'  limit 20");
            tableDxts = db.Select("select  * from questionMultiple where subject='" + Subject.SName + "' and paper='" + this.paperName + "'  limit 20");
            tablePdt = db.Select("select  * from questionJudge where subject='" + Subject.SName + "' and paper='" + this.paperName + "'  limit 20");
            tableCompute = db.Select("select  * from questionCompute where subject='" + Subject.SName + "' and paper='" + this.paperName + "'  limit 20");
            tableAnli = db.Select("select  * from questionAnalyse where subject='" + Subject.SName + "' and paper='" + this.paperName + "'  limit 20");
            sumDxt = tableDxt.Rows.Count;
            sumDxts = tableDxts.Rows.Count;
            sumPdt = tablePdt.Rows.Count;
            sumCompute = tableCompute.Rows.Count;
            sumAnli = tableAnli.Rows.Count;
        }

        private void FormExam_Load(object sender, EventArgs e)
        {
            remainSeconds = 3600;
            btnJiexi.Enabled = false;
            timerExam.Start();
            InitAllQuestion();
            ShowQuestion();
            BindBtnClick();
            label_subject.Text = Subject.SName;
            switch (label_subject.Text)
            {
                case "会计电算化":
                    showButtonForDiansh();
                    break;
                case "财经法规与会计职业道德":
                    showButtonForCaijing();
                    break;
                case "会计基础":
                    showButtonForKuaijijichu();
                    break;
            }
        }

        /// <summary>
        /// 当前为会计基础 显示按钮处理
        /// </summary>
        private void showButtonForKuaijijichu()
        {
            label_ttitle.Text = "计算分析题";
            button61.Visible = false;
            foreach (Control ctr in this.panel1.Controls)
            {
                if (ctr is Button && ctr.Tag != null)
                {
                    int intTag = Convert.ToInt32(ctr.Tag);
                    if (intTag >= 63 && intTag <= 70)
                    {
                        ctr.Visible = false;
                    }
                }
            }
        }
        /// <summary>
        /// 当前为财经法规 显示按钮处理
        /// </summary>
        private void showButtonForCaijing()
        {
            label_ttitle.Text = "案例分析题";
            button61.Visible = false;
        }
        /// <summary>
        /// 当前为电算化 显示按钮处理
        /// </summary>
        private void showButtonForDiansh()
        {
            foreach (Control ctr in this.panel1.Controls)
            {
                if (ctr is Button && ctr.Tag != null)
                {
                    int intTag = Convert.ToInt32(ctr.Tag);
                    if (intTag >= 63 && intTag <= 70)
                    {
                        ctr.Visible = false;
                    }
                }
            }
            label_ttitle.Text = "实务操作题";
            button65.Visible = false;
            button61.Visible = true;

            button4.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button43.Visible = false;

            button44.Visible = false;
            button45.Visible = false;
            button46.Visible = false;
            button47.Visible = false;
            button49.Visible = false;
            //多选题
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;

            button20.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            button26.Visible = false;
            //判断题
            button48.Visible = false;
            button50.Visible = false;
            button51.Visible = false;
            button52.Visible = false;
            button40.Visible = false;

            button35.Visible = false;
            button36.Visible = false;
            button37.Visible = false;
            button38.Visible = false;
            button39.Visible = false;

            button4.Dispose();
            button11.Dispose();
            button12.Dispose();
            button13.Dispose();
            button43.Dispose();

            button44.Dispose();
            button45.Dispose();
            button46.Dispose();
            button47.Dispose();
            button49.Dispose();
            //多选题
            button15.Dispose();
            button16.Dispose();
            button17.Dispose();
            button18.Dispose();
            button19.Dispose();

            button20.Dispose();
            button23.Dispose();
            button24.Dispose();
            button25.Dispose();
            button26.Dispose();
            //判断题
            button48.Dispose();
            button50.Dispose();
            button51.Dispose();
            button52.Dispose();
            button40.Dispose();

            button35.Dispose();
            button36.Dispose();
            button37.Dispose();
            button38.Dispose();
            button39.Dispose();

            //会计电算化 则需要改变按钮的tag值
            foreach (Control ctr in this.panel1.Controls)
            {
                if (ctr is Button && ctr.Tag != null)
                {
                    int intTag = Convert.ToInt32(ctr.Tag);
                    if (intTag >= 21 && intTag <= 40)
                    {
                        ctr.Tag = Convert.ToInt32(ctr.Tag) - 10;
                    }
                    else if (intTag >= 41 && intTag <= 60)
                    {
                        ctr.Tag = Convert.ToInt32(ctr.Tag) - 20;
                    }
                }
            }

        }
        private void RecordAnswer()
        {
            answers[currentIndex] = currentAnswer;
        }
        private void ShowAnswer()
        {
            string answer = answers[currentIndex];
            if (currentType == questionType.单选题)
            {
                ExamDxt control = panelExam.Controls.Find("ExamDxt", false)[0] as ExamDxt;
                control.answer = answer;
                switch (answer)
                {
                    case "A":
                        control.rbta.Checked = true;
                        break;
                    case "B":
                        control.rbtb.Checked = true;
                        break;
                    case "C":
                        control.rbtc.Checked = true;
                        break;
                    case "D":
                        control.rbtd.Checked = true;
                        break;
                    default:
                        control.rbta.Checked = false;
                        control.rbtb.Checked = false;
                        control.rbtc.Checked = false;
                        control.rbtd.Checked = false;
                        break;
                }
            }
            else if (currentType == questionType.多选题)
            {
                ExamDxts control = panelExam.Controls.Find("ExamDxts", false)[0] as ExamDxts;
                control.answer = answer;
                if (string.IsNullOrEmpty(answer))
                {
                    return;
                }
                char[] c = answer.ToCharArray();
                foreach (char item in c)
                {
                    if (item.ToString().ToLower() == "a")
                    {
                        control.cba.Checked = true;
                    }
                    else if (item.ToString().ToLower() == "b")
                    {
                        control.cbb.Checked = true;
                    }
                    else if (item.ToString().ToLower() == "c")
                    {
                        control.cbc.Checked = true;
                    }
                    else if (item.ToString().ToLower() == "d")
                    {
                        control.cbd.Checked = true;
                    }
                }
            }
            else if (currentType == questionType.案例分析题)
            {
                ExamAnli control = panelExam.Controls.Find("ExamAnli", false)[0] as ExamAnli;
                control.answer = answer;
                if (string.IsNullOrEmpty(answer))
                {
                    return;
                }
                char[] c = answer.ToCharArray();
                foreach (char item in c)
                {
                    if (item.ToString().ToLower() == "a")
                    {
                        control.cba.Checked = true;
                    }
                    else if (item.ToString().ToLower() == "b")
                    {
                        control.cbb.Checked = true;
                    }
                    else if (item.ToString().ToLower() == "c")
                    {
                        control.cbc.Checked = true;
                    }
                    else if (item.ToString().ToLower() == "d")
                    {
                        control.cbd.Checked = true;
                    }
                }
            }
            else if (currentType == questionType.判断题)
            {
                ExamPd control = panelExam.Controls.Find("ExamPd", false)[0] as ExamPd;
                control.answer = answer;
                if (string.IsNullOrEmpty(answer))
                {
                    return;
                }
                if (answer == "正确")
                {
                    control.rbttrue.Checked = true;
                }
                else if (answer.ToLower() == "错误")
                {
                    control.rbtfalse.Checked = true;
                }
            }
            else if (currentType == questionType.计算分析题)
            {
                if (string.IsNullOrEmpty(answer))
                {
                    return;
                }
                string[] list = answer.Split('|');
                string answer1 = list[0];
                string answer2 = list[1];
                string answer3 = list[2];
                string answer4 = list[3];
                string answer5 = list[4];
                BindComputeOldAnswer(answer1, CommonEnum.Questionnum.问题1);
                BindComputeOldAnswer(answer2, CommonEnum.Questionnum.问题2);
                BindComputeOldAnswer(answer3, CommonEnum.Questionnum.问题3);
                BindComputeOldAnswer(answer4, CommonEnum.Questionnum.问题4);
                BindComputeOldAnswer(answer5, CommonEnum.Questionnum.问题5);
            }
        }
        /// <summary>
        /// 将答案绑定到计算分析题
        /// </summary>
        private void BindComputeOldAnswer(string answer, CommonEnum.Questionnum num)
        {
            ExamCompute control = panelExam.Controls.Find("ExamCompute", false)[0] as ExamCompute;
            List<ComputeAnswerFuza> listfuza = GetControlByName<ComputeAnswerFuza>(control.flowLayoutPanel1, "ComputeAnswerFuza", false);
            List<ComputeAnswerJiandan> listjiandan = GetControlByName<ComputeAnswerJiandan>(control.flowLayoutPanel1, "ComputeAnswerJiandan", false);
            //等于-1则为简单题目 否则为复杂题目
            if (answer.IndexOf('#') == -1)
            {
                ComputeAnswerJiandan jiandan = listjiandan.First(x => x.num == num);
                jiandan.txtJiandan.Text = answer;
            }
            else
            {
                string[] str = answer.Split('*');
                List<ComputeAnswerFuza> listCurrent = listfuza.FindAll(x => x.num == num);
                for (int i = 0; i < str.Length; i++)
                {
                    string[] lineAnswer = str[i].Split('#');
                    listCurrent[i].cbbjd.SelectedItem = lineAnswer[0];
                    listCurrent[i].txtKuaijikemu.Text = lineAnswer[1];
                    listCurrent[i].txtNumber.Text = lineAnswer[2];
                }
                int length = str.Length;
                int startIndex = 0;
                switch (num)
                {
                    case CommonEnum.Questionnum.问题1:
                        startIndex = 1;
                        break;
                    case CommonEnum.Questionnum.问题2:
                        startIndex = 6;
                        break;
                    case CommonEnum.Questionnum.问题3:
                        startIndex = 11;
                        break;
                    case CommonEnum.Questionnum.问题4:
                        startIndex = 16;
                        break;
                    case CommonEnum.Questionnum.问题5:
                        startIndex = 21;
                        break;
                }
                for (int i = startIndex; i < length + startIndex; i++)
                {
                    listfuza.Find(x => x.index == i).Show();
                    listfuza.Find(x => x.index == i).IsVisiable = true;
                }
            }
        }
        private List<T> GetControlByName<T>(
      Control controlToSearch, string nameOfControlsToFind, bool searchDescendants)
      where T : class
        {
            List<T> result;
            result = new List<T>();
            foreach (Control c in controlToSearch.Controls)
            {
                if (c.Name == nameOfControlsToFind && c.GetType() == typeof(T))
                {
                    result.Add(c as T);
                }
                if (searchDescendants)
                {
                    result.AddRange(GetControlByName<T>(c, nameOfControlsToFind, true));
                }
            }
            return result;
        }
        private void ShowQuestion()
        {
            ShowButtonCss();
            lblInfo.Text = "第" + currentIndex + "题";
            if (Subject.SName == "会计电算化")
            {
                //单选题
                if (currentIndex >= 1 && currentIndex <= 10)
                {
                    currentType = questionType.单选题;
                    if (currentIndex > sumDxt)
                    {
                        MessageBox.Show("此索引没有题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    currentRow = tableDxt.Rows[currentIndex - 1];
                    ExamDxt dxt = new ExamDxt(currentRow);
                    panelExam.Controls.Clear();
                    panelExam.Controls.Add(dxt);
                    dxt.Dock = DockStyle.Fill;
                }
                //多选题
                else if (currentIndex > 10 && currentIndex <= 20)
                {
                    currentType = questionType.多选题;
                    if (currentIndex > sumDxts + 10)
                    {
                        MessageBox.Show("此索引没有题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    currentRow = tableDxts.Rows[currentIndex - 1 - 10];
                    ExamDxts dxt = new ExamDxts(currentRow);
                    panelExam.Controls.Clear();
                    panelExam.Controls.Add(dxt);
                    dxt.Dock = DockStyle.Fill;
                }
                else if (currentIndex > 20 && currentIndex <= 30)
                {
                    currentType = questionType.判断题;
                    if (currentIndex > sumPdt + 20)
                    {
                        MessageBox.Show("此索引没有题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    currentRow = tablePdt.Rows[currentIndex - 1 - 20];
                    ExamPd dxt = new ExamPd(currentRow);
                    panelExam.Controls.Clear();
                    panelExam.Controls.Add(dxt);
                    dxt.Dock = DockStyle.Fill;
                }
            }
            else
            {
                //单选题
                if (currentIndex >= 1 && currentIndex <= 20)
                {
                    currentType = questionType.单选题;
                    if (currentIndex > sumDxt)
                    {
                        MessageBox.Show("此索引没有题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    currentRow = tableDxt.Rows[currentIndex - 1];
                    ExamDxt dxt = new ExamDxt(currentRow);
                    panelExam.Controls.Clear();
                    panelExam.Controls.Add(dxt);
                    dxt.Dock = DockStyle.Fill;
                }
                //多选题
                else if (currentIndex > 20 && currentIndex <= 40)
                {
                    currentType = questionType.多选题;
                    if (currentIndex > sumDxts + 20)
                    {
                        MessageBox.Show("此索引没有题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    currentRow = tableDxts.Rows[currentIndex - 1 - 20];
                    ExamDxts dxt = new ExamDxts(currentRow);
                    panelExam.Controls.Clear();
                    panelExam.Controls.Add(dxt);
                    dxt.Dock = DockStyle.Fill;
                }
                else if (currentIndex > 40 && currentIndex <= 60)
                {
                    currentType = questionType.判断题;
                    if (currentIndex > sumPdt + 40)
                    {
                        MessageBox.Show("此索引没有题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    currentRow = tablePdt.Rows[currentIndex - 1 - 40];
                    ExamPd dxt = new ExamPd(currentRow);
                    panelExam.Controls.Clear();
                    panelExam.Controls.Add(dxt);
                    dxt.Dock = DockStyle.Fill;
                }
                else if (currentIndex > 60 && currentIndex <= 70)
                {
                    if (Subject.SName == "财经法规与会计职业道德")
                    {
                        //案例分析题
                        currentType = questionType.案例分析题;
                        if (currentIndex > sumAnli + 60)
                        {
                            MessageBox.Show("此索引没有题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        currentRow = tableAnli.Rows[currentIndex - 1 - 60];
                        ExamAnli dxt = new ExamAnli(currentRow);
                        panelExam.Controls.Clear();
                        panelExam.Controls.Add(dxt);
                        dxt.Dock = DockStyle.Fill;
                    }
                    else if (Subject.SName == "会计基础")
                    {
                        currentType = questionType.计算分析题;
                        if (currentIndex > sumCompute + 60)
                        {
                            MessageBox.Show("此索引没有题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        currentRow = tableCompute.Rows[currentIndex - 1 - 60];
                        ExamCompute ec = new ExamCompute(currentRow);
                        panelExam.Controls.Clear();
                        panelExam.Controls.Add(ec);
                        ec.Dock = DockStyle.Fill;

                    }

                }
            }
            if (currentType == questionType.单选题)
            {
                lbltm.Text = "单选题";
            }
            else if (currentType == questionType.多选题)
            {
                lbltm.Text = "多选题";
            }
            else if (currentType == questionType.判断题)
            {
                lbltm.Text = "判断题";
            }
            else if (currentType == questionType.案例分析题)
            {
                lbltm.Text = "案例分析题";
            }
            else if (currentType == questionType.计算分析题)
            {
                lbltm.Text = "计算分析题";
            }
        }
        //private void btnFirst_Click(object sender, EventArgs e)
        //{
        //    RecordCurrentAnswer();
        //    RecordAnswer();
        //    currentIndex = 1;
        //    ShowQuestion();
        //    ShowAnswer();
        //}

        private void btnPre_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        //private void btnLast_Click(object sender, EventArgs e)
        //{
        //    RecordCurrentAnswer();
        //    RecordAnswer();
        //    currentIndex = 62;
        //    ShowQuestion();
        //    ShowAnswer();
        //}
        private void RecordCurrentAnswer()
        {
            if (currentType == questionType.单选题)
            {
                ExamDxt control = panelExam.Controls.Find("ExamDxt", false)[0] as ExamDxt;
                currentAnswer = control.answer;
            }
            else if (currentType == questionType.多选题)
            {
                ExamDxts control = panelExam.Controls.Find("ExamDxts", false)[0] as ExamDxts;
                currentAnswer = control.answer;
            }
            else if (currentType == questionType.案例分析题)
            {
                ExamAnli control = panelExam.Controls.Find("ExamAnli", false)[0] as ExamAnli;
                currentAnswer = control.answer;
            }
            else if (currentType == questionType.判断题)
            {
                ExamPd control = panelExam.Controls.Find("ExamPd", false)[0] as ExamPd;
                currentAnswer = control.answer;
            }
            else if (currentType == questionType.计算分析题)
            {
                ExamCompute control = panelExam.Controls.Find("ExamCompute", false)[0] as ExamCompute;
                Control[] arr = control.flowLayoutPanel1.Controls.Find("ComputeAnswerFuza", false);
                ModelComputeJiexi jiexi = new ModelComputeJiexi();
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

                arr = control.flowLayoutPanel1.Controls.Find("ComputeAnswerJiandan", false);
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
                currentAnswer = jiexi.answer1 + "|" + jiexi.answer2 + "|" + jiexi.answer3 + "|" + jiexi.answer4 + "|" + jiexi.answer5;
            }
        }
        private void btnJiexi_Click(object sender, EventArgs e)
        {
            RecordCurrentAnswer();
            if (currentType == questionType.计算分析题)
            {
                ModelComputeJiexi jiexi = new ModelComputeJiexi();
                string[] str = currentAnswer.Split('|');
                jiexi.answer1 = str[0].ToString();
                jiexi.answer2 = str[1].ToString();
                jiexi.answer3 = str[2].ToString();
                jiexi.answer4 = str[3].ToString();
                jiexi.answer5 = str[4].ToString();
                jiexi.jiexi = currentRow["analysis"].ToString();
                jiexi.biaozhundaan1 = currentRow["answer1"].ToString().Trim();
                jiexi.biaozhundaan2 = currentRow["answer2"].ToString().Trim();
                jiexi.biaozhundaan3 = currentRow["answer3"].ToString().Trim();
                jiexi.biaozhundaan4 = currentRow["answer4"].ToString().Trim();
                jiexi.biaozhundaan5 = currentRow["answer5"].ToString().Trim();
                ShowJiexi sj = new ShowJiexi(jiexi);
                sj.ShowDialog();
            }
            else
            {
                Modeldajx model = new Modeldajx();
                model.bzAnswer = currentRow["answer"].ToString().Trim();
                model.analysis = currentRow["analysis"].ToString();
                if (currentAnswer == null)
                {
                    currentAnswer = "无";
                }
                if (currentType == questionType.单选题 || currentType == questionType.多选题 || currentType == questionType.案例分析题)
                {
                    char[] bz = model.bzAnswer.ToCharArray();
                    char[] your = currentAnswer.Trim().ToCharArray();
                    Array.Sort(bz);
                    Array.Sort(your);
                    string stringbz = new string(bz);
                    string stringyour = new string(your);
                    model.yourAnswer = stringyour;
                    if (stringbz.Trim().ToLower() != stringyour.Trim().ToLower())
                    {
                        model.score = "0";
                    }
                    else
                    {
                        model.score = currentRow["score"].ToString();
                    }
                }
                else if (currentType == questionType.判断题)
                {
                    if (string.IsNullOrEmpty(currentAnswer))
                    {
                        currentAnswer = "无";
                    }
                    if (currentAnswer.Trim() == "正确")
                    {
                        currentAnswer = "对";
                    }
                    else if (currentAnswer.Trim() == "错误")
                    {
                        currentAnswer = "错";
                    }
                    model.yourAnswer = currentAnswer;
                    if (currentAnswer.ToLower() != model.bzAnswer.ToLower())
                    {
                        model.score = "0";
                    }
                    else
                    {
                        model.score = currentRow["score"].ToString();
                    }
                }

                Formdxdxpd f = new Formdxdxpd(model);
                f.ShowDialog();
            }
        }
        private void BindBtnClick()
        {
            foreach (Control ctr in this.panel1.Controls)
            {
                if (ctr is Button && ctr.Tag != null)
                {
                    ctr.Click += new EventHandler(ctr_Click);
                }
            }
        }

        void ctr_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            RecordCurrentAnswer();
            RecordAnswer();
            lastIndex = currentIndex;
            currentIndex = Convert.ToInt32(btn.Tag);
            ShowQuestion();
            ShowAnswer();
        }
        /// <summary>
        /// 在显示答案后改变按钮样式
        /// </summary>
        private void ShowButtonCss()
        {
            //上一道题目
            Control cc = this.panel1.Controls.Cast<Control>().FirstOrDefault(control => control.Tag != null
    && control.Tag.ToString() == (lastIndex).ToString());
            if (cc is Button && cc.BackColor != Color.Yellow)
            {
                cc.BackColor = Color.Empty;
            }
            //已答题目
            if (answers[lastIndex] != "" && answers[lastIndex] != null)
            {
                Control c = this.panel1.Controls.Cast<Control>().FirstOrDefault(control => control.Tag != null && control.Tag.ToString() == lastIndex.ToString());
                if (c is Button && cc.BackColor != Color.Yellow)
                {
                    c.BackColor = Color.Blue;
                }
            }

            //当前题目
            cc = this.panel1.Controls.Cast<Control>().FirstOrDefault(control => control.Tag != null
               && control.Tag.ToString() == (currentIndex).ToString());
            if (cc is Button && cc.BackColor !=Color.Yellow)
            {
                cc.BackColor = Color.Green;
            }

        }
        private void JiaoJuan()
        {
            btnSubmit.Enabled = false;
            btnJiexi.Enabled = true;
            btnSubmit.Text = "已交卷";
            timerExam.Stop();
            int scoreDxt = 0, scoreDxts = 0, scorePdt = 0, scoreQita = 0;
            RecordCurrentAnswer();
            RecordAnswer();
            string strQita = string.Empty;
            //单选题 
            if (Subject.SName == "会计电算化")
            {
                strQita = "实务题";
                scoreQita = ReadScore();
                for (int i = 1; i <= 10; i++)
                {
                    string youranswer = answers[i];
                    if (string.IsNullOrEmpty(youranswer))
                    {
                        youranswer = "无";
                    }
                    youranswer = youranswer.Trim();
                    string bzanswer = tableDxt.Rows[i - 1]["answer"].ToString().Trim();
                    if (youranswer.ToLower() != bzanswer.ToLower())
                    {
                        Control c = this.panel1.Controls.Cast<Control>().FirstOrDefault(control => control.Tag != null && control.Tag.ToString() == i.ToString());
                        if (c is Button)
                        {
                            c.BackColor = Color.Red;
                        }
                        ShouCangHelper sc = new ShouCangHelper(ShouCangHelper.ShouCangTimu.单选题, Convert.ToInt32(tableDxt.Rows[i - 1]["KeyId"].ToString()));
                        sc.AddErrorTable();
                    }
                    else
                    {
                        scoreDxt++;
                    }

                }
                //多选题
                for (int i = 11; i <= 20; i++)
                {
                    string youranswer = answers[i];
                    if (string.IsNullOrEmpty(youranswer))
                    {
                        youranswer = "无";
                    }
                    string bzanswer = tableDxts.Rows[i - 1 - 10]["answer"].ToString().Trim();
                    char[] c1 = youranswer.ToCharArray();
                    char[] c2 = bzanswer.ToCharArray();
                    Array.Sort(c1);
                    Array.Sort(c2);
                    string stringyour = new string(c1);
                    string stringbz = new string(c2);
                    if (stringyour.Trim().ToLower() != stringbz.Trim().ToLower())
                    {
                        Control c = this.panel1.Controls.Cast<Control>().FirstOrDefault(control => control.Tag != null && control.Tag.ToString() == i.ToString());
                        if (c is Button)
                        {
                            c.BackColor = Color.Red;
                        }
                        ShouCangHelper sc = new ShouCangHelper(ShouCangHelper.ShouCangTimu.多选题, Convert.ToInt32(tableDxts.Rows[i - 1 - 10]["KeyId"].ToString()));
                        sc.AddErrorTable();
                    }
                    else
                    {
                        scoreDxts += 2;
                    }
                }
                //判断题
                for (int i = 21; i <= 30; i++)
                {
                    string youranswer = answers[i];
                    if (string.IsNullOrEmpty(youranswer))
                    {
                        youranswer = "无";
                    }
                    if (youranswer.Trim() == "正确")
                    {
                        youranswer = "对";
                    }
                    else if (youranswer.Trim() == "错误")
                    {
                        youranswer = "错";
                    }
                    string bzanswer = tablePdt.Rows[i - 1 - 20]["answer"].ToString().Trim();
                    if (youranswer.ToLower().Trim() != bzanswer.ToLower().Trim())
                    {
                        Control c = this.panel1.Controls.Cast<Control>().FirstOrDefault(control => control.Tag != null && control.Tag.ToString() == i.ToString());
                        if (c is Button)
                        {
                            c.BackColor = Color.Red;
                        }
                        ShouCangHelper sc = new ShouCangHelper(ShouCangHelper.ShouCangTimu.判断题, Convert.ToInt32(tablePdt.Rows[i - 1 - 20]["KeyId"].ToString()));
                        sc.AddErrorTable();
                    }
                    else
                    {
                        scorePdt++;
                    }
                }
            }
            else
            {
                for (int i = 1; i <= 20; i++)
                {
                    string youranswer = answers[i];
                    if (string.IsNullOrEmpty(youranswer))
                    {
                        youranswer = "无";
                    }
                    youranswer = youranswer.Trim();
                    string bzanswer = tableDxt.Rows[i - 1]["answer"].ToString().Trim();
                    if (youranswer.ToLower() != bzanswer.ToLower())
                    {
                        Control c = this.panel1.Controls.Cast<Control>().FirstOrDefault(control => control.Tag != null && control.Tag.ToString() == i.ToString());
                        if (c is Button)
                        {
                            c.BackColor = Color.Red;
                        }
                        ShouCangHelper sc = new ShouCangHelper(ShouCangHelper.ShouCangTimu.单选题, Convert.ToInt32(tableDxt.Rows[i - 1]["KeyId"].ToString()));
                        sc.AddErrorTable();
                    }
                    else
                    {
                        scoreDxt++;
                    }

                }
                //多选题
                for (int i = 21; i <= 40; i++)
                {
                    string youranswer = answers[i];
                    if (string.IsNullOrEmpty(youranswer))
                    {
                        youranswer = "无";
                    }
                    string bzanswer = tableDxts.Rows[i - 1 - 20]["answer"].ToString().Trim();
                    char[] c1 = youranswer.ToCharArray();
                    char[] c2 = bzanswer.ToCharArray();
                    Array.Sort(c1);
                    Array.Sort(c2);
                    string stringyour = new string(c1);
                    string stringbz = new string(c2);
                    if (stringyour.Trim().ToLower() != stringbz.Trim().ToLower())
                    {
                        Control c = this.panel1.Controls.Cast<Control>().FirstOrDefault(control => control.Tag != null && control.Tag.ToString() == i.ToString());
                        if (c is Button)
                        {
                            c.BackColor = Color.Red;
                        }
                        ShouCangHelper sc = new ShouCangHelper(ShouCangHelper.ShouCangTimu.多选题, Convert.ToInt32(tableDxts.Rows[i - 1 - 20]["KeyId"].ToString()));
                        sc.AddErrorTable();
                    }
                    else
                    {
                        scoreDxts += 2;
                    }
                }
                //判断题
                for (int i = 41; i <= 60; i++)
                {
                    string youranswer = answers[i];
                    if (string.IsNullOrEmpty(youranswer))
                    {
                        youranswer = "无";
                    }
                    if (youranswer.Trim() == "正确")
                    {
                        youranswer = "对";
                    }
                    else if (youranswer.Trim() == "错误")
                    {
                        youranswer = "错";
                    }
                    string bzanswer = tablePdt.Rows[i - 1 - 40]["answer"].ToString().Trim();
                    if (youranswer.ToLower().Trim() != bzanswer.ToLower().Trim())
                    {
                        Control c = this.panel1.Controls.Cast<Control>().FirstOrDefault(control => control.Tag != null && control.Tag.ToString() == i.ToString());
                        if (c is Button)
                        {
                            c.BackColor = Color.Red;
                        }
                        ShouCangHelper sc = new ShouCangHelper(ShouCangHelper.ShouCangTimu.判断题, Convert.ToInt32(tablePdt.Rows[i - 1 - 40]["KeyId"].ToString()));
                        sc.AddErrorTable();
                    }
                    else
                    {
                        scorePdt++;
                    }
                }

                //计算分析题
                if (Subject.SName == "会计基础")
                {
                    strQita = "计算分析题";
                    for (int i = 61; i <= 62; i++)
                    {
                        string youranswer = answers[i];
                        if (string.IsNullOrEmpty(youranswer))
                        {
                            youranswer = "无";
                            continue;
                        }
                        ModelComputeJiexi jiexi = new ModelComputeJiexi();
                        string[] str = youranswer.Split('|');
                        jiexi.answer1 = str[0].ToString();
                        jiexi.answer2 = str[1].ToString();
                        jiexi.answer3 = str[2].ToString();
                        jiexi.answer4 = str[3].ToString();
                        jiexi.answer5 = str[4].ToString();
                        jiexi.biaozhundaan1 = tableCompute.Rows[i - 1 - 60]["answer1"].ToString().Trim();
                        jiexi.biaozhundaan2 = tableCompute.Rows[i - 1 - 60]["answer2"].ToString().Trim();
                        jiexi.biaozhundaan3 = tableCompute.Rows[i - 1 - 60]["answer3"].ToString().Trim();
                        jiexi.biaozhundaan4 = tableCompute.Rows[i - 1 - 60]["answer4"].ToString().Trim();
                        jiexi.biaozhundaan5 = tableCompute.Rows[i - 1 - 60]["answer5"].ToString().Trim();
                        if (jiexi.answer1 == jiexi.biaozhundaan1)
                        {
                            scoreQita += 2;
                        }
                        if (jiexi.answer2 == jiexi.biaozhundaan2)
                        {
                            scoreQita += 2;
                        }
                        if (jiexi.answer3 == jiexi.biaozhundaan3)
                        {
                            scoreQita += 2;
                        }
                        if (jiexi.answer4 == jiexi.biaozhundaan4)
                        {
                            scoreQita += 2;
                        }
                        if (jiexi.answer5 == jiexi.biaozhundaan5)
                        {
                            scoreQita += 2;
                        }

                    }
                }
                else if (Subject.SName == "财经法规与会计职业道德")
                {
                    strQita = "案例分析题";
                    for (int i = 61; i <= 70; i++)
                    {
                        string youranswer = answers[i];
                        if (string.IsNullOrEmpty(youranswer))
                        {
                            youranswer = "无";
                        }
                        string bzanswer = tableAnli.Rows[i - 1 - 60]["answer"].ToString().Trim();
                        char[] c1 = youranswer.ToCharArray();
                        char[] c2 = bzanswer.ToCharArray();
                        Array.Sort(c1);
                        Array.Sort(c2);
                        string stringyour = new string(c1);
                        string stringbz = new string(c2);
                        if (stringyour.Trim().ToLower() != stringbz.Trim().ToLower())
                        {
                            Control c = this.panel1.Controls.Cast<Control>().FirstOrDefault(control => control.Tag != null && control.Tag.ToString() == i.ToString());
                            if (c is Button)
                            {
                                c.BackColor = Color.Red;
                            }
                            //ShouCangHelper sc = new ShouCangHelper(ShouCangHelper.ShouCangTimu.多选题, Convert.ToInt32(tableDxts.Rows[i - 1 - 20]["KeyId"].ToString()));
                            //sc.AddErrorTable();
                        }
                        else
                        {
                            scoreQita += 2;
                        }
                    }

                }


            }
            MessageBox.Show("本次考试结束！其中单选题得分" + scoreDxt +
                ",多选题得分" + scoreDxts + ",判断题得分" + scorePdt + "," + strQita + "得分" + scoreQita + ".总分:" + (scoreDxt + scoreDxts + scorePdt + scoreQita), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.DialogResult result =
               System.Windows.Forms.MessageBox.Show(
                       "确实要交卷吗？",
                       "确认",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                JiaoJuan();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                               this.panel1.ClientRectangle,
                               Color.Gainsboro,//7f9db9
                               1,
                               ButtonBorderStyle.Solid,
                               Color.Gainsboro,
                               1,
                               ButtonBorderStyle.Solid,
                               Color.Gainsboro,
                               1,
                               ButtonBorderStyle.Solid,
                               Color.Gainsboro,
                               1,
                               ButtonBorderStyle.Solid);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                               this.panel2.ClientRectangle,
                               Color.Gainsboro,//7f9db9
                               1,
                               ButtonBorderStyle.Solid,
                               Color.Gainsboro,
                               1,
                               ButtonBorderStyle.Solid,
                               Color.Gainsboro,
                               1,
                               ButtonBorderStyle.Solid,
                               Color.Gainsboro,
                               1,
                               ButtonBorderStyle.Solid);
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            RecordCurrentAnswer();
            RecordAnswer();
            lastIndex = currentIndex;
            currentIndex--;
            if (currentIndex < 1)
            {
                MessageBox.Show("已经是第一题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentIndex++;
                return;
            }
            ShowQuestion();
            ShowAnswer();
        }

        private void buttonEx2_Click(object sender, EventArgs e)
        {
            RecordCurrentAnswer();
            RecordAnswer();
            lastIndex = currentIndex;
            currentIndex++;
            if (Subject.SName == "会计电算化")
            {
                if (currentIndex > 30)///需要判断
                {
                    MessageBox.Show("已经是最后一题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentIndex--;
                    return;
                }
            }
            else if(Subject.SName=="会计基础")
            {
                if (currentIndex > 62)///需要判断
                {
                    MessageBox.Show("已经是最后一题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentIndex--;
                    return;
                }
            }
            else if (Subject.SName == "财经法规与会计职业道德")
            {
                if (currentIndex > 70)
                {
                    MessageBox.Show("已经是最后一题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentIndex--;
                    return;
                }
            }
            ShowQuestion();
            ShowAnswer();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                              this.panel10.ClientRectangle,
                              Color.Gainsboro,//7f9db9
                              1,
                              ButtonBorderStyle.Solid,
                              Color.Gainsboro,
                              1,
                              ButtonBorderStyle.Solid,
                              Color.Gainsboro,
                              1,
                              ButtonBorderStyle.Solid,
                              Color.Gainsboro,
                              1,
                              ButtonBorderStyle.Solid);
        }

        private void panel11_MouseClick(object sender, MouseEventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void btnbiaoji_Click(object sender, EventArgs e)
        {
            Control cc = this.panel1.Controls.Cast<Control>().FirstOrDefault(control => control.Tag != null
        && control.Tag.ToString() == (currentIndex).ToString());
            if (cc is Button)
            {
                cc.BackColor = Color.Yellow;
            }
        }

        private void btnquxiaobiaoji_Click(object sender, EventArgs e)
        {
            Control cc = this.panel1.Controls.Cast<Control>().FirstOrDefault(control => control.Tag != null
&& control.Tag.ToString() == (currentIndex).ToString());
            if (cc is Button)
            {
                cc.BackColor = Color.Empty;
            }
        }

        private void button61_Click(object sender, EventArgs e)
        {
            int shiwutiIndex = (paperIndex + 1) % 4 + 1;
            if(paperIndex>=4)
            {
                shiwutiIndex = new Random().Next(1, 5);
            }
            AppconfigOperate operate = new AppconfigOperate();
            operate.SetValue(Application.StartupPath + "/mbdatafiles/WindowsApplication.exe.config", "Paper", shiwutiIndex.ToString());
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.WorkingDirectory = Application.StartupPath + "\\mbdatafiles\\";    //要启动程序路径
            p.StartInfo.FileName = "WindowsApplication.exe";//需要启动的程序名   
            p.StartInfo.Arguments = "kjsw";
            p.Start();
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 读取分数
        /// </summary>
        private int ReadScore()
        {
            SQLiteHelper sqllite = new SQLiteHelper("mbdatafiles\\data\\Systemdata.dll");
            DataTable dt = sqllite.Select("select tscore from kaoshifengshu");
            int score = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                score += Convert.ToInt32(dt.Rows[i]["tscore"]);
            }
            return score;
        }

    }
}
