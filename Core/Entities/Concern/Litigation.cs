using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Entities.Concern
{
    public class Litigation
    {
        /// <summary>
        /// 被起诉流水号
        /// </summary>
        public string ChargedSerialNumber { get; set; }

        /// <summary>
        /// 起诉人姓名
        /// </summary>
        public string ProsecuteName { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 判决执行金额
        /// </summary>
        public string Money { get; set; }

        /// <summary>
        /// 判决执行日期
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// 执行结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 被起诉原因
        /// </summary>
        public string Reason { get; set; }
    }
}