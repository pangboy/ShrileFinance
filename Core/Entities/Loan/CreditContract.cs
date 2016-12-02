﻿namespace Core.Entities.Loan
{
    using System;
    using System.Collections.Generic;
    using Core.Interfaces;
    using Customers.Enterprise;
    using Exceptions;

    public enum StatusEnum : byte
    {
        生效 = 0,
        失效 = 1,
        未结清 = 2
    }

    public class CreditContract : Entity, IAggregateRoot
    {
        public CreditContract()
        {
            if (EffectiveDate < ExpirationDate)
            {
                throw new ArgumentOutOfRangeAppException(nameof(ExpirationDate), "合同终止日期必须小于生效日期.");
            }

            if (CreditBalance > CreditLimit)
            {
                throw new ArgumentOutOfRangeAppException(nameof(CreditBalance), "授信余额不能大于授信额度.");
            }

            GuarantyContract = new HashSet<GuarantyContract>();
        }

        public Guid OrganizationId { get; set; }

        /// <summary>
        /// 合同编码
        /// </summary>
        public string LoanCode { get; set; }

        /// <summary>
        /// 授信合同生效日期
        /// </summary>
        public DateTime EffectiveDate { get; set; }

        /// <summary>
        /// 授信合同终止日期
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// 授信额度
        /// </summary>
        public decimal CreditLimit { get; set; }

        /// <summary>
        /// 授信余额
        /// </summary>
        public decimal CreditBalance { get; set; }

        /// <summary>
        /// 合同有效状态
        /// </summary>
        public StatusEnum ValidStatus { get; set; }

        /// <summary>
        /// 是否有担保
        /// </summary>
        public bool IsGuarantee { get; set; }

        /// <summary>
        /// 担保合同
        /// </summary>
        public virtual ICollection<GuarantyContract> GuarantyContract { get; set; }

        /// <summary>
        /// 组织机构
        /// </summary>
        public virtual Organization Organization { get; set; }

        /// <summary>
        /// 额度变更
        /// </summary>
        /// <param name="limit">新授信额度</param>
        public void ChangeLimit(decimal limit)
        {
            if (ValidStatus != StatusEnum.失效)
            {
                CreditLimit = limit;
            }
            else
            {
                throw new ArgumentOutOfRangeAppException(nameof(ValidStatus), "合同已失效不允许额度变更.");
            }
        }

        /// <summary>
        /// 合同有效期变更
        /// </summary>
        /// <param name="expirationDate">终止日期</param>
        public void ChangeExpirationDate(DateTime expirationDate)
        {
            ExpirationDate = expirationDate;
        }

        /// <summary>
        /// 可否申请贷款
        /// </summary>
        /// <param name="limit">金额</param>
        /// <returns></returns>
        public bool CanApplyLoan(decimal limit)
        {
            var result = true;

            result &= CanCredit(limit);
            result &= IsEffectiveDate();
            result &= IsEffective();
            return result;
        }

        /// <summary>
        /// 终止授信协议
        /// </summary>
        public void ChangeStutus()
        {
            ValidStatus = StatusEnum.失效;
        }

        /// <summary>
        ///  融资额度是否充足
        /// </summary>
        /// <param name="amount">贷款金额</param>
        /// <returns></returns>
        private bool CanCredit(decimal amount)
        {
            if (CreditBalance < amount)
            {
                throw new ArgumentOutOfRangeAppException(nameof(CreditBalance), "授信余额不足.");
            }

            return true;
        }

        /// <summary>
        /// 判断申请是否在合同有效期内
        /// </summary>
        /// <returns></returns>
        private bool IsEffectiveDate()
        {
            if (ExpirationDate < DateTime.Now)
            {
                throw new InvalidOperationAppException("不在合同有效期内.");
                throw new ArgumentOutOfRangeAppException("当前时间", "不在合同有效期内.");
            }

            return true;
        }

        /// <summary>
        /// 授信协议是否有效
        /// </summary>
        /// <returns></returns>
        private bool IsEffective()
        {
            var result = true;

            if (IsEffectiveDate() == true && ValidStatus == StatusEnum.失效)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 更改合同有效状态
        /// </summary>
        /// <param name="status">合同状态</param>
        private void ChangeEffective(StatusEnum status)
        {
            ValidStatus = status;
        }
    }
}
