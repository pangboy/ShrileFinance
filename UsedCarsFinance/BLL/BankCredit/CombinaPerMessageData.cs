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
    public class CombinaPerMessageData : ICombinaData
    {
        private const string DOCUMENT_VERSION = "1.3";
        private const string path = @"~\upload\messageFile\";
        private readonly static DataRule _dataRule = new DataRule();

        /// <summary>
        /// 生成报文名
        /// </summary>
        /// yaoy    16.07.05
        /// <param name="fileId"></param>
        /// <returns></returns>
        public string BuildMessageName(int fileId)
        {
            string messageName = string.Empty;
            string serialNumber = string.Empty;
            string serialNumberExt = string.Empty;
            string parterName = string.Empty;
            // 个人金融机构代码
            string perFinancialInstitutionCode = "B10211000H0001";

            ReportFilesInfo reportFilesInfo = _dataRule.GetReportFilesInfoById(fileId);
            int messageFileId = reportFilesInfo == null ? 0 : reportFilesInfo.MessageFileId;
            MessageFileInfo messageFileInfo = _dataRule.GetMessageFileInfoById(messageFileId);
            int messageFileTypeId = messageFileInfo == null ? 0 : messageFileInfo.MessageFileTypeId;

            if (messageFileTypeId == 4)
            {
                parterName = perFinancialInstitutionCode + DateTime.Now.ToString("yyyyMM");
            }
            if (messageFileTypeId == 5)
            {
                parterName = perFinancialInstitutionCode + DateTime.Now.ToString("yyyyMMdd") + "04";
            }
            if (messageFileTypeId == 6)
            {
                parterName = perFinancialInstitutionCode + DateTime.Now.ToString("yyyyMMdd") + "08";
            }
            // 获取当天文件数量
            int fileCount = new DAL.BankCredit.ReportFilesMapper().FindFileCount(parterName);
            if (fileCount >= 0)
            {
                string number = new DataUtil().ConvertTo36(fileCount + 1);

                if (number.Length <= 6 && number.Length >= 3)
                {
                    serialNumber = number.Substring(0, 3);
                    serialNumberExt = number.Substring(3, number.Length).PadLeft(3, '0');
                }
                if (number.Length > 0 && number.Length < 3)
                {
                    serialNumber = number.PadLeft(3, '0');
                    serialNumberExt = "000";
                }
            }

            if (messageFileTypeId == 4)
            {
                messageName = parterName + serialNumber + "1" + serialNumberExt;
            }
            if (messageFileTypeId == 5)
            {
                messageName = parterName + "04" + serialNumber;
            }
            if (messageFileTypeId == 6)
            {
                messageName = parterName + "08" + serialNumber;
            }

            return messageName;
        }

        /// <summary>
        /// 生成报文头
        /// </summary>
        /// yaoy    16.07.05
        /// <param name="fileId"></param>
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        public string BuildMessageTop(int fileId, int messageTypeId, int i)
        {
            //TODO:个人报文头需要获取“最早结算/应还款日期”和“最晚结算/应还款日期”获取联系人和联系电话
            string Name = "严冬";
            int GBlength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(Name);//用于获取字符串转换成GB2312的长度
            int EncLength = Name.Length;
            Name = Name.PadRight(30, ' ');
            Name = Name.Substring(0, Name.Length - (GBlength - EncLength));
            string Phone = "15824430950";


            // 报文头临时变量
            string messageTopData = string.Empty;
            // 补位码临时变量
            string complementBits = string.Empty;
            // 版本号
            string version = "1.3";
            // 个人金融机构代码
            string perFinancialInstitutionCode = "B10211000H0001";
            // 获取报文文件信息
            ReportFilesInfo reportFilesInfo = _dataRule.GetReportFilesInfoById(fileId);
            int messageFileId = reportFilesInfo == null ? 0 : reportFilesInfo.MessageFileId;
            MessageFileInfo messageFileInfo = _dataRule.GetMessageFileInfoById(messageFileId);
            int messageFileTypeId = messageFileInfo == null ? 0 : messageFileInfo.MessageFileTypeId;

            string tempDate = GetValue(fileId);

            // 正常报文文件
            if (messageFileTypeId == 4 && tempDate != "")
            {
                messageTopData = version + perFinancialInstitutionCode + DateTime.Now.ToString("yyyyMMddHHmmss") + "1.0" + "11" + i.ToString().PadLeft(10, '0') + tempDate + Name + Phone.PadRight(25, ' ')+string.Empty.PadLeft(30, ' ');
            }
            // 账户标识变更报文文件
            if (messageFileTypeId == 5)
            {
                messageTopData = version + DateTime.Now.ToString("yyyyMMddHHmmss") + perFinancialInstitutionCode + "4" + i.ToString().PadLeft(8, '0');
            }
            // 删除报文文件
            if (messageFileTypeId == 6)
            {
                messageTopData = version + DateTime.Now.ToString("yyyyMMddHHmmss") + perFinancialInstitutionCode + i.ToString().PadLeft(8, '0') + "000000000000000000000000000000" + "0000000000000000000000000" + string.Empty.PadLeft(30, ' ');
            }

            return messageTopData;
        }

        /// <summary>
        /// 生成报文体
        /// </summary>
        /// yaoy    16.07.05
        /// <param name="fileId"></param>
        /// <param name="messageTypeId"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public string BuildMessageBody(int fileId, int messageTypeId, out int i)
        {
            int j = 0;
            string messageBodyData = string.Empty;

            DataAndRuleComPare compare = new DataAndRuleComPare();
            List<InfoTypeInfo> infoTypeList = _dataRule.GetInfoTypeList(messageTypeId);

            // 遍历信息类型
            foreach (InfoTypeInfo infoTypeInfo in infoTypeList)
            {
                InfoTypeInfo infoType = _dataRule.GetDataRuleByInfoTypeId(infoTypeInfo.InfoTypeId);
                List<InformationRecordInfo> informationRecordList = _dataRule.GetInformationListByInfoTypeIdAndFileId(infoTypeInfo.InfoTypeId, fileId);

                if (informationRecordList != null)
                {
                    // 遍历信息记录
                    foreach (InformationRecordInfo informationRecordInfo in informationRecordList)
                    {
                        j++;

                        var context = informationRecordInfo.Context;
                        messageBodyData += new DataRule().ReplaceData(compare.EncapsulateData(infoType, context)) + "\r\n";
                    }
                }
            }

            i = j;

            return messageBodyData;
        }

        /// <summary>
        /// 获取最早最晚还款日期
        /// </summary>
        /// yaoy    16.09.29
        /// <param name="fileId"></param>
        /// <returns></returns>
        public string GetValue(int fileId)
        {
            var result = string.Empty;
            var metaCode = 2301;
            var list = new List<string>();

            List<ReportInfo> reportList = new Report().List(fileId);

            foreach (var reportInfo in reportList)
            {
                List<InformationRecordInfo> informationList = new InformationRecord().GetByReportId(reportInfo.ReportID);

                if(informationList!= null)
                {
                    foreach (var informationInfo in informationList)
                    {
                        // 根据信息记录类型和数据元获取所以数据段规则集合
                        var segmentRulesList = new SegmentRules().GetByInfoTypeIdAndMetaCode(informationInfo.InfoTypeID, metaCode);

                        if(segmentRulesList != null)
                        {
                            foreach (var segmentRulesInfo in segmentRulesList)
                            {
                                // 数据段实体
                                var dataSegmentInfo = new DataSegment().Get(segmentRulesInfo.BDS_ID);
                                // 取值
                                var temp = new CommonUtil().GetValues(informationInfo.Context, dataSegmentInfo.ParagraphCode, segmentRulesInfo.SegmentRulesId.ToString());

                                if(temp != "") {
                                    list.Add(temp);
                                }
                            }
                        }
                    }
                }
            }

            list.Sort();

            if (list.Count >= 1)
            {
                result = list[0] + list[list.Count - 1];
            }

            return result;
        }
    }
}
