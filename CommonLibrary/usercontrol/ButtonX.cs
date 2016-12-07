using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountingApplication.usercontrol
{
    public class ButtonX : Button
    {
        public ButtonX()
        {
            //不让button显示虚线边框
            SetStyle(ControlStyles.Selectable, false); 
        }
    }
}
