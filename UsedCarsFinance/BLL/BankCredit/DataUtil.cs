using BLL.FileOparate;
using Models.BankCredit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL.BankCredit
{
    public class DataUtil
    {
        private const string path = @"~\upload\messageFile\";
        private readonly static DataRule _dataRule = new DataRule();

        /// <summary>
        /// 生成报文尾
        /// </summary>
        /// cais    16.05.30
        /// <param name="count">信息记录总数[10进制数]</param>
        /// <returns></returns>
        public string BuildMessageTail(int count)
        {
            string temp = string.Empty;

            if (count.ToString().Length <= 10)
            {
                temp = count.ToString().PadLeft(10, '0');
            }

            return "Z" + temp;
        }

        /// <summary>
        /// 生成txt文件
        /// </summary>
        /// yaoy    16.07.06
        /// <param name="fileId"></param>
        /// <returns></returns>
        public string CreateTxtFile(int fileId,string message)
        {
            string fileName = string.Empty;
            string txtFileName = string.Empty;
            // 文件路径
            string dirPath = HttpContext.Current.Server.MapPath(path);

            ICombinaData combinaComData = new CombinaComMessageData();
            ICombinaData combinaPerData = new CombinaPerMessageData();

            ReportFilesInfo reportFilesInfo = new DataRule().GetReportFilesInfoById(fileId);

            // 获取服务对象
            int serviceObj = reportFilesInfo == null ? 0 : reportFilesInfo.ServiceObj;

            // 企业报文
            if (serviceObj == 1)
            {
                txtFileName = combinaComData.BuildMessageName(fileId);
            }
            // 个人报文
            if (serviceObj == 2)
            {
                txtFileName = combinaPerData.BuildMessageName(fileId);
            }

            if (! DirFile.IsExistDirectory(dirPath))
            {
                DirFile.CreateDirectory(dirPath);
            }

            if (txtFileName != string.Empty)
            {
                fileName = txtFileName + ".txt";
                string filePath = dirPath + fileName;

                DirFile.CreateFile(filePath);
                DirFile.WriteText(filePath, message, Encoding.GetEncoding("gb2312"));
            }

            return fileName;
        }

        /// <summary>
        /// 10进制转36进制
        /// </summary>
        /// yaoy    16.07.12
        /// <param name="i"></param>
        /// <returns></returns>
        public string ConvertTo36(int i)
        {
            int j = 0;
            string s = string.Empty;

            while (i >= 36)
            {
                j = i % 36;

                if (j <= 9)
                {
                    s += j.ToString();
                }
                else
                {
                    s += Convert.ToChar(j - 10 + 'A');
                }

                i = i / 36;
            }
            if (i <= 9)
            {
                s += i.ToString();
            }
            else
            {
                s += Convert.ToChar(i - 10 + 'A');
            }
            Char[] c = s.ToCharArray();
            Array.Reverse(c);

            return new string(c);
        }
    }
}
