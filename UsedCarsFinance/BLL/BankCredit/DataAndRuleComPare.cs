using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Transactions;
using Model.BankCredit;
using Newtonsoft.Json;

namespace BLL.BankCredit
{
    public class DataAndRuleComPare
    {
        //用于记录操作类型的值
        string czType = string.Empty;
        string ParagraphCode = string.Empty;
        // 借据编号
        string jjbh = string.Empty;
        //展期金额
        string zqje = string.Empty;
        //展期次数
        string zqcs = string.Empty;
        /// <summary>
        /// 信息记录保存
        /// </summary>
        /// yand    16.06.02
        /// <param name="infoType">信息记录实体</param>
        /// <param name="recordID">RecordID</param>
        /// <param name="messageInfo">报文实体</param>
        /// <param name="postmessage">前端参数</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Compare(InfoTypeInfo infoType, int recordID, int reportID, MessageInfo messageInfo, PostMessage postmessage, ref string message)
        {
            bool result = true;
            InformationRecordInfo informationRecord = new InformationRecordInfo();
            informationRecord.InfoTypeID = postmessage.InfoTypeId;
            informationRecord.ReportID = postmessage.ReportId;
            informationRecord.Context = postmessage.Value;

            using (TransactionScope scope = new TransactionScope())
            {
                informationRecord.Context = JsonConvert.SerializeObject(DataAndRuleCompare1(infoType, messageInfo, ref message));

                if (recordID != 0)
                {
                    informationRecord.RecordID = recordID;
                    result &= DataAndRuleCompare(infoType, messageInfo, recordID, reportID, ref message) && new InformationRecord().Modify(informationRecord);
                }
                else
                {
                    result &= DataAndRuleCompare(infoType, messageInfo, recordID, reportID, ref message) && new InformationRecord().Add(informationRecord);
                    if (result)
                    {
                        DataTable dt = new DAL.BankCredit.ReportFilesMapper().FindData(postmessage.ReportId);
                        if (dt.Rows.Count > 0)
                        {
                            ReportFilesInfo reportFile = new ReportFilesInfo();

                            // 已编辑
                            reportFile.ReportState = 2;
                            reportFile.FileID = Convert.ToInt32(dt.Rows[0]["FileID"].ToString());
                            result = new DAL.BankCredit.ReportFilesMapper().UpdateState(reportFile) > 0;
                        }
                    }
                }

                if (result)
                {
                    scope.Complete();
                }
            }

            return result;
        }

        /// <summary>
        /// 数据和规则校验
        /// </summary>
        /// yaoy    16.06.01
        /// <param name="infoType"></param>
        /// <param name="messageInfo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool DataAndRuleCompare(InfoTypeInfo infoType, MessageInfo messageInfo, int recordID, int reportID, ref string message)
        {
            message = string.Empty;

            PropertyInfo[] ps = messageInfo.GetType().GetProperties();
            //数据校验

            foreach (PropertyInfo pi in ps)
            {
                List<Dictionary<string, string>> list = (List<Dictionary<string, string>>)pi.GetValue(messageInfo);
                if (pi.Name == "C" && list.Count > 0)
                {
                    ParagraphCode = pi.Name;
                }
                List<DataSegmentInfo> dataSegmentList = infoType.DataSegmentList;
                if (dataSegmentList != null)
                {
                    foreach (DataSegmentInfo dataSegmentInfo in dataSegmentList)
                    {
                        List<SegmentRulesInfo> segmentRulesList = dataSegmentInfo.SegmnetRulesList;

                        foreach (SegmentRulesInfo segmentRulesInfo in segmentRulesList)
                        {
                            MetaInfo metaInfo = segmentRulesInfo.MetaInfo;
                            if (list != null)
                            {
                                foreach (Dictionary<string, string> dic in list)
                                {
                                    foreach (var info in dic)
                                    {
                                        if (info.Key == dataSegmentInfo.ParagraphCode + segmentRulesInfo.SegmentRulesId.ToString())
                                        {
                                            if (info.Value != "")
                                            {
                                                bool result = DataValidate(infoType, metaInfo, info, dataSegmentInfo.ParagraphCode, recordID, reportID, ref message);
                                                if (result == false)
                                                {
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                if (segmentRulesInfo.IsRequired == "M")
                                                {
                                                    throw new ApplicationException(metaInfo.Name + "为必填项！");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Validates.ValidatesFactoryModel.Create(infoType.InfoTypeId, messageInfo);

            return true;
        }

        /// <summary>
        /// 跨信息记录校验
        /// </summary>
        /// yand    16.09.27
        /// <param name="infoTypeId">信息记录id</param>
        /// <param name="fileId">报文文件ID</param>
        /// <param name="metaCode">数据元ID</param>
        /// <param name="dataSegmentParagraphCode">段标识</param>
        /// <returns></returns>
        public bool ValidateInfos(int infoTypeId, int fileId, int metaCode, KeyValuePair<string, string> value, string dataSegmentParagraphCode)
        {
            //var list = new List<string>();
            //string result = string.Empty;
            ////业务发生日期
            //if (metaCode == 2501)
            //{
            //    list = Dictionary(infoTypeId, fileId, metaCode, dataSegmentParagraphCode);
            //    list.Sort();
            //    if (list.Count > 0)
            //    {
            //        if (Convert.ToInt32(value.Value) < Convert.ToInt32(list[list.Count - 1]))
            //        {
            //            throw new ApplicationException("当信息记录的记录操作类型为新增时，该信息记录的业务发生日期必须大于等于库中该记录所属业务的最新信息记录的业务发生日期");
            //        }
            //    }
            //}

            return true;
        }

        /// <summary>
        /// 数据跨信息记录校验
        /// </summary>
        /// yand    16.09.27
        /// <param name="infoType">信息记录实体</param>
        /// <param name="metaInfo">数据元实体</param>
        /// <param name="info">前端传递过来的键值对值</param>
        /// <param name="recordID">信息记录保存的ID</param>
        /// <param name="message">返回的错误信息</param>
        /// <returns></returns>
        public bool DataValidate(InfoTypeInfo infoType, MetaInfo metaInfo, KeyValuePair<string, string> info, string dataSegmentParagraphCode, int recordID, int reportID, ref string message)
        {
            if (!VarificationData(metaInfo, info.Value))
            {
                throw new ApplicationException(metaInfo.Name + "数据类型错误！");
            }
            if (Encoding.GetEncoding("GB2312").GetByteCount(info.Value) > metaInfo.DatasLength)
            {
                throw new ApplicationException(metaInfo.Name + "数据长度错误！");
            }
            if (!(new CodeProofMethod().BaseInfo(infoType.InfoTypeId, info)))
            {
                throw new ApplicationException(metaInfo.Name + "下拉选项有误！");
            }
            //校验时间类型
            if (metaInfo.RuleType.TimeType == true && info.Value != "")
            {
                DateTime dt = new DateTime();
                DateTime.TryParse(info.Value, out dt);
                if (dt == null)
                {
                    throw new ApplicationException(metaInfo.Name + "时间格式有错误");
                }
            }
            //根据财务报表中信息记录类型判断借款人概况信息中借款人性质
            if (infoType.InfoTypeId == 3 || infoType.InfoTypeId == 4 || infoType.InfoTypeId == 5 || infoType.InfoTypeId == 6 || infoType.InfoTypeId == 7)
            {
                if (metaInfo.MetaCode == 7653)
                {
                    //借款人性质
                    string segmentRuleID = "D26";
                    //根据还款记录对应的借据信息记录
                    int infoid = 1;

                    ReportInfo reportInfo = new DAL.BankCredit.ReportMapper().FindByReportID(reportID);

                    string s = InfoValueValidate(infoid, reportInfo.ReportFileID, info, jjbh, segmentRuleID);
                    if (string.IsNullOrEmpty(s))
                    {
                        throw new ApplicationException("未能找到该报文下对应的借款人概况信息记录，请先填写借款人概况信息");
                    }
                    else
                    {
                        if (s != "04" && (info.Value == "46" || info.Value == "47"))
                        {
                            throw new ApplicationException("当为“事业单位资产负债表信息记录”或“事业单位收入支出表信息记录”时，借款人概况信息中的借款人性质只能是“事业单位”");
                        }
                        if (s == "04" && (info.Value == "43" || info.Value == "44" || info.Value == "45"))
                        {
                            throw new ApplicationException("当为“2007版资产负债表信息记录”或“2007版利润及利润分配表信息记录”或“2007版现金流量表信息记录”时，借款人概况信息中的借款人性质不能为“事业单位”");
                        }
                    }

                }
            }

            //借据信息记录中贷款合同编号
            if (info.Key == "B513")
            {
                //需要获取的贷款合同信息记录中的贷款合同编号
                string segmentRuleID = "B489";
                //根据合同信息记录编号
                int infoid = 10;

                ReportInfo reportInfo = new DAL.BankCredit.ReportMapper().FindByReportID(reportID);

                string s = InfoValueValidate(infoid, reportInfo.ReportFileID, info, info.Value, segmentRuleID);
                if (string.IsNullOrEmpty(s)|| info.Value != s)
                {
                    throw new ApplicationException("未能找到该贷款合同号码对应的贷款合同信息");
                }
            }
            if (metaInfo.MetaCode == 7511)
            {
                czType = info.Value;
                if (info.Value == "4" && recordID == 0)
                {
                    throw new ApplicationException("该条信息记录不存在，信息记录操作类型不能为删除操作");
                }
                if (info.Value == "4" && ParagraphCode == "C")
                {
                    throw new ApplicationException("当信息记录操作类型为删除时不能存在标识变更段");
                }

            }
            if (metaInfo.MetaCode == 2501)
            {
                //根据recordId获取信息获取保存的报文文件ID

                ReportInfo reportInfo = new DAL.BankCredit.ReportMapper().FindByReportID(reportID);

                bool result = ValidateInfos(infoType.InfoTypeId, reportInfo.ReportFileID, metaInfo.MetaCode, info, dataSegmentParagraphCode);

            }
            // 借据编号
            if (info.Key == "H566" || info.Key == "G548")
            {
                jjbh = info.Value;
            }
            //展期金额
            if (metaInfo.MetaCode == 1517)
            {
                //展期金额赋值
                zqje = info.Value;
                //需要获取的借据金额对应的段标识
                string segmentRuleID = "F523";
                //根据还款记录对应的借据信息记录
                int infoid = 11;

                ReportInfo reportInfo = new DAL.BankCredit.ReportMapper().FindByReportID(reportID);
                string s = InfoValueValidate(infoid, reportInfo.ReportFileID, info, jjbh, segmentRuleID);
                if (string.IsNullOrEmpty(s))
                {
                    throw new ApplicationException("未能找到该借据编号对应的借据信息");
                }
                else
                {
                    if (Convert.ToDouble(s) < Convert.ToDouble(info.Value))
                    {
                        throw new ApplicationException("展期金额应小于贷款业务借款中借据金额");
                    }
                }

            }
            //贷款业务展期
            if (infoType.InfoTypeId == 13)
            {
                //展期还款次数
                if (info.Key == "H567")
                {
                    zqcs = info.Value;
                }
                //展期金额
                if (info.Key == "H569")
                {
                    if (zqcs == "1")
                    {

                        ReportInfo reportInfo = new DAL.BankCredit.ReportMapper().FindByReportID(reportID);
                        //jjbh该展期对应的借据编号
                        //借据还款信息记录ID
                        infoType.InfoTypeId = 12;
                        string result = Validate160(infoType.InfoTypeId, reportInfo.ReportFileID, jjbh);
                        if (!string.IsNullOrEmpty(result))
                        {
                            if (Convert.ToDouble(result) != Convert.ToDouble(zqje))
                            {
                                throw new ApplicationException("对于贷款业务展期信息记录，当展期次数为1，同时该展期信息记录的对应的贷款业务借据信息记录下无还款信息记录时，展期金额等于该展期信息记录对应的最新贷款业务借据记录的借据余额");
                            }
                        }

                    }
                    //操作类型为新增
                    if (czType == "1")
                    {
                        //需要获取的展期标志对应的段标识
                        string segmentRuleID = "F532";
                        //根据还款记录对应的借据信息记录
                        int infoid = 11;

                        ReportInfo reportInfo = new DAL.BankCredit.ReportMapper().FindByReportID(reportID);

                        string s = InfoValueValidate(infoid, reportInfo.ReportFileID, info, jjbh, segmentRuleID);
                        if (string.IsNullOrEmpty(s))
                        {
                            throw new ApplicationException("未能找到该借据编号对应的借据信息");
                        }
                        else
                        {
                            if (s == "2")
                            {
                                throw new ApplicationException("当信息记录操作类型为新增时借据信息记录中展期标志必须为‘是’");
                            }
                        }
                    }
                }
            }

            //展期起始时间
            if (info.Key == "H570")
            {
                //需要获取的借据时间对应的段标识
                string segmentRuleID = "F525";
                //根据还款记录对应的借据信息记录
                int infoid = 11;

                ReportInfo reportInfo = new DAL.BankCredit.ReportMapper().FindByReportID(reportID);

                string s = InfoValueValidate(infoid, reportInfo.ReportFileID, info, jjbh, segmentRuleID);
                if (string.IsNullOrEmpty(s))
                {
                    throw new ApplicationException("未能找到该借据编号对应的借据信息");
                }
                else
                {
                    if (Convert.ToDouble(s) > Convert.ToDouble(info.Value))
                    {
                        throw new ApplicationException("展期起始日期不应该小于贷款业务借款中借据放款日期");
                    }
                }

            }
            //借据还款日期
            if (info.Key == "G549")
            {
                //需要获取的借据时间对应的段标识
                string segmentRuleID = "F525";
                //根据还款记录对应的借据信息记录
                int infoid = 11;

                ReportInfo reportInfo = new DAL.BankCredit.ReportMapper().FindByReportID(reportID);

                string s = InfoValueValidate(infoid, reportInfo.ReportFileID, info, jjbh, segmentRuleID);
                if (string.IsNullOrEmpty(s))
                {
                    throw new ApplicationException("未能找到该借据编号对应的借据信息");
                }
                else
                {
                    if (Convert.ToDouble(s) > Convert.ToDouble(info.Value))
                    {
                        throw new ApplicationException("还款日期不应该小于贷款业务借款中借据放款日期");
                    }
                }

            }
            //TODO 增加 163中的还款信息记录中的业务发生时间和借据信息中的业务发生日期的校验
            return true;
        }

        /// <summary>
        /// 160规则校验
        /// </summary>
        /// <param name="infoTypeId">还款信息记录ID</param>
        /// <param name="fileID">该展期对应的报文文件ID</param>
        /// <param name="value">展期信息记录中对应的借据编号</param>
        /// <returns></returns>
        public string Validate160(int infoTypeId, int fileID, string value)
        {
            string result = string.Empty;
            List<ReportInfo> reportList = new Report().List(fileID);
            var list = new List<string>();
            List<Dictionary<string, string>> ListDic = new List<Dictionary<string, string>>();
            foreach (var reportInfo in reportList)
            {
                // 获取信息记录集合
                List<InformationRecordInfo> informationRecordList = new DAL.BankCredit.InformationRecordMapper().FindInformationListByInfoTypeIdAndReportId(infoTypeId, reportInfo.ReportID);
                // 该展期信息记录对应的业务借据信息记录下无还款信息记录时
                if (informationRecordList == null)
                {
                    //借据信息记录ID
                    int typeId = 11;
                    //获取借据信息中借据余额（groupId表示段标识）
                    string groupId = "F524";
                    List<InformationRecordInfo> informationRecord = new DAL.BankCredit.InformationRecordMapper().FindInformationListByInfoTypeIdAndReportId(typeId, reportInfo.ReportID);
                    if (informationRecord != null)
                    {
                        foreach (var infoRecord in informationRecord)
                        {
                            bool findResult = new CommonUtil().FindInfo(infoRecord.Context, value);
                            if (findResult)
                            {
                                result = new CommonUtil().GetValue(infoRecord.Context, groupId);
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 根据信息记录ID和需要校验的值查询另一个信息若存在则查询存在信息记录中某个值
        /// </summary>
        /// yand    16。09.27
        /// <param name="infoTypeID">信息记录ID</param>
        /// <param name="value">校验条件</param>
        /// <param name="value2">校验条件2</param>
        /// <param name="segmentRuleID">需要获取的字段值</param>
        /// <returns></returns>
        public string InfoValueValidate(int infoTypeID, int fileId, KeyValuePair<string, string> value, string value2, string segmentRuleID)
        {
            string result = string.Empty;
            List<ReportInfo> reportList = new Report().List(fileId);
            var list = new List<string>();
            List<Dictionary<string, string>> ListDic = new List<Dictionary<string, string>>();

            foreach (var reportInfo in reportList)
            {
                // 获取报文文件下该类型的信息记录集合
                List<InformationRecordInfo> informationRecordList = new DAL.BankCredit.InformationRecordMapper().FindInformationListByInfoTypeIdAndReportId(infoTypeID, reportInfo.ReportID);
                if (informationRecordList != null)
                {
                    foreach (var informationRecord in informationRecordList)
                    {
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        // JSON 字符串
                        var content = informationRecord.Context;
                        var infoTypeId = informationRecord.InfoTypeID;
                        // 根据查询条件查询是否存在该条件对应的记录
                        bool findResult = new CommonUtil().FindInfo(content, value2);
                        if (findResult)
                        {
                            //借据放款日期
                            result = new CommonUtil().GetValue(content, segmentRuleID);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 查找报文文件下面含有该数据元对应的值
        /// </summary>
        /// yand   16.09.27
        /// <param name="typeId">信息记录ID</param>
        /// <param name="fileId">报文文件ID</param>
        /// <param name="metaCode">需要获取数据元对应的值</param>
        /// <param name="dataSegmentParagraphCode">数据段标识</param>
        /// <returns></returns>
        public List<string> Dictionary(int typeId, int fileId, int metaCode, string dataSegmentParagraphCode)
        {
            List<ReportInfo> reportList = new Report().List(fileId);
            var list = new List<string>();
            List<Dictionary<string, string>> ListDic = new List<Dictionary<string, string>>();
            foreach (var reportInfo in reportList)
            {
                // 获取报文文件下该类型的信息记录集合
                List<InformationRecordInfo> informationRecordList = new DAL.BankCredit.InformationRecordMapper().FindInformationListByInfoTypeIdAndReportId(typeId, reportInfo.ReportID);

                if (informationRecordList != null)
                {
                    foreach (var informationRecord in informationRecordList)
                    {
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        // JSON 字符串
                        var content = informationRecord.Context;
                        var infoTypeId = informationRecord.InfoTypeID;
                        // 根据信息记录类型ID和数据元ID获取数据段规则实体
                        var segmentRulesInfo = new SegmentRules().GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeId, metaCode, dataSegmentParagraphCode);

                        // 获取信息记录中数据段中数据元规则对应的值
                        var temp = new CommonUtil().GetValues(content, dataSegmentParagraphCode, segmentRulesInfo.SegmentRulesId.ToString());
                        list.Add(temp);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 用于补位
        /// </summary>
        /// yand    16.07.15 测试补充没有的字段
        /// <param name="infoType"></param>
        /// <param name="messageInfo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public MessageInfo DataAndRuleCompare1(InfoTypeInfo infoType, MessageInfo messageInfo, ref string message)
        {
            message = string.Empty;

            PropertyInfo[] ps = messageInfo.GetType().GetProperties();

            foreach (PropertyInfo pi in ps)
            {
                List<Dictionary<string, string>> list = (List<Dictionary<string, string>>)pi.GetValue(messageInfo);
                List<DataSegmentInfo> dataSegmentList = infoType.DataSegmentList;
                if (dataSegmentList != null)
                {
                    foreach (DataSegmentInfo dataSegmentInfo in dataSegmentList)
                    {
                        List<SegmentRulesInfo> segmentRulesList = dataSegmentInfo.SegmnetRulesList;

                        foreach (SegmentRulesInfo segmentRulesInfo in segmentRulesList)
                        {
                            MetaInfo metaInfo = segmentRulesInfo.MetaInfo;

                            if (list != null)
                            {
                                foreach (Dictionary<string, string> dic in list)
                                {
                                    if (pi.Name == dataSegmentInfo.ParagraphCode)
                                    {
                                        // 段标识
                                        if (metaInfo.MetaCode == 8105 || metaInfo.MetaCode == 7543)
                                        {
                                            dic.Add(dataSegmentInfo.ParagraphCode + segmentRulesInfo.SegmentRulesId, dataSegmentInfo.ParagraphCode);
                                        }

                                        // 信息记录长度
                                        else if (metaInfo.MetaCode == 8103 || metaInfo.MetaCode == 4501)
                                        {
                                            dic.Add(dataSegmentInfo.ParagraphCode + segmentRulesInfo.SegmentRulesId, "0");
                                        }

                                        //// 个人金融机构代码
                                        //else if (metaInfo.MetaCode == 6101)
                                        //{
                                        //    dic.Add(dataSegmentInfo.ParagraphCode + segmentRulesInfo.SegmentRulesId, "B10211000H0001");
                                        //}

                                        // 企业金融机构代码
                                        else if (metaInfo.MetaCode == 6501)
                                        {
                                            dic.Add(dataSegmentInfo.ParagraphCode + segmentRulesInfo.SegmentRulesId, "33207991216");
                                        }

                                        // 企业审计时间
                                        else if (metaInfo.MetaCode == 2589)
                                        {
                                            dic.Add(dataSegmentInfo.ParagraphCode + segmentRulesInfo.SegmentRulesId, DateTime.Now.ToString("yyyyMMdd"));
                                        }

                                        // 业务号
                                        //else if (metaInfo.MetaCode == 7101)
                                        //{
                                        //    dic.Add(dataSegmentInfo.ParagraphCode + segmentRulesInfo.SegmentRulesId, "999123123123999");
                                        //}

                                        // 信息记录跟踪编号
                                        else if (metaInfo.MetaCode == 7641)
                                        {
                                            dic.Add(dataSegmentInfo.ParagraphCode + segmentRulesInfo.SegmentRulesId, "00000000000000000000");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return messageInfo;
        }

        /// <summary>
        /// 校验数据类型
        /// </summary>
        /// yaoy    16.06.01
        /// <param name="metaInfo"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool VarificationData(MetaInfo metaInfo, string value)
        {
            char[] temp = value.ToCharArray();

            if (metaInfo.DataType == "N")
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] < 0X30 || temp[i] > 0X39)
                    {
                        return false;
                    }
                }
            }

            if (metaInfo.DataType == "AN")
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] < 0X20 || temp[i] > 0X7E)
                    {
                        return false;
                    }
                }
            }

            if (metaInfo.DataType == "ANC")
            {
                return true;
            }

            return true;
        }

        /// <summary>
        /// 补位
        /// </summary>
        /// yaoy    16.06.01
        /// yand    16.08.02 修改
        /// <param name="metaInfo"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ComplementBits(MetaInfo metaInfo, string value)
        {
            int GBlength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(value);//用于获取字符串转换成GB2312的长度
            int EncLength = value.Length;
            if (metaInfo != null)
            {
                MetaComponentsInfo metaComponentsInfo = new DataRule().GetMetaComponentsInfoByCode(metaInfo.MetaCode);

                // 特殊时间控件
                if (metaComponentsInfo.HtmlElementId == 9)
                {
                    var length = metaInfo.DatasLength;

                    if (length == 8)
                    {
                        value = DateTime.Now.ToString("yyyyMMdd");
                    }
                    if (length == 14)
                    {
                        value = DateTime.Now.ToString("yyyyMMddHHmmss");
                    }
                }

                //经营场地所有权、借款人成立年份、四级分类
                if ((metaInfo.MetaCode == 2503 || metaInfo.MetaCode == 8503|| metaInfo.MetaCode== 7539) && string.IsNullOrEmpty(value))
                {
                    value = value.PadLeft(metaInfo.DatasLength, ' ');
                }
                switch (metaInfo.DataType)
                {
                    case "N":
                        value = value.PadLeft(metaInfo.DatasLength, '0');
                        value = value.Substring(GBlength - EncLength, value.Length);
                        break;

                    case "AN":
                        value = value.PadRight(metaInfo.DatasLength, ' ');
                        value = value.Substring(0, value.Length - (GBlength - EncLength));
                        break;

                    case "ANC":
                        value = value.PadRight(metaInfo.DatasLength, ' ');
                        value = value.Substring(0, value.Length - (GBlength - EncLength));
                        break;

                    default:
                        return null;
                }
            }

            return value;
        }

        /// <summary>
        /// 封装信息类型报文
        /// </summary>
        /// yaoy    16.06.01
        /// yand    16.07.15(修改)
        /// <returns></returns>
        public string EncapsulateData(InfoTypeInfo infoTypeInfo, string content)
        {
            string result = string.Empty;
            StringBuilder sb = new StringBuilder();
            MessageInfo messageInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageInfo>(content);
            PropertyInfo[] ps = messageInfo.GetType().GetProperties();

            // 获取数据段列表
            List<DataSegmentInfo> dataSegmentList = infoTypeInfo.DataSegmentList;
            foreach (PropertyInfo pi in ps)
            {
                foreach (DataSegmentInfo dataSegment in dataSegmentList)
                {
                    // 获取数据段规则集合
                    List<SegmentRulesInfo> segmentRulesList = dataSegment.SegmnetRulesList;

                    // 获取段
                    List<Dictionary<string, string>> list = (List<Dictionary<string, string>>)pi.GetValue(messageInfo);

                    if (list != null)
                    {
                        foreach (Dictionary<string, string> dic in list)
                        {
                            foreach (SegmentRulesInfo segmentRules in segmentRulesList)
                            {
                                foreach (var info in dic)
                                {
                                    if (segmentRules != null)
                                    {
                                        // 获取数据元实体
                                        MetaInfo metaInfo = segmentRules.MetaInfo;

                                        // 判断前端传的Key值与数据段Code值和该数据段下的数据段规则Id值是否相等
                                        if (info.Key == dataSegment.ParagraphCode + segmentRules.SegmentRulesId.ToString())
                                        {

                                            // 判断前端传的Value值长度小于或等于元数据长度
                                            if (System.Text.Encoding.GetEncoding("GB2312").GetByteCount(info.Value) <= metaInfo.DatasLength)
                                            {
                                                sb.Append(ComplementBits(metaInfo, info.Value));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return sb.ToString();
        }
    }
}
