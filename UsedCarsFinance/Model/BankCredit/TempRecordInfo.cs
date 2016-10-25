using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BankCredit
{
    /// <summary>
    /// 信息草稿实体
    /// yangj   2016.09.21
    /// </summary>
    public class TempRecordInfo
    {
        /// <summary>
        /// 临时数据ID
        /// </summary>
        [Alias("BTI_ID")]
        public int TempInfoId { get; set; }

        /// <summary>
        /// 临时数据内容
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// 信息记录类型ID
        /// </summary>
        [Alias("BIT_ID")]
        public int InfoTypeId { get; set; }

        /// <summary>
        /// 报告ID
        /// </summary>
        public int ReportId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Alias("UI_ID")]
        public int UserId { get; set; }
    }
}
