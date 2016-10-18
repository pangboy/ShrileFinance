using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BankCredit
{
    /// <summary>
    /// 信息记录类型
    /// yaoy    16.07.04
    /// </summary>
    public class InfoTypeInfo
    {
        [Alias("BIT_ID")]
        public int InfoTypeId { get; set; }
        public string InfoCode { get; set; }
        public string InfoName { get; set; }

        [Alias("BMT_ID")]
        public int MessageTypeId { get; set; }
        public List<DataSegmentInfo> DataSegmentList { get; set; }
    }
}
