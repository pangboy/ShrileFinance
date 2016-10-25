using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.BankCredit.Validates
{
    public class Parameters
    {
        public Dictionary<string, bool> Segments { get; set; }

        public Dictionary<string, string> SegmentRules { get; set; }

        public Dictionary<string, string> Mates { get; set; }
    }

    public abstract class BaseValidate
    {
        protected Parameters PData { get; private set; }

        protected BaseValidate(MessageInfo data)
        {
            string[] segments, segmentRules, mates;

            GetData(out segments, out segmentRules, out mates);

            Find(segments, segmentRules, mates, data);
        }

        protected abstract void GetData(out string[] segments, out string[] segmentRules, out string[] mates);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segments">需要的段标识</param>
        /// <param name="segmentRules">段规则ID</param>
        /// <param name="mates">数据元标识</param>
        protected void Find(string[] segments, string[] segmentRules, string[] mates, MessageInfo data)
        {
            SegmentRulesInfo Rules = new SegmentRulesInfo();
            // 段
            var segs = new Dictionary<string, bool>();
            // 段规则
            var segsRule = new Dictionary<string, string>();
            // 数据元
            var meta = new Dictionary<string, string>();

            //将数据段转换成字典类型并且都设置为False
            segments.ToList().ForEach(m => segs.Add(m, false));

            //修改段属性
            foreach (var item in data.GetType().GetProperties())
            {
                if (segments.Contains(item.Name))
                {
                    segs[item.Name] = true;
                }
            }

            //将数据段规则转换成字典类型并且都设置为False
            segmentRules.ToList().ForEach(m => segsRule.Add(m, null));
            //修改段规则属性
            foreach (var item in data.GetType().GetProperties())
            {
                List<Dictionary<string, string>> list = (List<Dictionary<string, string>>)item.GetValue(data);

                if (list != null)
                {
                    foreach (Dictionary<string, string> dic in list)
                    {
                        foreach (var info in dic)
                            if (segmentRules.Contains(info.Key))
                            {
                                segsRule[info.Key] = info.Value;
                            }
                    }
                }
            }


            //将数据元转换成字典类型并且都设置为False
            mates.ToList().ForEach(m => meta.Add(m, null));
            //修改数据元属性
            foreach (var item in data.GetType().GetProperties())
            {
                List<Dictionary<string, string>> list = (List<Dictionary<string, string>>)item.GetValue(data);

                if (list != null)
                {
                    foreach (Dictionary<string, string> dic in list)
                    {
                        foreach (var info in dic)
                        {
                            Rules = new DAL.BankCredit.SegmentRulesMapper().Find(Convert.ToInt32(info.Key.Substring(1, info.Key.Length - 1)));

                            if (mates.Contains(Rules.MetaCode.ToString()))
                            {
                                meta[Rules.MetaCode.ToString()] = info.Value;
                            }
                        }

                    }
                }
            }

            PData = new Parameters
            {
                Segments = segs,
                SegmentRules = segsRule,
                Mates = meta,
            };
        }

        /// <summary>
        /// 通用验证方法
        /// </summary>
        public virtual void Valid(int infoTypeId, MessageInfo data)
        {
            // 写通用验证 1503注册资金，1507出资金额,1509投资金额,1577判决执行金额,贷款合同金额,1511贷款借据金额,1517展期金额
            //1519叙做金额,1523贴现金额,1525票面金额,1527融资协议金额,1531融资金额,1535开证金额,1539保函金额,1543汇票金额,1545企业授信额度，1101个人授信额度，1547保证金额
            //1549抵押物评估价值,1551抵押金额,1557质押金额,1559垫款金额,1571质押物价值
            string[] money = new string[] { "1503", "1507", "1509", "1577", "1573", "1511", "1517", "1519", "1523", "1525", "1527", "1531", "1535", "1539", "1543", "1545", "1101", "1547", "1549", "1551", "1557", "1559", "1571" };
            //6501企业金融机构代码，6101个人金融机构代码，4511保证金比例,4507还款次数,4509展期次数,5511证件类型，5553证件号码,7503贷款卡编码
            string[] attr = new string[] { "6501", "6101", "4511", "4507", "4509", "5511", "5553", "7503" };


            //币种，金额，时间暂未处理,115错误

            // 判断是否有需要验证的数据
            //if (!PData.Mates.Where(m => money.Contains(m.Key)).Select(m => m.Value).All(m =>Convert.ToDouble(m)> 0))
            //{
            //    //抛出异常信息
            //    throw new ApplicationException("金额>0");
            //}
            foreach (var item in PData.Mates)
            {
                foreach (var temp in money)
                {
                    if (item.Key == temp)
                    {
                        if (!string.IsNullOrEmpty(item.Value) && Convert.ToDouble(item.Value) <= 0)
                        {
                            throw new ApplicationException(item.Key+"金额>0");
                        }
                    }
                }
            }

            for (int i = 0; i < attr.Length; i++)
            {
                foreach (var item in PData.Mates)
                {
                    if (attr[i] == item.Key && (attr[i] == "6501" || attr[i] == "6101"))
                    {
                        if (!string.IsNullOrEmpty(PData.Mates["6501"]) || !string.IsNullOrEmpty(PData.Mates["6101"]))
                        {
                            //校验金融机构代码
                        }
                    }
                    else if (attr[i] == item.Key && attr[i] == "4511")
                    {
                        if (!string.IsNullOrEmpty(PData.Mates["4511"]) && (Convert.ToInt32(PData.Mates["4511"]) <= 0 && Convert.ToInt32(PData.Mates["4511"]) > 100))
                        {
                            throw new ApplicationException("保证金比例在0~100之间");
                        }
                    }
                    else if (attr[i] == item.Key && attr[i] == "4507")
                    {
                        if (!string.IsNullOrEmpty(PData.Mates["4507"]) && Convert.ToInt32(PData.Mates["4507"]) <= 0)
                        {
                            throw new ApplicationException("还款次数>0");
                        }
                    }
                    else if (attr[i] == item.Key && attr[i] == "4509")
                    {
                        if (!string.IsNullOrEmpty(PData.Mates["4509"]) && Convert.ToInt32(PData.Mates["4509"]) <= 0)
                        {
                            throw new ApplicationException("展期次数>0");
                        }
                    }
                    else if ((attr[i] == item.Key && attr[i] == "5511") || (attr[i] == item.Key && attr[i] == "5533"))
                    {
                        if (!string.IsNullOrEmpty(PData.Mates["5511"]) && !string.IsNullOrEmpty(PData.Mates["5553"]))
                        {
                            if (PData.Mates["5511"] == "0")
                            {
                                //身份证校验
                                if (!string.IsNullOrEmpty(PData.Mates["5553"]))
                                {
                                    var reg = Regex.Match(PData.Mates["5553"], @"(^[1-9][0-9]{5}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])[0-9]{3}$)").Groups.Count > 1;
                                    reg |= Regex.Match(PData.Mates["5553"], @"(^[1-9][0-9]{5}((19[0-9]{2})|(200[0-9])|2011)(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])[0-9]{3}[0-9xX]$)").Groups.Count > 1;
                                    if (!reg)
                                    {
                                        throw new ApplicationException("身份证格式不对");
                                    }
                                }
                            }
                        }
                        if ((!string.IsNullOrEmpty(PData.Mates["5511"]) && string.IsNullOrEmpty(PData.Mates["5553"]))||(string.IsNullOrEmpty(PData.Mates["5511"]) && !string.IsNullOrEmpty(PData.Mates["5553"])))
                        {
                            throw new ApplicationException("证件号码和证件类型必须同时出现");
                        }
                    }
                    else if (attr[i] == item.Key && attr[i] == "7503")
                    {
                        if (PData.Mates["7503"] != null)
                        {
                            //贷款卡编码
                        }
                    }
                }
            }
        }
    }


























}
