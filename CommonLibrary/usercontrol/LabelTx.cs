using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace CommonLibrary.usercontrol
{
    public class LabelTx : Label
    {
        int lineDistance = 5;//行间距

        public int LineDistance
        {
            get { return lineDistance; }
            set { lineDistance = value; }
        }
        public LabelTx()
        {
           // InitializeComponent();
        }


        public LabelTx(IContainer container)
        {
            container.Add(this);

            //InitializeComponent();
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            String drawString = this.Text;
            Font drawFont = this.Font;
            SolidBrush drawBrush = new SolidBrush(this.ForeColor);
            SizeF textSize = g.MeasureString(this.Text, this.Font);//文本的矩形区域大小 
            int lineCount = Convert.ToInt16(textSize.Width / this.Width) + 1;//计算行数

            this.Height = Convert.ToInt16((textSize.Height + lineDistance) * lineCount);//计算调整后的高度

            //this.Height = Convert.ToInt16((textSize.Height + lineDistance) * lineCount) - Math.Abs(LineDistance * 2);//计算调整后的高度 
            this.AutoSize = false;
            float x = 0.0F;
            float y = 0.0F;
            StringFormat drawFormat = new StringFormat();
            int step = 1;
            lineCount = drawString.Length;//行数不超过总字符数目 
            for (int i = 0; i < lineCount; i++)
            {
                //计算每行容纳的字符数目 
                int charCount;
                for (charCount = 0; charCount < drawString.Length; charCount++)
                {
                    string subN = drawString.Substring(0, charCount);
                    string subN1 = drawString.Substring(0, charCount + 1);
                    if (g.MeasureString(subN, this.Font).Width <= this.Width && g.MeasureString(subN1, this.Font).Width > this.Width)
                    {
                        step = charCount;
                        break;
                    }
                }
                string subStr;
                if (charCount == drawString.Length)//最后一行文本 
                {
                    subStr = drawString;
                    e.Graphics.DrawString(subStr, drawFont, drawBrush, x, Convert.ToInt16(textSize.Height * i) + i * LineDistance, drawFormat);
                    break;
                }
                else
                {
                    subStr = drawString.Substring(0, step);//当前行文本 
                    drawString = drawString.Substring(step);//剩余文本 
                    e.Graphics.DrawString(subStr, drawFont, drawBrush, x, Convert.ToInt16(textSize.Height * i) + i * LineDistance, drawFormat);
                }
            }
        }
    }

}
