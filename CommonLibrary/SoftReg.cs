using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using Microsoft.Win32;

 
    public class SoftReg
    {
        ///<summary>
        /// 获取硬盘卷标号
        ///</summary>
        ///<returns></returns>
        public string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        ///<summary>
        /// 获取CPU序列号
        ///</summary>
        ///<returns></returns>
        public string GetCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuCollection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuCollection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
            }
            return strCpu;
        }

        ///<summary>
        /// 生成机器码
        ///</summary>
        ///<returns></returns>
        public string GetMNum()
        {
            string strNum = GetCpu() + GetDiskVolumeSerialNumber();
            //截取前24位作为机器码
            string strMNum = strNum.Substring(0, 24);
            return strMNum;
        }
        //存储密钥
        public int[] intCode = new int[127];
        //存储ASCII码
        public char[] charCode = new char[25];
        //存储ASCII码值
        public int[] intNumber = new int[25];

        //初始化密钥
        public void SetIntCode()
        {
            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = i % 9;
            }
        }

        ///<summary>
        /// 生成注册码
        ///</summary>
        ///<returns></returns>
        public string GetRNum()
        {
            SetIntCode();
            string strMNum = GetMNum();
            //存储机器码
            for (int i = 1; i < charCode.Length; i++)
            {
                charCode[i] = Convert.ToChar(strMNum.Substring(i - 1, 1));
            }
            //改变ASCII码值
            for (int j = 1; j < intNumber.Length; j++)
            {
                intNumber[j] = Convert.ToInt32(charCode[j]) + intCode[Convert.ToInt32(charCode[j])];
            }
            //注册码
            string strAsciiName = "";
            //生成注册码
            for (int k = 1; k < intNumber.Length; k++)
            {
                //判断如果在0-9、A-Z、a-z之间
                if ((intNumber[k] >= 48 && intNumber[k] <= 57) || (intNumber[k] >= 65 && intNumber[k]
                    <= 90) || (intNumber[k] >= 97 && intNumber[k] <= 122))
                {
                    strAsciiName += Convert.ToChar(intNumber[k]).ToString();
                }
                else if (intNumber[k] > 122)  //判断如果大于z
                {
                    strAsciiName += Convert.ToChar(intNumber[k] - 10).ToString();
                }
                else
                {
                    strAsciiName += Convert.ToChar(intNumber[k] - 9).ToString();
                }
            }
            return strAsciiName;
        }


        ///<summary>
        /// 生成注册码
        ///</summary>
        ///<returns></returns>
        public string GetRNum(string mNum)
        {
            SetIntCode();
            string strMNum = mNum;
            //存储机器码
            for (int i = 1; i < charCode.Length; i++)
            {
                charCode[i] = Convert.ToChar(strMNum.Substring(i - 1, 1));
            }
            //改变ASCII码值
            for (int j = 1; j < intNumber.Length; j++)
            {
                intNumber[j] = Convert.ToInt32(charCode[j]) + intCode[Convert.ToInt32(charCode[j])];
            }
            //注册码
            string strAsciiName = "";
            //生成注册码
            for (int k = 1; k < intNumber.Length; k++)
            {
                //判断如果在0-9、A-Z、a-z之间
                if ((intNumber[k] >= 48 && intNumber[k] <= 57) || (intNumber[k] >= 65 && intNumber[k]
                    <= 90) || (intNumber[k] >= 97 && intNumber[k] <= 122))
                {
                    strAsciiName += Convert.ToChar(intNumber[k]).ToString();
                }
                else if (intNumber[k] > 122)  //判断如果大于z
                {
                    strAsciiName += Convert.ToChar(intNumber[k] - 10).ToString();
                }
                else
                {
                    strAsciiName += Convert.ToChar(intNumber[k] - 9).ToString();
                }
            }
            return strAsciiName;
        }
        /// <summary>
        /// 写入注册码到注册表
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public void WriteRegInfo(string reg)
        {
            RegistryKey retkey = Registry.CurrentUser.OpenSubKey("Software", true).CreateSubKey("wxf").CreateSubKey("wxf.INI").CreateSubKey(reg);
            retkey.SetValue("UserName", "YanC");
        }
        /// <summary>
        /// 判断注册码是否在注册表中
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public bool GetRegInfo(string reg)
        {
            RegistryKey retkey = Registry.CurrentUser.OpenSubKey("Software", true).CreateSubKey("wxf").CreateSubKey("wxf.INI").CreateSubKey(reg);
            if (retkey == null || retkey.GetValue("UserName") == null || retkey.GetValue("UserName").ToString()!= "YanC")
            {
                return false;
            }
            return true;
        }
    }
 
