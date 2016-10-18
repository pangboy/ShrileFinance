using Model.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit.Validates
{
     public class JKRGZValidate:BaseValidate
    {
        private int typeId;
        public JKRGZValidate(int infoTypeId, MessageInfo data) : base(data)
        {
            typeId = infoTypeId;
            Valid(infoTypeId, data);
        }
        public override void Valid(int infoTypeId, MessageInfo data)
        {
            base.Valid(infoTypeId, data);

            // 借款人关注
            if (PData.Segments.Count > 0)
            {
                if (string.IsNullOrEmpty(PData.SegmentRules["D464"]) && Convert.ToInt32(PData.SegmentRules["D464"]) <= 0)
                {
                    throw new ApplicationException("“判决执行金额”必须大于零。");
                }
            }
            
        }

        protected override void GetData(out string[] segments, out string[] segmentRules, out string[] mates)
        {
            string[] segment = new string[] { };
            string[] segmentRule = new string[] { };
            string[] mate = new string[] { };
            if (typeId == 8)
            {
                segment = new string[] { "B", "D" };
                //分别对应D464判决执行金额
                segmentRule = new string[] { "D464" };
                //分别对应1577判决执行金额
                mate = new string[] { "1577" };
            }
            else if (typeId == 9)
            {
                segment = new string[] { "B", "E" };
            }
            segments = segment;
            segmentRules = segmentRule;
            mates = mate;
        }
    }
}
