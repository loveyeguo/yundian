using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
using System.Text;
using Microsoft.Win32;
using System.Net.NetworkInformation;

namespace CommonLibrary
{
    /// <summary>
    /// 验证是否为注册
    /// </summary>
    public class CheckMember
    {
        string Ekey = "";
        public CheckMember()
        {
            switch (Subject.SName)
            {
                case "会计电算化":
                    Ekey = "33333333";
                    break;

                case "财经法规与会计职业道德":
                    Ekey = "22222222";
                    break;

                case "会计基础":
                    Ekey = "11111111";
                    break;
            }
        }
        EncryptClass encry = new EncryptClass();
        /// <summary>
        /// 查找是否注册过,验证码是否正确,返回到期日期
        /// </summary>
        /// <returns></returns>
        public string CheckRegReturnEndTime(out DateTime endTime)
        {
            endTime = DateTime.Parse("1990-01-01");
            SQLiteHelper sh = new SQLiteHelper("rrr.dll");
            string currentMac = encry.getMNum();
            DataTable tb = sh.Select("select * from reg where subjectName='" + Subject.SName + "' and macAddress='" + currentMac + "'");
            if (tb == null || tb.Rows.Count == 0)
            {
                CommonIsReg.IsReg = false;
                return "软件未注册";
            }
            if (tb.Rows[0]["macAddress"].ToString() != currentMac)
            {
                CommonIsReg.IsReg = false;
                return "软件未注册";
            }
            DateTime selectDt = DateTime.Parse(tb.Rows[0]["endTime"].ToString());
            if (selectDt.Date.Subtract(DateTime.Now.Date).Days < 0)
            {
                CommonIsReg.IsReg = false;
                return "软件已过期 到期日期：" + selectDt.ToString("yyyy-MM-dd");
            }
            endTime = selectDt;
            CommonIsReg.IsReg = true;
            return "";

        }
        public void WriteReg(string regCode, DateTime endTime)
        {
            SQLiteHelper sh = new SQLiteHelper("rrr.dll");
            string reg = DESEncrypt.Decrypt(regCode);
            if (reg.Contains("test"))
            {
                endTime = endTime.AddMonths(1);
            }
            else
            {
                endTime = endTime.AddYears(1);
            }
            string currentMac = encry.getMNum();
            sh.Execute("update reg set macAddress='" + currentMac + "' , endTime='" + endTime + "' where subjectName='" + Subject.SName + "'");
        }

        private static  DateTime InitCacheTime()
        {
            RegistryKey retkey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true).CreateSubKey("ks").CreateSubKey("cache.INI");
            DateTime cacheTime;
            if (Ping("60.205.26.33"))
            {
                CommonLibrary.CheckReg.WebServiceExamSoapClient c = new CommonLibrary.CheckReg.WebServiceExamSoapClient();
                cacheTime = c.GetServiceTime().Date;
              
                retkey.SetValue("cacheTime", cacheTime);

            }
            else
            {
                object obj = retkey.GetValue("cacheTime");
                if (obj == null)
                {
                    cacheTime = DateTime.Now;
                }
                else
                {
                    cacheTime= Convert.ToDateTime(obj);
                }
            }
            return cacheTime;

        }
        /// <summary>
        /// 检测系统时间是否被篡改
        /// </summary>
        /// <returns></returns>
        public static bool CheckChangeTime()
        {
            DateTime dt = InitCacheTime();
            if (DateTime.Now.Date.Subtract(dt.Date).Days < 0)
            {
                return true;

            }
            return false;
        }
        public static bool Ping(string strIpOrDName)
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions();
                objPinOptions.DontFragment = true;
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 120;
                PingReply objPinReply = objPingSender.Send(strIpOrDName, intTimeout, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
