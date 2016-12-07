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
    public partial class ShowJiexi : Form
    {
        private ModelComputeJiexi jiexi;
        public int score = 0;
        public ShowJiexi()
        {
            InitializeComponent();
        }
        public ShowJiexi(ModelComputeJiexi jiexi)
        {
            InitializeComponent();
            this.jiexi = jiexi;
        }
        private void Init()
        {
            score = 0;

            txtjiexi.Text = jiexi.jiexi;
            if (jiexi.answer1 == jiexi.biaozhundaan1)
            {
                this.pictureBoxAnswer1.ImageLocation = @"image/right.png";
                score += 2;
            }
            else
            {
                this.pictureBoxAnswer1.ImageLocation = @"image/error.png";
            }

            if (jiexi.answer2 == jiexi.biaozhundaan2)
            {
                this.pictureBoxAnswer2.ImageLocation = @"image/right.png";
                score += 2;
            }
            else
            {
                this.pictureBoxAnswer2.ImageLocation = @"image/error.png";
            }

            if (jiexi.answer3 == jiexi.biaozhundaan3)
            {
                this.pictureBoxAnswer3.ImageLocation = @"image/right.png";
                score += 2;
            }
            else
            {
                this.pictureBoxAnswer3.ImageLocation = @"image/error.png";
            }

            if (jiexi.answer4 == jiexi.biaozhundaan4)
            {
                this.pictureBoxAnswer4.ImageLocation = @"image/right.png";
                score += 2;
            }
            else
            {
                this.pictureBoxAnswer4.ImageLocation = @"image/error.png";
            }

            if (jiexi.answer5 == jiexi.biaozhundaan5)
            {
                this.pictureBoxAnswer5.ImageLocation = @"image/right.png";
                score += 2;
            }
            else
            {
                this.pictureBoxAnswer5.ImageLocation = @"image/error.png";
            }
            txtkaosheng1.Text = jiexi.answer1.Replace("#", " ").Replace("*", Environment.NewLine);
            txtkaosheng2.Text = jiexi.answer2.Replace("#", " ").Replace("*", Environment.NewLine);
            txtkaosheng3.Text = jiexi.answer3.Replace("#", " ").Replace("*", Environment.NewLine);
            txtkaosheng4.Text = jiexi.answer4.Replace("#", " ").Replace("*", Environment.NewLine);
            txtkaosheng5.Text = jiexi.answer5.Replace("#", " ").Replace("*", Environment.NewLine);

            txtbiaozhun1.Text = jiexi.biaozhundaan1.Replace("#", " ").Replace("*", Environment.NewLine);
            txtbiaozhun2.Text = jiexi.biaozhundaan2.Replace("#", " ").Replace("*", Environment.NewLine);
            txtbiaozhun3.Text = jiexi.biaozhundaan3.Replace("#", " ").Replace("*", Environment.NewLine);
            txtbiaozhun4.Text = jiexi.biaozhundaan4.Replace("#", " ").Replace("*", Environment.NewLine);
            txtbiaozhun5.Text = jiexi.biaozhundaan5.Replace("#", " ").Replace("*", Environment.NewLine);
            lblScore.Text = score.ToString();
        }

        private void ShowJiexi_Load(object sender, EventArgs e)
        {
            Init();
        }
    }
}
