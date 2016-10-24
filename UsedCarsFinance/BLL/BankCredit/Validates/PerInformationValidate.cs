using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.BankCredit;

namespace BLL.BankCredit.Validates
{
    /// <summary>
    /// 企业信息记录级别校验
    /// yaoy    16.09.27
    public class PerInformationValidate : BaseValidate
    {
        private MessageInfo data;
        private int infoTypeID;
        private readonly static ValidateUtil validateUtil = new ValidateUtil();

        public PerInformationValidate(int infoTypeID, MessageInfo data) : base(data)
        {
            this.infoTypeID = infoTypeID;
            this.data = data;
        }

        public class ValidateClass
        {
            public string first { get; set; }
            public string second { get; set; }
            public string third { get; set; }
        }

        /// <summary>
        /// 整合校验方法
        /// </summary>
        /// yaoy    16.09.28
        /// <returns></returns>
        public bool BaseValidateMethod()
        {
            bool result = true;

            result &= TimesValidate();
            result &= ValuesValidate();
            result &= ValueAndTimeVildate();
            result &= Value008Validate();
            //result &= SegmentValidate();
            //result &= Value056Validate();

            return result;
        }

        /// <summary>
        /// 数据段规则校验
        /// </summary>
        /// yaoy    16.09.26
        /// <param name="informationInfo"></param>
        /// <returns></returns>
        public bool SegmentValidate()
        {
            var result = true;

            // 获取数据段规则实体
            var segmentRulesInfo = new SegmentRules().GetSegmentRulesIdByInfoTypeIdAndPosition(infoTypeID);

            // 获取数据段实体
            var dataSegmentInfo = new DataSegment().Get(segmentRulesInfo.BDS_ID);

            result &= validateUtil.GetValues(data, dataSegmentInfo.ParagraphCode, segmentRulesInfo.SegmentRulesId.ToString()) == "A";

            if (!result)
            {
                throw new ApplicationException("信息报文第五位必须为基础信息段标识！");
            }

            return result;
        }

        /// <summary>
        /// 次数验证
        /// </summary>
        /// yaoy    16.09.28
        /// <returns></returns>
        public bool TimesValidate()
        {
            return validateUtil.TimesValidate(infoTypeID, data);
        }

        /// <summary>
        /// 信息记录中对应数据段的值类型校验
        /// </summary>
        /// yaoy    16.09.23
        /// <param name="informationInfo"></param>
        /// <returns></returns>
        public bool ValuesValidate()
        {
            List<ValidateClass> validateList = new List<ValidateClass>();
            List<string> segmentRulesIds = new List<string>();

            // metaCode数组
            int[] str = new int[] { 5101, 5107, 5109 };

            foreach (var item in str)
            {
                var segmentRulesInfo = new SegmentRules().GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeID, item, "E");

                segmentRulesIds.Add("E" + segmentRulesInfo.SegmentRulesId.ToString());
            }

            List<Dictionary<string, string>> list = validateUtil.GetList(data, "E");

            if (list.Count > 1)
            {
                foreach (var item in list)
                {
                    ValidateClass vc = new ValidateClass();

                    var temp = item.Where(m => segmentRulesIds.Contains(m.Key)).ToArray();

                    vc.first = temp[0].Value;
                    vc.second = temp[1].Value;
                    vc.third = temp[2].Value;

                    validateList.Add(vc);
                }
            }

            if (validateList.Count > 0)
            {
                for (int i = 0; i < validateList.Count; i++)
                {
                    for (int j = i + 1; j < validateList.Count; j++)
                    {
                        if (validateList[i].first == validateList[j].first
                            && validateList[i].second == validateList[j].second
                            && validateList[i].third == validateList[j].third)
                        {
                            throw new ApplicationException("任意两个担保信息段的姓名、证件类型、证件号码不能完全相同");
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 根据数据段出现次数校验其他段中数据段规则对应的Value
        /// </summary>
        /// yaoy    16.09.26
        /// <param name="informationInfo"></param>
        /// <returns></returns>
        public bool ValueAndTimeVildate()
        {
            bool result = true;
            var segment = new SegmentRules();
            var dic = new Dictionary<string, string>();
            var dictionary = new Dictionary<string, string>();

            // 获取标识变更段出现次数
            var time = validateUtil.GetTimes(data, "F");

            if (time > 0)
            {
                var arr = new int[] { 6101, 7101 };

                for (int i = 0; i < arr.Length; i++)
                {
                    var segmentRulesInfo1 = segment.GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeID, arr[i], "A");
                    var segmentRulesInfo2 = segment.GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeID, arr[i], "F");

                    dic.Add("A" + segmentRulesInfo1.SegmentRulesId.ToString(), string.Empty);
                    dictionary.Add("F" + segmentRulesInfo2.SegmentRulesId.ToString(), string.Empty);
                }

                dic = validateUtil.GetAllValues(data, "A", dic);
                dictionary = validateUtil.GetAllValues(data, "F", dictionary);

                foreach (var item in dic)
                {
                    foreach (var temp in dictionary)
                    {
                        if (item.Key == temp.Key && item.Value == temp.Value)
                        {
                            throw new ApplicationException("交易标识变更段中 金融机构代码 + 业务号 不能和基础段中 金融机构代码 + 业务号相同");
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 个人单独校验方法
        /// </summary>
        /// yaoy    16.09.27
        /// <returns></returns>
        public bool Value008Validate()
        {
            var result = true;

            var infoTypeInfo = new InfoType().Get(infoTypeID);
            var segmentRulesInfo = new SegmentRules().GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeID, 7121, "A");
            var temp = validateUtil.GetValues(data, "A", segmentRulesInfo.SegmentRulesId.ToString());

            if (temp == "2")
            {
                var times = validateUtil.GetTimes(data, "F");

                if (times > 0)
                {
                    throw new ApplicationException("新账户开立信息记录不能包含交易标识变更段！");
                }

                var times1 = validateUtil.GetTimes(data, "B");
                var times2 = validateUtil.GetTimes(data, "C");
                var times3 = validateUtil.GetTimes(data, "D");

                if (!(times1 > 0 && times2 > 0 && times3 > 0))
                {
                    throw new ApplicationException("新账户开立信息账户记录必须包括身份信息段、职业信息段、居住地址段!");
                }
            }

            return result;
        }

        /// <summary>
        /// 个人单独校验方法
        /// </summary>
        /// yaoy    16.09.27
        public bool Value056Validate()
        {
            var result = true;
            int metaCode = 8105;

            // 根据信息记录类型获取数据段集合
            var dataSegmentList = new DataSegment().GetByInfoTypeId(infoTypeID);

            // 根据数据元获取字典编码集合
            var dicList = new string[] { "A", "B", "C", "D", "E", "F", "G", "" };

            foreach (var dataSegmentInfo in dataSegmentList)
            {
                // 根据信息类型和元数据以及数据段名称获取数据段规则
                var segmentRulesInfo = new SegmentRules().GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeID, metaCode, dataSegmentInfo.ParagraphCode);

                // 根据数据段和数据段规则ID获取特定的值
                var value = validateUtil.GetValues(data, dataSegmentInfo.ParagraphCode, segmentRulesInfo.SegmentRulesId.ToString());

                //value值不在数据字典的集合中
                if (!dicList.Contains(value))
                {
                    throw new ApplicationException("信息记录类型的值不在数据字典的集合中!");
                }
            }

            return result;
        }

        protected override void GetData(out string[] segments, out string[] segmentRules, out string[] mates)
        {
            segments = new string[] { };
            segmentRules = new string[] { };
            mates = new string[] { };
        }
    }
}
