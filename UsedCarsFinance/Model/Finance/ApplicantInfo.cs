using System;

namespace Models.Finance
{
    /// <summary>
    /// 申请人实体
    /// </summary>
    /// cais    16.03.30
    public class ApplicantInfo
    {
        /// <summary>
        /// 申请人主键ID
        /// </summary>
        public int? ApplicantId { get; set; }

        /// <summary>
        /// 融资ID
        /// </summary>
        public int? FinanceId { get; set; }

        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 申请人性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 申请人年龄
        /// </summary>
        public int? Age { get; set; }
        /// <summary>
        /// 申请人类型
        /// </summary>
        public TypeEnum Type { get; set; }
        public string TypeDesc { get { return Type.ToString(); } }

        /// <summary>
        /// 与主要申请人关系
        /// </summary>
        public string RelationWithMaster { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string Identity { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string IdentityType { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 住宅电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string MaritalStatus { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public string Degree { get; set; }

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
        /// 行业
        /// </summary>
        public string IndustryType { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        public string ProfessionType { get; set; }

        /// <summary>
        /// 单位电话
        /// </summary>
        public string OfficePhone { get; set; }

        /// <summary>
        /// 单位地址
        /// </summary>
        public string OfficeAddress { get; set; }

        /// <summary>
        /// 现住房情况
        /// </summary>
        public string LiveHouseType { get; set; }

        /// <summary>
        /// 现住房地址
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
        /// 配偶姓名
        /// </summary>
        public string WifeName { get; set; }

        /// <summary>
        /// 月收入总额
        /// </summary>
        public string TotalMonthlyIncome { get; set; }

        /// <summary>
        /// 家庭月收入
        /// </summary>
        public string HomeMonthlyIncome { get; set; }

        /// <summary>
        /// 家庭月支出
        /// </summary>
        public string HomeMonthlyExpend { get; set; }

        /// <summary>
        /// 其他收入
        /// </summary>
        public string OtherIncome { get; set; }

        /// <summary>
        /// 供养人数
        /// </summary>
        public string FamilyNumber { get; set; }

        /// <summary>
        /// 现住房面积
        /// </summary>
        public string LiveHouseArea { get; set; }

        /// <summary>
        /// 自有住房类型
        /// </summary>
        public string OwnHouseType { get; set; }
        /// <summary>
        /// 自有住房地址
        /// </summary>
        public string OwnHouseAddress { get; set; }
        public string Fax { get; set; }
        public string EMail { get; set; }
        public string Postcode { get; set; }


        /// <summary>
        /// 申请人类型枚举
        /// </summary>
        public enum TypeEnum : byte
        {
            主要申请人 = 1,
            共同申请人 = 2,
            担保人 = 3,
            联系人 = 4
        }

    }
}