using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingApplication.model
{
    /// <summary>
    /// 章节树节点
    /// </summary>
    public class TreeNodeZJ
    {
        public int parentIndex { get; set; }
        public int currentIndex { get; set; }
        public TreeNodeZJ(int parentIndex, int currentIndex)
        {
            this.parentIndex = parentIndex;
            this.currentIndex = currentIndex;
        }
    }
}
