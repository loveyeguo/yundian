using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLibrary;

namespace AccountingApplication.Bll
{
    /// <summary>
    /// 处理题目收藏
    /// </summary>
    public class ShouCangHelper
    {
        SQLiteHelper db = new SQLiteHelper("error.dll");
        string tableName = string.Empty;
        string subject = Subject.SName;
        int KeyId = 0;
        public ShouCangHelper(ShouCangTimu timu, int KeyId)
        {
            switch (timu)
            {
                case ShouCangTimu.单选题:
                    tableName = "questionSingle";
                    break;
                case ShouCangTimu.多选题:
                    tableName = "questionMultiple";
                    break;
                case ShouCangTimu.判断题:
                    tableName = "questionJudge";
                    break;
            }
            this.KeyId = KeyId;
        }
        public enum ShouCangTimu
        {
            单选题,
            多选题,
            判断题
        }
        public enum ShouCangKemu
        {
            会计基础,
            财经法规与会计职业道德,
            会计电算化
        }
        public bool IsAlreadyShouCang()
        {
            object result = db.ExecuteScalar
                ("select KeyId from goodTable where subject='" + subject + "' and questionType='" + tableName + "' and questionID=" + KeyId + "");
            if (result != null && Convert.ToInt32(result) > 0)
            {
                return true;
            }
            return false;

        }
        public bool IsAlreadyCuotiji()
        {
            object result = db.ExecuteScalar
                ("select KeyId from errorTable where subject='" + subject + "' and questionType='" + tableName + "' and questionID=" + KeyId + "");
            if (result != null && Convert.ToInt32(result) > 0)
            {
                return true;
            }
            return false;

        }
        public void AddGoodTable()
        {
            db.Execute("insert into goodTable values(null,'" + subject + "'," + KeyId + ",'" + tableName + "')");
        }
        public void DelGoodTable()
        {
            db.Execute("delete from goodTable where questionID=" + KeyId + "");
        }

        public void AddErrorTable()
        {
            if (!IsAlreadyCuotiji())
            {
                db.Execute("insert into errorTable values(null,'" + subject + "'," + KeyId + ",'" + tableName + "')");

            }

        }
        public void DelErrorTable()
        {
            db.Execute("delete from errorTable where questionID=" + KeyId + "");
        }
    }
}
