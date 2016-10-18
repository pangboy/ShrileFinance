using Model.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit
{
    public class CommonUtil
    {
        /// <summary>
        /// 校验Value是否重复
        /// </summary>
        /// yaoy    16.09.26
        /// <param name="content"></param>
        /// <param name="infoTypeId"></param>
        /// <param name="metaCode"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Value1Validate(string content, int infoTypeId, int metaCode, string code)
        {
            var temp = new List<string>();

            // 获取合同段所有字典类型数据
            var list = GetList(content, code);

            var segmentRulesInfo = new SegmentRules().GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeId, metaCode, code);

            if (list.Count > 0)
            {
                foreach (var dic in list)
                {
                    var tmp = code + segmentRulesInfo.SegmentRulesId.ToString();

                    if (dic.ContainsKey(tmp))
                    {
                        if (!temp.Contains(tmp))
                        {
                            temp.Add(dic[tmp]);
                        }

                        else
                        {
                            return false;
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
        /// <param name="infoTypeId"></param>
        /// <param name="content"></param>
        /// <param name="metaCode"></param>
        /// <param name="code"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public bool Value2Proof(int infoTypeId, string content, int[] metaCode, string code, string[] value1, string[] value2)
        {
            var result = true;

            var segmentRulesInfo1 = new SegmentRules().GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeId, metaCode[0], code);
            var segmentRulesInfo2 = new SegmentRules().GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeId, metaCode[1], code);

            var temp1 = GetValues(content, code, segmentRulesInfo1.SegmentRulesId.ToString());

            if (value1.Contains(temp1))
            {
                var temp2 = GetValues(content, code, segmentRulesInfo2.SegmentRulesId.ToString());

                result &= value2.Contains(temp2);
            }

            return result;
        }

        /// <summary>
        /// 获取特定数据段中数据源规则ID对应的值
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="message"></param>
        /// <param name="dataSegmentCode"></param>
        /// <param name="segmentRulesId"></param>
        public string GetValues(string message, string dataSegmentCode, string segmentRulesId)
        {
            MessageInfo messageInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageInfo>(message);

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
        /// <param name="informationInfo"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> GetList(string content, string code)
        {
            var list = new List<Dictionary<string, string>>();

            MessageInfo messageInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageInfo>(content);

            PropertyInfo[] ps = messageInfo.GetType().GetProperties();

            foreach (PropertyInfo pi in ps)
            {
                if (pi.Name == code)
                {
                    list = (List<Dictionary<string, string>>)pi.GetValue(messageInfo);
                }
            }

            return list;
        }

        /// <summary>
        /// 获取信息记录特定段出现的次数
        /// </summary>
        /// yaoy    16.09.23
        /// <param name="content">信息记录字符串</param>
        /// <param name="code">数据段名称</param>
        /// <returns></returns>
        public int GetTimes(string content, string code)
        {
            var times = 0;

            MessageInfo messageInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageInfo>(content);
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
        /// 验证两个数据段之间关系
        /// </summary>
        /// yaoy    16.09.22
        /// <param name="infoTypeId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ValidateRelation(int infoTypeId, string message)
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

                MessageInfo messageInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageInfo>(message);

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
                switch (item.SegmentRelation)
                {
                    case ">=":
                        result &= Convert.ToInt32(dictionary[item.FirstSegmentRuleId.ToString()]) >= Convert.ToInt32(dictionary[item.SecondSegmentRuleId.ToString()]);
                        break;
                    case "<=":
                        result &= Convert.ToInt32(dictionary[item.FirstSegmentRuleId.ToString()]) <= Convert.ToInt32(dictionary[item.SecondSegmentRuleId.ToString()]);
                        break;
                    case "!=":
                        result &= dictionary[item.FirstSegmentRuleId.ToString()] != dictionary[item.SecondSegmentRuleId.ToString()];
                        break;
                    case "!=!":
                        if (dictionary[item.FirstSegmentRuleId.ToString()] == string.Empty && dictionary[item.SecondSegmentRuleId.ToString()] == string.Empty)
                        {
                        }
                        if (dictionary[item.FirstSegmentRuleId.ToString()] != string.Empty && dictionary[item.SecondSegmentRuleId.ToString()] != string.Empty)
                        {
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// 判断所有数据规则段出现的次数
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="infoTypeId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ValidateTimes(int infoTypeId, string message)
        {
            bool result = true;

            MessageInfo messageInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageInfo>(message);

            PropertyInfo[] ps = messageInfo.GetType().GetProperties();

            foreach (PropertyInfo pi in ps)
            {
                List<Dictionary<string, string>> list = (List<Dictionary<string, string>>)pi.GetValue(messageInfo);

                if (list != null)
                {
                    //根据信息类型ID和段编码获取实体
                    DataSegmentInfo dataSegmentInfo = new DataSegment().GetByInfoTypeIdAndCode(infoTypeId, pi.Name);

                    switch (dataSegmentInfo.times)
                    {
                        case "1:1":
                            result &= list.Count() == 1;
                            break;
                        case "1:n":
                            result &= list.Count() >= 1;
                            break;
                        case "0:1":
                            result &= list.Count() <= 1;
                            break;
                        default:
                            break;
                    }
                }

                if (!result)
                {
                    return false;
                }
            }

            return result;
        }

       
        /// <summary>
        /// 根据查询条件获取该记录中是否存在满足条件的信息
        /// </summary>
        /// yand    16.09.27
        /// <param name="message">json保存的信息记录值</param>
        /// <param name="value">筛选条件</param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public bool FindInfo(string message, string value)
        {
            bool result = false;
            MessageInfo messageInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageInfo>(message);

            PropertyInfo[] ps = messageInfo.GetType().GetProperties();

            foreach (PropertyInfo pi in ps)
            {
                var list = (List<Dictionary<string, string>>)pi.GetValue(messageInfo);

                if (list != null)
                {
                    foreach (var item in list)
                    {
                        foreach (var va in item)
                        {
                            if (va.Value == value)
                            {
                                result = true;
                            }
                        }
                    }
                }
                
            }
            return result;
        }


        /// <summary>
        /// 查询该信息记录中的某个值
        /// </summary>
        /// yand    16.09.27
        /// <param name="message">json信息</param>
        /// <param name="groupId">组合ID（数据段标识+数据段规则ID）</param>
        /// <returns></returns>
        public string GetValue(string message, string groupId)
        {
            string result = string.Empty;
            MessageInfo messageInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageInfo>(message);

            PropertyInfo[] ps = messageInfo.GetType().GetProperties();

            foreach (PropertyInfo pi in ps)
            {
                var list = (List<Dictionary<string, string>>)pi.GetValue(messageInfo);
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        foreach (var va in item)
                        {
                            if (va.Key == groupId)
                            {
                                result = va.Value;
                            }
                        }
                    }
                }
               
            }
            return result;
        }
    }
}
