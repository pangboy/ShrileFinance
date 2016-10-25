using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit.Validates
{
    /// <summary>
    /// 通用校验方法
    /// yaoy    16.09.27
    /// </summary>
    public class ValidateUtil
    {
        /// <summary>
        /// 校验Value是否重复
        /// </summary>
        /// yaoy    16.09.26
        /// <param name="messageInfo"></param>
        /// <param name="infoTypeId"></param>
        /// <param name="metaCode"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool RepeatValidate(MessageInfo messageInfo, int infoTypeId, int metaCode, string code)
        {
            var temp = new List<string>();
            // 获取合同段所有字典类型数据
            var list = GetList(messageInfo, code);
            // 数据段实体
            var dataSegmentInfo = new DataSegment().GetByInfoTypeIdAndCode(infoTypeId, code);
            // 数据元实体
            var metaInfo = new Meta().Find(metaCode);
            // 数据段规则实体
            var segmentRulesInfo = new SegmentRules().GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeId, metaCode, code);

            var tmp = code + segmentRulesInfo.SegmentRulesId.ToString();

            if (list != null)
            {
                foreach (var dic in list)
                {
                    if (dic.ContainsKey(tmp))
                    {
                        // 判断集合中是否存在该值，不存在则添加至集合
                        if (!IsContains(temp, dic[tmp]))
                        {
                            temp.Add(dic[tmp]);
                        }

                        else
                        {
                            throw new ApplicationException(dataSegmentInfo.ParagraphName + metaInfo.Name + "出现重复！");
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 关联性性校验
        /// </summary>
        /// yaoy    16.09.27
        /// <param name="messageInfo"></param>
        /// <param name="infoTypeId"></param>
        /// <param name="metaCode"></param>
        /// <param name="code"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public bool RelevanceValidate(MessageInfo messageInfo, int infoTypeId, int[] metaCode, string code, string[] value1, string[] value2)
        {
            var result = true;

            var dataSegmentInfo = new DataSegment().GetByInfoTypeIdAndCode(infoTypeId, code);
            var metaInfo = new Meta().Find(metaCode[1]);

            var segmentRulesInfo1 = new SegmentRules().GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeId, metaCode[0], code);
            var segmentRulesInfo2 = new SegmentRules().GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeId, metaCode[1], code);

            if (segmentRulesInfo1 != null)
            {
                var temp1 = GetValues(messageInfo, code, segmentRulesInfo1.SegmentRulesId.ToString());

                // 判断第一个值取值范围是否在预期范围中
                if (value1.Contains(temp1))
                {
                    if (segmentRulesInfo2 != null)
                    {
                        var temp2 = GetValues(messageInfo, code, segmentRulesInfo2.SegmentRulesId.ToString());

                        // 限定第二个值的取值范围
                        result &= value2.Contains(temp2);

                        if (!result)
                        {
                            throw new ApplicationException(dataSegmentInfo.ParagraphName + metaInfo.Name + "不在预期范围内！");
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 验证两个数据段之间关系
        /// </summary>
        /// yaoy    16.09.22
        /// <param name="infoTypeId"></param>
        /// <param name="messageInfo"></param>
        /// <returns></returns>
        public bool RelationValidate(int infoTypeId, MessageInfo messageInfo)
        {
            bool result = true;

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            // 根据信息类型ID获取所有需要校验的规则
            List<SegmentRuleRelationInfo> segmentRuleRelationList = new SegmentRuleRelation().GetByInfoTypeId(infoTypeId);

            if (segmentRuleRelationList.Count > 0)
            {
                // 将所以需要校验的数据全部添加到字典类型中
                foreach (var segmentRuleRelationInfo in segmentRuleRelationList)
                {
                    if (!dictionary.ContainsKey(segmentRuleRelationInfo.FirstSegmentRuleId.ToString()))
                    {
                        dictionary.Add(segmentRuleRelationInfo.FirstSegmentRuleId.ToString(), string.Empty);
                    }
                    if (!dictionary.ContainsKey(segmentRuleRelationInfo.SecondSegmentRuleId.ToString()))
                    {
                        dictionary.Add(segmentRuleRelationInfo.SecondSegmentRuleId.ToString(), string.Empty);
                    }
                }

                PropertyInfo[] ps = messageInfo.GetType().GetProperties();

                foreach (PropertyInfo pi in ps)
                {
                    List<Dictionary<string, string>> listDic = (List<Dictionary<string, string>>)pi.GetValue(messageInfo);

                    if (listDic != null)
                    {
                        foreach (Dictionary<string, string> dic in listDic)
                        {
                            foreach (var info in dic)
                            {
                                if (dictionary.ContainsKey(info.Key.ToString().Substring(1, info.Key.Length - 1)))
                                {
                                    dictionary[info.Key.ToString().Substring(1, info.Key.Length - 1)] = info.Value;
                                }
                            }
                        }
                    }
                }
            }
            // 将取出的数据进行规则校验
            foreach (var item in segmentRuleRelationList)
            {
                string relation = string.Empty;
                var dataSegmentInfo1 = new DataSegment().GetByInfoTypeIdAndSegmentRulesId(infoTypeId, item.FirstSegmentRuleId);
                var metaInfo1 = new Meta().GetByInfoTypeIdAndSegmentRulesId(infoTypeId, item.FirstSegmentRuleId);

                var dataSegmentInfo2 = new DataSegment().GetByInfoTypeIdAndSegmentRulesId(infoTypeId, item.SecondSegmentRuleId);
                var metaInfo2 = new Meta().GetByInfoTypeIdAndSegmentRulesId(infoTypeId, item.SecondSegmentRuleId);

                switch (item.SegmentRelation)
                {
                    case ">=":
                        relation = "大于或等于";
                        result &= Convert.ToDouble(dictionary[item.FirstSegmentRuleId.ToString()] == "" ? "0" : dictionary[item.FirstSegmentRuleId.ToString()])
                               >= Convert.ToDouble(dictionary[item.SecondSegmentRuleId.ToString()] == "" ? "0" : dictionary[item.SecondSegmentRuleId.ToString()]);
                        break;
                    case "<=":
                        relation = "小于或等于";
                        result &= Convert.ToDouble(dictionary[item.FirstSegmentRuleId.ToString()] == "" ? "0" : dictionary[item.FirstSegmentRuleId.ToString()])
                               <= Convert.ToDouble(dictionary[item.SecondSegmentRuleId.ToString()] == "" ? "0" : dictionary[item.SecondSegmentRuleId.ToString()]);
                        break;
                    case "!=":
                        relation = "不等于";
                        if (dictionary[item.FirstSegmentRuleId.ToString()] != "" && dictionary[item.SecondSegmentRuleId.ToString()] != "")
                        {
                            result &= dictionary[item.FirstSegmentRuleId.ToString()] != dictionary[item.SecondSegmentRuleId.ToString()];
                        }
                        break;
                    case "!=!":
                        if (!(dictionary[item.FirstSegmentRuleId.ToString()] == string.Empty && dictionary[item.SecondSegmentRuleId.ToString()] == string.Empty)
                            || (dictionary[item.FirstSegmentRuleId.ToString()] != string.Empty && dictionary[item.SecondSegmentRuleId.ToString()] != string.Empty)
                            )
                        {
                            throw new ApplicationException(dataSegmentInfo1.ParagraphName + metaInfo1.Name + "和" +
                                dataSegmentInfo2.ParagraphName + metaInfo2.Name + "必须同时为空或者同时不为空！");

                        }
                        break;
                    default:
                        break;
                }

                if (!result)
                {
                    throw new ApplicationException(dataSegmentInfo1.ParagraphName + metaInfo1.Name + relation + dataSegmentInfo2.ParagraphName + metaInfo2.Name);
                }
            }

            return result;
        }

        /// <summary>
        /// 判断所有数据规则段出现的次数
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="infoTypeId"></param>
        /// <param name="messageInfo"></param>
        /// <returns></returns>
        public bool TimesValidate(int infoTypeId, MessageInfo messageInfo)
        {
            bool result = true;
            // 根据信息类型ID获取所有数据段
            List<DataSegmentInfo> dataSegmentList = new DataSegment().GetByInfoTypeId(infoTypeId);

            PropertyInfo[] ps = messageInfo.GetType().GetProperties();

            foreach (PropertyInfo pi in ps)
            {
                List<Dictionary<string, string>> list = (List<Dictionary<string, string>>)pi.GetValue(messageInfo);

                // list集合不为空且段名称包含在数据段集合中
                if (list != null && dataSegmentList.Select(m => m.ParagraphCode).Contains(pi.Name))
                {
                    // 异常情况描述
                    var temp = string.Empty;

                    //根据信息类型ID和段编码获取实体
                    DataSegmentInfo dataSegmentInfo = new DataSegment().GetByInfoTypeIdAndCode(infoTypeId, pi.Name);

                    switch (dataSegmentInfo.times)
                    {
                        case "1:1":
                            temp = "次数为一";
                            result &= list.Count() == 1;
                            break;
                        case "1:n":
                            temp = "次数大于等于一";
                            result &= list.Count() >= 1;
                            break;
                        case "0:1":
                            temp = "次数小于等于一";
                            result &= list.Count() <= 1;
                            break;
                        default:
                            break;
                    }

                    if (!result)
                    {
                        throw new ApplicationException(dataSegmentInfo.ParagraphName + "必须满足" + temp);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 获取信息记录特定段出现的次数
        /// </summary>
        /// yaoy    16.09.23
        /// <param name="messageInfo"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public int GetTimes(MessageInfo messageInfo, string code)
        {
            var times = 0;

            PropertyInfo[] ps = messageInfo.GetType().GetProperties();

            foreach (PropertyInfo pi in ps)
            {
                if (pi.Name == code)
                {
                    List<Dictionary<string, string>> list = (List<Dictionary<string, string>>)pi.GetValue(messageInfo);

                    times = list == null ? 0 : list.Count();
                }
            }

            return times;
        }

        /// <summary>
        /// 获取特定数据段中数据源规则ID对应的值
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="messageInfo"></param>
        /// <param name="dataSegmentCode"></param>
        /// <param name="segmentRulesId"></param>
        /// <returns></returns>
        public string GetValues(MessageInfo messageInfo, string dataSegmentCode, string segmentRulesId)
        {
            PropertyInfo[] ps = messageInfo.GetType().GetProperties();

            foreach (PropertyInfo pi in ps)
            {
                if (pi.Name == dataSegmentCode)
                {
                    List<Dictionary<string, string>> list = (List<Dictionary<string, string>>)pi.GetValue(messageInfo);

                    if (list != null)
                    {
                        foreach (Dictionary<string, string> dic in list)
                        {
                            foreach (var info in dic)
                            {
                                if (info.Key == dataSegmentCode + segmentRulesId)
                                {
                                    return info.Value;
                                }
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取信息记录字段中数据段数据
        /// </summary>
        /// yaoy    16.09.23  
        /// <param name="messageInfo"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> GetList(MessageInfo messageInfo, string code)
        {
            var list = new List<Dictionary<string, string>>();

            PropertyInfo[] ps = messageInfo.GetType().GetProperties();

            foreach (PropertyInfo pi in ps)
            {
                if (pi.Name == code)
                {
                    return (List<Dictionary<string, string>>)pi.GetValue(messageInfo);
                }
            }

            return list;
        }

        /// <summary>
        /// 一次性获取数据段中所有Value
        /// </summary>
        /// yaoy    16.09.26
        /// <param name="messageInfo"></param>
        /// <param name="dataSegmentCode"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetAllValues(MessageInfo messageInfo, string dataSegmentCode, Dictionary<string, string> dic)
        {
            var lists = new List<string>();

            foreach (var item in dic)
            {
                lists.Add(item.Key);
            }

            PropertyInfo[] ps = messageInfo.GetType().GetProperties();

            foreach (PropertyInfo pi in ps)
            {
                if (pi.Name == dataSegmentCode)
                {
                    var list = (List<Dictionary<string, string>>)pi.GetValue(messageInfo);

                    foreach (var item in list)
                    {
                        foreach (var temp in item)
                        {
                            if (lists.Contains(temp.Key))
                            {
                                dic[temp.Key] = temp.Value;
                            }
                        }
                    }
                }
            }

            return dic;
        }

        /// <summary>
        /// 189,190跨信息记录规则校验
        /// </summary>
        /// yaoy    16.09.27
        /// <param name="informationList"></param>
        /// <param name="infoType"></param>
        /// <param name="code"></param>
        /// <param name="metaCode"></param>
        /// <returns></returns>
        public bool Value1Proof(int reportId, MessageInfo messageInfo, int infoTypeId, string code, int metaCode)
        {
            //校验参数
            //var metaCode = 2501;
            //var code = "B";
            //var infoType = new int[] { 18, 17 };

            //var metaCode = 2501;
            //var code = "B";
            //var infoType = new int[] { 19, 17 };

            // 融资业务还款信息记录集合

            var segmentRulesInfo = new SegmentRules().GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeId, metaCode, code);
            var temp1 = GetValues(messageInfo, code, segmentRulesInfo.SegmentRulesId.ToString());
            // 获取不包括本身的所有报文集合
            var reportList = new Report().GetReportList(reportId).Where(m => m.ReportID != reportId).ToList();

            foreach (var reportInfo in reportList)
            {
                var informationList = new InformationRecord().GetByReportId(reportInfo.ReportID);

                if (informationList != null)
                {
                    foreach (var informationRecordInfo in informationList)
                    {
                        MessageInfo messageInfo2 = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageInfo>(informationRecordInfo.Context);

                        var segment = new SegmentRules().GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(informationRecordInfo.InfoTypeID, metaCode, code);

                        var temp2 = GetValues(messageInfo2, code, segment.SegmentRulesId.ToString());

                        if (temp1 != temp2)
                        {
                            throw new ApplicationException("该报文中业务发生时间必须和融资业务信息记录中业务发生时间保持一致！");
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 191,192规则校验
        /// </summary>
        /// yaoy    16.09.27
        /// <param name="infoTypeId"></param>
        /// <param name="messageInfo"></param>
        /// <param name="metaCode"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Value2Proof(MessageInfo messageInfo, int infoTypeId, int metaCode, string[] value)
        {
            var temp = GetList(messageInfo, "C");
            var infoTypeInfo = new InfoType().Get(infoTypeId);
            foreach (var dic in temp)
            {
                var segmentRulesInfo = new SegmentRules().GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeId, metaCode, "C");
                var metaInfo = new Meta().GetByInfoTypeIdAndSegmentRulesId(infoTypeId, segmentRulesInfo.SegmentRulesId);

                if (dic.ContainsKey("C" + segmentRulesInfo.SegmentRulesId.ToString()))
                {
                    if (dic["C" + segmentRulesInfo.SegmentRulesId.ToString()] == "")
                    {
                        if (value.Contains(dic["C" + segmentRulesInfo.SegmentRulesId.ToString()]))
                        {
                            throw new ApplicationException(infoTypeInfo.InfoName + "标识变更段不能包括" + metaInfo.Name);
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 判断字符串值是否在集合中
        /// </summary>
        /// yaoy    16.09.29
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsContains(List<string> list, string value)
        {
            foreach (var item in list)
            {
                if (item == value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
