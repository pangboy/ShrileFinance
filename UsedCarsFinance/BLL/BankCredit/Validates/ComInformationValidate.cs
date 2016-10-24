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
    /// </summary>
    public class ComInformationValidate : BaseValidate
    {
        private MessageInfo data;
        private int infoTypeID;
        private readonly static ValidateUtil validateUtil = new ValidateUtil();

        /// <summary>
        /// 整合校验方法
        /// </summary>
        /// yaoy    16.09.28
        /// <returns></returns>
        public bool BaseValidateMethod()
        {
            bool result = true;

            result &= TimesValidate();
            result &= RepeatValidate();
            result &= RelationValidate();
            result &= RelevanceValidate();
            result &= Validate1Method();

            return result;
        }
        public ComInformationValidate(int infoTypeID, MessageInfo data) : base(data)
        {
            this.infoTypeID = infoTypeID;
            this.data = data;
        }

        /// <summary>
        /// 次数验证
        /// </summary>
        /// yaoy    16.09.27
        /// <returns></returns>
        public bool TimesValidate()
        {
            var code = "B";
            var metaCode = 7511;

            var result = true;
            var segmentRulesInfo = new SegmentRules().GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeID, metaCode, code);

            // 获取信息记录中数据段B段中数据元规则对应的值
            var value = validateUtil.GetValues(data, code, segmentRulesInfo.SegmentRulesId.ToString());

            // 信息记录操作类型不为删除
            if (value != "4")
            {
                result &= validateUtil.TimesValidate(infoTypeID, data);
            }

            return result;
        }

        /// <summary>
        /// 重复性校验
        /// </summary>
        /// yaoy    16.09.27
        /// <param name="metaCode"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool RepeatValidate()
        {
            var result = true;
            var metaCode = 1501;
            // 第一组参数
            var infoType1 = new int[] { 10 };
            var code1 = "E";
            // 第二组参数
            var infoType2 = new int[] { 2 };
            var code2 = "F";

            if (infoType1.Contains(infoTypeID))
            {
                result &= validateUtil.RepeatValidate(data, infoTypeID, metaCode, code1);
            }

            if (infoType2.Contains(infoTypeID))
            {
                result &= validateUtil.RepeatValidate(data, infoTypeID, metaCode, code2);
            }

            return result;
        }

        /// <summary>
        /// 验证两个数据段之间关系
        /// </summary>
        /// yaoy    16.09.27
        /// <returns></returns>
        public bool RelationValidate()
        {
            return validateUtil.RelationValidate(infoTypeID, data);
        }

        /// <summary>
        /// 关联性验证
        /// </summary>
        /// yaoy    16.09.27
        /// <returns></returns>
        public bool RelevanceValidate()
        {
            var result = true;
            // 第一组参数
            var code = "D";
            var metaCode = new int[] { 7549, 7551 };
            var value1 = new string[] { "1", "3" };
            var value2 = new string[] { "2" };

            if (infoTypeID == 14)
            {
                result &= validateUtil.RelevanceValidate(data, infoTypeID, metaCode, code, value1, value2);
            }

            return result;
        }

        /// <summary>
        /// 企业191，192项规则校验
        /// </summary>
        /// yaoy    16.09.28
        /// <returns></returns>
        public bool Validate1Method()
        {
            var result = true;

            var metaCode = 7515;
            //检验参数1
            var infoType1 = new int[] { 14, 17, 18, 19 };
            var value1 = new string[] { "1", "2" };

            //检验参数2
            var infoType2 = new int[] { 18, 19 };
            var value2 = new string[] { "3" };

            if (infoType1.Contains(infoTypeID))
            {
                result &= validateUtil.Value2Proof(data, infoTypeID, metaCode, value1);
            }

            if (infoType2.Contains(infoTypeID))
            {
                result &= validateUtil.Value2Proof(data, infoTypeID, metaCode, value2);
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
