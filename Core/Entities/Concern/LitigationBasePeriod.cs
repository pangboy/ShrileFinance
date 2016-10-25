using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Entities.Concern
{
    public class LitigationBasePeriod
    {
        /// <summary>
        /// 借款人名称
        /// </summary>
        public string BorrowName { get; set; }

        /// <summary>
        /// 贷款卡编码
        /// </summary>
        public string LoanCardCode { get; set; }

        /// <summary>
        /// 信息记录操作类型
        /// </summary>
        public string InformationOperationType{ get; set; }

        /// <summary>
        /// 业务发生日期
        /// </summary>
        public string BusinessDate { get; set; }
    }
}