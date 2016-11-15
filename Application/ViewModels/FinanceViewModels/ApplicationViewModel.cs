namespace Application.ViewModels.FinanceViewModels
{
    using System;

    public class ApplicationViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 申请人性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string IdentityType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string Identity { get; set; }

        /// <summary>
        /// 申请人类型
        /// </summary>
        public TypeEnum Type { get; set; }

        /// <summary>
        /// 与主要申请人关系
        /// </summary>
        public string RelationWithMaster { get; set; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string MaritalStatus { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 住宅电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 现居住地址
        /// </summary>
        public string LiveHouseAddress { get; set; }

        /// <summary>
        /// 通讯地址
        /// </summary>
        public string ContactAddress { get; set; }

        /// <summary>
        /// 通讯地址类型（住宅/单位）
        /// </summary>
        public string ContactAddressType { get; set; }

        /// <summary>
        /// 户口所在地
        /// </summary>
        public string RegisteredAddress { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string OfficeName { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 行业
        /// </summary>
        public string IndustryType { get; set; }

        /// <summary>
        /// 单位电话
        /// </summary>
        public string OfficePhone { get; set; }

        /// <summary>
        /// 单位地址
        /// </summary>
        public string OfficeAddress { get; set; }

        /// <summary>
        /// 配偶姓名
        /// </summary>
        public string WifeName { get; set; }

        /// <summary>
        /// 配偶电话
        /// </summary>
        public string WifePhone { get; set; }

        /// <summary>
        /// 配偶单位电话
        /// </summary>
        public string WifeOfficePhone { get; set; }

        /// <summary>
        /// 配偶单位地址
        /// </summary>
        public string WifeOfficeAddress { get; set; }

        /// <summary>
        /// 申请人月收入
        /// </summary>
        public decimal TotalMonthlyIncome { get; set; }

        /// <summary>
        /// 其他月收入
        /// </summary>
        public decimal OtherIncome { get; set; }

        /// <summary>
        /// 家庭月收入
        /// </summary>
        public decimal HomeMonthlyIncome { get; set; }

        /// <summary>
        /// 家庭月支出
        /// </summary>
        public decimal HomeMonthlyExpend { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public string Degree { get; set; }

        /// <summary>
        /// 供养人数
        /// </summary>
        public int FamilyNumber { get; set; }

        /// <summary>
        /// 自有住房数
        /// </summary>
        public int OwnHouseCount { get; set; }

        /// <summary>
        /// 自有住房信息
        /// </summary>
        public string OwnHouse { get; set; }

        /// <summary>
        /// 申请人类型枚举
        /// </summary>
        public enum TypeEnum : byte
        {
            /// <summary>
            /// 主要申请人
            /// </summary>
            主要申请人 = 1,

            /// <summary>
            /// 共同申请人
            /// </summary>
            共同申请人 = 2,

            /// <summary>
            /// 担保人
            /// </summary>
            担保人 = 3,

            /// <summary>
            /// 联系人
            /// </summary>
            联系人 = 4
        }
    }
}
