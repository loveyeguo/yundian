using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace AccountingApplication
{
    public class BaseExamForm : UserControl
    {
        public string answer = "";

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseExamForm
            // 
            this.Name = "BaseExamForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BaseExamForm_Paint);
            this.ResumeLayout(false);

        }

        private void BaseExamForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                        this.ClientRectangle,
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

    }
}
