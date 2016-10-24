using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit.Validates
{
    public class JKRZBValidate : BaseValidate
    {
        //借款人资本信息记录
        public JKRZBValidate(int infoTypeId,MessageInfo data) : base(data)
        {
            Valid(infoTypeId,data);
        }

        public override void Valid(int infoTypeId, MessageInfo data)
        {
            base.Valid(infoTypeId,data);
            //存在出资资本情况段
            if(data.E.Count > 0)
            {
                //if (string.IsNullOrEmpty(PData.SegmentRules["E69"]) && string.IsNullOrEmpty(PData.SegmentRules["E67"]) && string.IsNullOrEmpty(PData.SegmentRules["E70"]))
                //{
                //    throw new ApplicationException("出资资本情况段“织机构代码”和“贷款卡编码”和”注册登记号“不能同时为空。");
                //}
                if ((!string.IsNullOrEmpty(PData.SegmentRules["E71"]) && string.IsNullOrEmpty(PData.SegmentRules["E72"]))|| (string.IsNullOrEmpty(PData.SegmentRules["E71"]) && !string.IsNullOrEmpty(PData.SegmentRules["E72"])))
                {
                    throw new ApplicationException("出资资本情况段证件类型和证件号码必须成对出现。");
                }
                else
                {
                    if (PData.SegmentRules["E71"] == "0")
                    {
                        //身份证校验
                        if (System.Text.RegularExpressions.Regex.IsMatch(PData.SegmentRules["E72"], @"(^\d{18}$)|(^\d{15}$)") == false)
                        {
                            throw new ApplicationException("出资资本情况段身份证格式不对");
                        }
                    }
                }
                if ((!string.IsNullOrEmpty(PData.SegmentRules["E73"]) && string.IsNullOrEmpty(PData.SegmentRules["E74"]))|| (string.IsNullOrEmpty(PData.SegmentRules["E73"]) && !string.IsNullOrEmpty(PData.SegmentRules["E74"])))
                {
                    throw new ApplicationException("出资资本情况段币种和出资金额必须成对出现。");
                }
            }
            //存在对外投资段
            if (data.F.Count > 0)
            {
                if (string.IsNullOrEmpty(PData.SegmentRules["F78"]) && string.IsNullOrEmpty(PData.SegmentRules["F77"]))
                {
                    throw new ApplicationException("对外投资段组织机构代码和贷款卡编码不能同时为空。");
                }
                if ((!string.IsNullOrEmpty(PData.SegmentRules["F79"]) && string.IsNullOrEmpty(PData.SegmentRules["F81"]))|| (string.IsNullOrEmpty(PData.SegmentRules["F82"]) && !string.IsNullOrEmpty(PData.SegmentRules["F83"])&& (string.IsNullOrEmpty(PData.SegmentRules["F85"]) || string.IsNullOrEmpty(PData.SegmentRules["F86"]))))
                {
                    throw new ApplicationException("对外投资段币种和出资金额必须成对出现。");
                }
            }
            //存在集团公司段
            if (data.G.Count > 0)
            {
                if (string.IsNullOrEmpty(PData.SegmentRules["G89"]) && string.IsNullOrEmpty(PData.SegmentRules["G90"]))
                {
                    throw new ApplicationException("集团公司段中组织机构代码和贷款卡编码不能同时为空。");
                }
            }
            if (data.I.Count > 0)
            {
                if ((!string.IsNullOrEmpty(PData.SegmentRules["I103"]) && string.IsNullOrEmpty(PData.SegmentRules["I104"]))||(string.IsNullOrEmpty(PData.SegmentRules["I103"]) &&!string.IsNullOrEmpty(PData.SegmentRules["I104"])))
                {
                    throw new ApplicationException("法人代表家族段中的证件类型和证件号码必须成对出现。");
                }
            }
            if ((string.IsNullOrEmpty(PData.SegmentRules["H93"]) &&!string.IsNullOrEmpty(PData.SegmentRules["H94"]))|| (!string.IsNullOrEmpty(PData.SegmentRules["H93"]) && string.IsNullOrEmpty(PData.SegmentRules["H94"])))
            {
                throw new ApplicationException("高级管理员情况段证件类型和证件号码必须成对出现。");
            }
            else
            {
                if (PData.SegmentRules["H93"] == "0")
                {
                    //身份证校验
                    if (System.Text.RegularExpressions.Regex.IsMatch(PData.SegmentRules["H94"], @"(^\d{18}$)|(^\d{15}$)") == false)
                    {
                        throw new ApplicationException("高级管理员情况段身份证格式不对");
                    }
                }
                if (PData.SegmentRules["I103"] == "0")
                {
                    //身份证校验
                    if (System.Text.RegularExpressions.Regex.IsMatch(PData.SegmentRules["I104"], @"(^\d{18}$)|(^\d{15}$)") == false)
                    {
                        throw new ApplicationException("法人代表家族段身份证格式不对");
                    }
                }
            }
            if ((string.IsNullOrEmpty(PData.SegmentRules["D64"])&& !string.IsNullOrEmpty(PData.SegmentRules["D63"]))|| (!string.IsNullOrEmpty(PData.SegmentRules["D64"]) && string.IsNullOrEmpty(PData.SegmentRules["D63"])))
            {
                throw new ApplicationException("资本注册情况段中“币种”、“金额”必须成对出现。");
            }
        }
        protected override void GetData(out string[] segments, out string[] segmentRules, out string[] mates)
        {
            segments = new string[] { "B", "D" ,"H"};
            //分别对应被投资单位组织机构代码，被投资单位贷款卡编码，E67贷款卡编码,E69组织机构代码,D64注册资金,E74出资金额;E73\F79\F82\F85币种;F81\F83\F86投资金额；E71\H93\I103证件类型;E72\H94\I104证件号码，E70注册登记证号码段规则ID
            segmentRules = new string[] { "F78", "F77", "G89", "G90" ,"D63","D64","E67","E69","E73","E74","F81","F83","F86","F79","F82","F85","E71","H93","I103","E72", "H94", "I104","E70" };
            //分别对应组织机构代码，贷款卡编码,1501币种,1503注册资金,1507出资金额,1509投资金额,1501币种,5511证件类型;5553证件号码,5517注册登记证号码
            mates = new string[] { "6511", "7503","1501","1503","1507","1509","5511","5553","5517"};
        }
    }
}
