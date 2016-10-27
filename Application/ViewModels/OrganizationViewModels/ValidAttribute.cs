namespace Application.ViewModels.OrganizationViewModels
{
    #region 命名空间引用
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    #endregion

    #region 属性级别验证
    /// <summary>
    /// N类型验证特性
    /// </summary>
    /// zouql   16.10.17
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class NAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var temp = value == null ? string.Empty.ToCharArray() : value.ToString().ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] < 0X30 || temp[i] > 0X39)
                {
                    return false;
                }
            }

            return true;
        }
    }

    /// <summary>
    /// AN类型验证特性
    /// </summary>
    /// zouql   16.10.17
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ANAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var temp = value == null ? string.Empty.ToCharArray() : value.ToString().ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] < 0X20 || temp[i] > 0X7E)
                {
                    return false;
                }
            }

            return true;
        }
    }

    /// <summary>
    /// ANC类型验证特性
    /// </summary>
    /// zouql   16.10.17
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ANCAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return true;
        }
    }

    /// <summary>
    /// 组织机构代码验证特性
    /// </summary>
    /// zouql   16.10.20
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class OrganizateCodeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var valueStr = value == null ? string.Empty : value.ToString();

            var regResult = false;

            // 10个'#'通过校验
            if (new Regex(@"^[#]{10}").IsMatch(valueStr))
            {
                return true;
            }

            if (valueStr != "")
            {
                // 基础校验（前8位为数字或者大写英文字母、后1位为校验码）
                regResult = new Regex(@"^[A-Z0-9]{8}-[A-Z0-9]$").IsMatch(valueStr);

                // 校验码 C9=11-MOD(∑Ci(i=1→8)×Wi,11)
                if (regResult)
                {
                    valueStr = valueStr.Remove(valueStr.IndexOf('-'), 1);

                    var w = new int[] { 3, 7, 9, 10, 5, 8, 4, 2 };

                    var c9 = 0;
                    for (var index = 0; index < w.Length; index++)
                    {
                        c9 += int.Parse(valueStr[index].ToString()) * w[index];
                    }

                    c9 = 11 - (c9 % 11);

                    // 校验  当C9的值为10时，校验码应用大写的拉丁字母X表示；当C9的值为11时校验码用0表示。
                    if (c9 == 10)
                    {
                        regResult = valueStr[8] == 'X';
                    }
                    else if (c9 == 11)
                    {
                        regResult = valueStr[8] == 0;
                    }
                    else
                    {
                        // 十六进制转十进制后进行校验
                        regResult = Convert.ToInt32(valueStr[8].ToString(), 16) == c9;
                    }
                }

            }
            else
            {
                return true;
            }

            return regResult;
        }
    }

    /// <summary>
    /// 贷款卡编码验证特性
    /// </summary>
    /// zouql   16.10.20
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class CreditCardAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var valueStr = value == null ? string.Empty : value.ToString();

            var regResult = false;

            // 基础校验（前3位为数字或者大写英文字母、后13位数字）
            regResult = new Regex(@"^[A - Z0 - 9]{ 3}\d{ 13}$|^\d{ 16}$").IsMatch(valueStr);

            // 后两位校验 前十四位乘以权重相加后除以97后的余数再加1后得到的数字
            if (regResult)
            {
                // 权重
                var w = new int[] { 1, 3, 5, 7, 11, 2, 13, 1, 1, 17, 19, 97, 23, 29 };

                // 后两位校验
                var lastValue = 0;
                for (var index = 0; index < w.Length; index++)
                {
                    // 十六进制转十进制后再进行计算
                    lastValue += w[index] * Convert.ToInt32(valueStr[index].ToString(), 16);
                }

                lastValue = 1 + (lastValue % 97);

                var lastValueStr = lastValue > 10 ? lastValue.ToString() : "0" + lastValue;

                regResult = lastValueStr.Equals(valueStr.Substring(14, 2));
            }

            return regResult;
        }
    }

    /// <summary>
    /// 注册资本保留2位小数
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RegisterCapitalAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var valueStr = value == null ? string.Empty : value.ToString();

            return new Regex(@"^d+\.\d{2}$").IsMatch(valueStr);
        }
    }

    /// <summary>
    /// 持股比例保留2位小数
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class SharesProportionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var valueStr = value == null ? string.Empty : value.ToString();

            return new Regex(@"^d+\.\d{2}$").IsMatch(valueStr);
        }
    }
    #endregion

    #region 机构段级别验证
    #region 基础段
    /// <summary>
    /// 组织机构代码和登记注册号码不能同时为空
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class BasePeriod_ORAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? new BaseViewModel();

            var basePeriod = value as BaseViewModel;

            return ServiceMethods.CheckInPairs(new string[] { basePeriod.OrganizateCode, basePeriod.RegistraterCode });
        }
    }

    /// <summary>
    /// 登记注册号类型和登记注册号码需成对出现
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class BasePeriod_TNAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? new BaseViewModel();

            var basePeriod = value as BaseViewModel;

            if (string.IsNullOrEmpty(basePeriod.RegistraterType) && string.IsNullOrEmpty(basePeriod.RegistraterCode))
            {
                return false;
            }

            return ServiceMethods.CheckInPairs(new string[] { basePeriod.RegistraterType, basePeriod.RegistraterCode });
        }
    }
    #endregion

    #region 高管及主要关系人段
    /// <summary>
    /// 证件号码和证件类型成对出现
    /// </summary>
    public class ExecutivesMajorParticipantPeriod_NTAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? new ManagerViewModel();

            var executivesMajorParticipantPeriod = value as ManagerViewModel;

            return ServiceMethods.CheckInPairs(new string[] { executivesMajorParticipantPeriod.CertificateCode, executivesMajorParticipantPeriod.CertificateType });
        }
    }
    #endregion

    #region 重要股东段
    /// <summary>
    /// 证件号码/登记注册号码和证件类型/登记注册号类型成对出现
    /// </summary>
    public class MajorShareholdersPeriod_NTAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? new StockholderViewModel();

            var executivesMajorParticipantPeriod = value as StockholderViewModel;

            return ServiceMethods.CheckInPairs(new string[] { executivesMajorParticipantPeriod.RegistraterCode, executivesMajorParticipantPeriod.RegistraterType }); 
        }
    }

    /// <summary>
    /// 当股东类型为2-机构时，登记注册号码、组织机构代码、机构信用代码必填其一
    /// </summary>
    public class MajorShareholdersPeriod_ROIAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? new StockholderViewModel();

            var executivesMajorParticipantPeriod = value as StockholderViewModel;

            if (!string.IsNullOrEmpty(executivesMajorParticipantPeriod.ShareholdersType) && executivesMajorParticipantPeriod.ShareholdersType.Equals("2"))
            {
                if (string.IsNullOrEmpty(executivesMajorParticipantPeriod.RegistraterCode) && string.IsNullOrEmpty(executivesMajorParticipantPeriod.OrganizateCode) && string.IsNullOrEmpty(executivesMajorParticipantPeriod.InstitutionCreditCode))
                {
                    return false;
                }
            }

            return true;
        }
    }

    /// <summary>
    /// 当股东类型与证件类型/登记注册号类型对应
    /// </summary>
    public class MajorShareholdersPeriod_TRAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? new StockholderViewModel();

            var executivesMajorParticipantPeriod = value as StockholderViewModel;

            if (!string.IsNullOrEmpty(executivesMajorParticipantPeriod.ShareholdersType) && !string.IsNullOrEmpty(executivesMajorParticipantPeriod.RegistraterType))
            {
                if (executivesMajorParticipantPeriod.ShareholdersType.Equals("1"))
                {
                    var list = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "X" };

                    return list.Contains(executivesMajorParticipantPeriod.RegistraterType);
                }
                else
                {
                    var list = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "99" };

                    return list.Contains(executivesMajorParticipantPeriod.RegistraterType);
                }
            }

            return true;
        }
    }

    #endregion

    #region 主要关联企业段
    /// <summary>
    /// 登记注册号码、组织机构代码和机构信用代码不能同时为空
    /// </summary>
    public class MainAssociatedEnterprisePerid_ROIAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? new AssociatedEnterpriseViewModel();

            var mainAssociatedEnterprisePerid = value as AssociatedEnterpriseViewModel;

            return ServiceMethods.CheckInPairs(new string[] { mainAssociatedEnterprisePerid.RegistraterCode, mainAssociatedEnterprisePerid.OrganizateCode });
        }
    }
    #endregion

    #region 上级机构（主管单位）段
    /// <summary>
    /// 登记注册号码、组织机构代码和机构信用代码不能同时为空
    /// </summary>
    public class SuperInstitutionPeriod_ROIAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? new ParentViewModel();

            var superInstitutionPeriod = value as ParentViewModel;

            return ServiceMethods.CheckInPairs(new string[] { superInstitutionPeriod.RegistraterCode, superInstitutionPeriod.OrganizateCode });
        }
    }
    #endregion
    #endregion

    #region 家族段级别验证
    #region 基础段
    /// <summary>
    /// 家族成员证件号码和证件类型成对出现
    /// </summary>
    public class FBasePeriod_FORAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? new FamilyMemberViewModel();

            var basePeriod = value as FamilyMemberViewModel;

            return ServiceMethods.CheckInPairs(new string[] { basePeriod.CertificateCode, basePeriod.CertificateType });
        }
    }
    #endregion
    #endregion

    #region 家族删除报文
    /// <summary>
    /// 家族成员证件号码和证件类型成对出现
    /// </summary>
    public class FDBasePeriod_FORAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? new FamilyMemberViewModel();

            var basePeriod = value as FamilyMemberViewModel;

            return ServiceMethods.CheckInPairs(new string[] { basePeriod.CertificateCode, basePeriod.CertificateType });
        }
    }
    #endregion

    #region 信息记录级别验证

    #endregion

    #region 代码表验证
    /// <summary>
    /// 证件类型
    /// </summary>
    public class CertificateTypeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "X" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 家族关系
    /// </summary>
    public class FamilyRelationshipAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "1", "2", "3", "4", "5" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 需删除的信息类别
    /// </summary>
    public class NendDeleteInformationCategoriesAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "B", "C", "D", "E", "F", "G", "H", "I" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 关系人类型
    /// </summary>
    public class ParticipantTypeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "0", "1", "2", "3", "4", "5" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 客户类型
    /// </summary>
    public class CustomerTypeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "1", "2", "3", "X" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 登记注册号类型
    /// </summary>
    public class RegistrationNumberTypeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "99" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 国别
    /// </summary>
    public class CountryAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "CHN", "HKG", "MAC", "TWN" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 币种
    /// </summary>
    public class CapitalCurrencyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "CNY", "HKD", "MOP", "USD", "XAU" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 组织机构类别
    /// </summary>
    public class OrganizationCategoryAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "1", "2", "3", "4", "7", "9" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 组织机构类别细分
    /// </summary>
    public class OrganizationCategorySubdivisionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "10", "13", "14", "11", "12", "20", "21", "24", "30", "31", "32", "40", "41", "51", "52", "53", "54", "60", "61", "62", "70", "99" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 经济类型
    /// </summary>
    public class EconomicTypeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "10", "11", "12", "13", "14", "15", "16", "17", "19", "20", "21", "22", "23", "24", "29", "30", "31", "32", "33", "34", "39", "90" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 基本户状态
    /// </summary>
    public class BasicAccountStateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "1", "2", "3", "4", "9", "X" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 企业规模
    /// </summary>
    public class EnterpriseScaleAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "2", "3", "4", "5", "9", "X" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 机构状态
    /// </summary>
    public class InstitutionsStateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "1", "2", "9", "X" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 股东类型
    /// </summary>
    public class ShareholdersTypeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "1", "2" };

            return list.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 关联类型
    /// </summary>
    public class AssociatedTypeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            var list = new List<string>() { "20", "21", "22", "23", "24" };

            return list.Contains(value.ToString());
        }
    }

    #endregion

    #region 服务方法
    public class ServiceMethods
    {
        /// <summary>
        /// 判断两项成对出现
        /// </summary>
        /// zouql
        /// yand    16.10.25 修改校验
        /// <param name="valueArray">被判断的值</param>
        /// <returns></returns>
        public static bool CheckInPairs(string[] valueArray)
        {
            if (valueArray == null || valueArray.Length < 2)
            {
                return false;
            }

            var value1 = string.IsNullOrEmpty(valueArray[0]);

            var value2 = string.IsNullOrEmpty(valueArray[1]);

            if (value1 && value2)
            {
                return false;
            }

            return true;
        }
    }

    #endregion
}
