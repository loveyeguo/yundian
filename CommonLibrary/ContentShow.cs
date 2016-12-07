using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
    public class ContentShow
    {
        public static string GetTile(string content, ColorBrowser color)
        {
            string html = "<html><body style=\"background-color:rgb(" + GetColor(color) + ")\" onmousemove=\"HideMenu()\" oncontextmenu=\"return false\" ondragstart=\"return false\" onselectstart =\"return false\" onselect=\"document.selection.empty()\" oncopy=\"document.selection.empty()\" onbeforecopy=\"return false\" onmouseup=\"document.selection.empty()\"><p>" + content + "</p></html>";
            return html;
        }
        public enum ColorBrowser
        {
            针对普通题目,
            针对考试题目
        }
        private static string GetColor(ColorBrowser color)
        {
            string s = string.Empty;
            switch (color)
            {
                case ColorBrowser.针对普通题目:
                    s = "249,249,249";
                    break;
                case ColorBrowser.针对考试题目:
                    s = "221, 241, 250";
                    break;
                default:
                    s = "249,249,249";
                    break;
            }
            return s;
        }

    }
}
