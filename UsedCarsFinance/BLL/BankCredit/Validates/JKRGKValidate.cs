using Model.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit.Validates
{
    public class JKRGKValidate : BaseValidate
    {
        //借款人概况信息记录
        public JKRGKValidate(int infoTypeId, MessageInfo data) : base(data)
        {
            Valid(infoTypeId,data);
        }
        public override void Valid(int infoTypeId, MessageInfo data)
        {
            base.Valid(infoTypeId,data);

            // 借款人验证
            if (PData.SegmentRules["D14"] == "CHN")
            {
                if (string.IsNullOrEmpty(PData.SegmentRules["D15"]) || string.IsNullOrEmpty(PData.SegmentRules["D17"]))
                {
                    throw new ApplicationException("“借款人中文名称和组织机构代码”不能同时为空。");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(PData.SegmentRules["D16"]))
                {
                    throw new ApplicationException("“借款人外文名称”不能为空。");
                }
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["D18"]))
            {
                int year = Convert.ToInt32(PData.SegmentRules["D18"]);
                int nowyear = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                if (year > nowyear && year < 0)
                    throw new ApplicationException("“借款人成立年份”必须小于当前年份并且为有效年份。");
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["D28"]))
            {
                if (Convert.ToInt32(PData.SegmentRules["D28"]) <= 0)
                {
                    throw new ApplicationException("“从业人数”必须大于零。");
                }
            }
            if (data.F.Count>0)
            {
                if (PData.SegmentRules["D44"] != "1")
                {
                    throw new ApplicationException("“当股票信息段存在时”上市公司标志必须为是。");
                }
            }
            if (!string.IsNullOrEmpty(PData.Mates["2503"]))
            {
                if (Convert.ToInt32(PData.Mates["2503"]) <= 1900)
                {
                    throw new ApplicationException("“报表年份”必须为有效年份并且大于1900");
                }
            }
        }

        protected override void GetData(out string[] segments, out string[] segmentRules,out string[] mates)
        {
            segments = new string[] { "B", "D" };
            //分别对应借款人国别，借款人中文名称，借款人外文名称,组织机构代码，借款人成立年份,从业人数,上市公司标志对应的段规则ID
            segmentRules = new string[] { "D14", "D15", "D16", "D17", "D18", "D28", "B6","D44"};
            //分别对应借款人国别，借款人中文名称，借款人外文名称,组织机构代码，借款人成立年份,从业人数对应,上市公司标志的数据元编号
            mates = new string[] { "5509", "5505", "5507", "6511", "2503", "4503","7503", "8509" };
        }
    }
}
