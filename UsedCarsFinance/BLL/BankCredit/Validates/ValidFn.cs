using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.BankCredit.Validates
{
    public class ValidFn
    {
        /// <summary>
        /// 身份证号码校验
        /// zouql   16.10.14
        /// </summary>
        /// <param name="value">被检测身份证号码</param>
        /// <returns>检测结果</returns>
        public static bool IdCard_Valid(string value)
        {
            var regResult = false;

            // 15位身份证校验
            regResult = new Regex(@"^[1 - 9][0 - 9]{5}[0-9]{2}(0[1-9]|1[0-2])((0[1-9])|((1|2)[0-9])|3[0-1])[0-9]{3}$").IsMatch(value);
            if (regResult)
            {
                return true;
            }

            // 基础校验（前17位为数字,后1位为校验码）
            regResult = new Regex(@"^[1-9][0-9]{5}[1-9][0-9]{3}(0[1-9]|1[0-2])((0[1-9])|((1|2)[0-9])|3[0-1])[0-9]{3}[0-9X]$").IsMatch(value);

            // 校验码 C18=(12-MOD(∑Ci(i=1→17)×Wi,11)%11)%11
            if (regResult)
            {
                var W = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };

                var C18 = 0;
                for (var index = 0; index < W.Length; index++)
                {
                    C18 += int.Parse(value[index].ToString()) * W[index];
                }
                C18 = (12 - C18 % 11) % 11;

                // 校验  当C18的值为10时，校验码应用大写的拉丁字母X表示
                if (C18 == 10)
                {
                    regResult = value[17].Equals('X');
                }
                else
                {
                    regResult = int.Parse(value[17].ToString()) == C18;
                }
            }

            if (regResult)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///  组织机构代码校验
        /// zouql   16.10.14
        /// </summary>
        /// <param name="value">被检测组织机构代码</param>
        /// <returns>检测结果</returns>
        public static bool OrganizateCode_Valid(string value)
        {
            var regResult = false;

            // 10个'#'通过校验
            if (new Regex(@"^[#]{10}").IsMatch(value))
            {
                return true;
            }

            // 基础校验（前8位为数字或者大写英文字母、后1位为校验码）
            regResult = new Regex(@"^[A-Z0-9]{8}-[A-Z0-9]$").IsMatch(value);

            // 校验码 C9=11-MOD(∑Ci(i=1→8)×Wi,11)
            value = value.Remove(value.IndexOf('-'), 1);

            // 校验码 C9=11-MOD(∑Ci(i=1→8)×Wi,11)
            if (regResult)
            {
                var W = new int[] { 3, 7, 9, 10, 5, 8, 4, 2 };

                var C9 = 0;
                for (var index = 0; index < W.Length; index++)
                {
                    C9 += int.Parse(value[index].ToString()) * W[index];
                }
                C9 = 11 - C9 % 11;

                // 校验  当C9的值为10时，校验码应用大写的拉丁字母X表示；当C9的值为11时校验码用0表示。
                if (C9 == 10)
                {
                    regResult = value[8] == 'X';
                }
                else if (C9 == 11)
                {
                    regResult = value[8] == 0;
                }
                else
                {
                    // 十六进制转十进制后进行校验
                    regResult = Convert.ToInt32(value[8].ToString(),16) == C9;
                }
            }

            return regResult;
        }

        /// <summary>
        /// 贷款卡编码校验
        /// zouql   16.10.14
        /// </summary>
        /// <param name="value">被检测贷款卡编码</param>
        /// <returns>检测结果</returns>
        public static bool CreditCard_Valid(string value)
        {
            var regResult = false;

            // 基础校验（前3位为数字或者大写英文字母、后13位数字）
            regResult = new Regex(@"^[A - Z0 - 9]{ 3}\d{ 13}$|^\d{ 16}$").IsMatch(value);

            // 后两位校验 前十四位乘以权重相加后除以97后的余数再加1后得到的数字
            if (regResult)
            {
                // 权重
                var W = new int[] { 1, 3, 5, 7, 11, 2, 13, 1, 1, 17, 19, 97, 23, 29 };

                // 后两位校验
                var lastValue = 0;
                for(var index=0;index<W.Length;index++) {
                    // 十六进制转十进制后再进行计算
                    lastValue += W[index] * Convert.ToInt32(value[index].ToString(),16);
                }

                lastValue = 1 + lastValue % 97;

                var lastValueStr = lastValue > 10 ? lastValue.ToString() : "0" + lastValue;

                regResult = lastValueStr.Equals(value.Substring(14, 2));
            }

            return regResult;
        }
    }
}
