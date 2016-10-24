using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Models.BankCredit;
using System.Linq;

namespace BLL.BankCredit.Validates
{
    public class PersonalBaseValidate : BaseValidate
    {
        private readonly Dictionary<string, string> dataDic = null;

        public PersonalBaseValidate(int infoTypeId, MessageInfo data) : base(data)
        {
            // 实例化DataDic
            dataDic = new SegmentRules().GetDataByMetaId(infoTypeId);

            // 类型检验
            BaseTypeComare(data);

            // 通用验证
            Valid(infoTypeId, data);

            // 通用验证2
            Valid2(infoTypeId, data);
        }

        /// <summary>
        /// 通用验证方法
        /// </summary>
        /// yangj   2016.09.27
        /// zouql   2016.10.14 代码整理及新增验证
        /// <param name="infoTypeId">信息记录ID</param>
        /// <param name="data">数据</param>
        public override void Valid(int infoTypeId, MessageInfo data)
        {
            #region 元数据
            // 授信额度
            var value1101 = GetValue(1101, "A", data);
            // 最大负债额
            var value1103 = GetValue(1103, "A", data);
            // 余额
            var value1109 = GetValue(1109, "A", data);
            // 当前逾期总额
            var value1111 = GetValue(1111, "A", data);
            // 逾期31-60天未归还贷款本金
            var value1113 = GetValue(1113, "A", data);
            // 逾期61-90天未归还贷款本金
            var value1115 = GetValue(1115, "A", data);
            // 逾期91-180天未归还贷款本金
            var value1117 = GetValue(1117, "A", data);
            // 逾期180天以上未归还贷款本金
            var value1119 = GetValue(1119, "A", data);
            // 开户日期
            var value2101 = GetValue(2101, "A", data);
            // 到期日期
            var value2103 = GetValue(2103, "A", data);
            // 最近一次实际还款日期
            var value2107 = GetValue(2107, "A", data);
            // 结算/还款日期
            var value2301 = GetValue(2301, "A", data);
            // 出生日期
            var value2408 = GetValue(2408, "B", data);
            // 还款月数
            var value4101 = GetValue(4101, "A", data);
            // 剩余还款月数
            var value4105 = GetValue(4105, "A", data);
            // 最高逾期期数
            var value4107 = GetValue(4107, "A", data);
            // 当前逾期期数
            var value4109 = GetValue(4109, "A", data);
            // 还款频率
            var value4111 = GetValue(4111, "A", data);
            // 累计逾期期数
            var value4312 = GetValue(4312, "A", data);
            // 姓名
            var value5101 = GetValue(5101, "E", data);
            // 证件类型
            var value5107 = GetValue(5107, "E", data);
            // 证件号码
            var value5109 = GetValue(5109, "E", data);
            // 金融机构代码
            var value6101 = GetValue(6101, "A", data);
            // 金融机构代码[交易标识变更段]
            var value6101F = GetValue(6101, "F", data);
            // 业务号[基础段]
            var value7101 = GetValue(7101, "A", data);
            // 业务号[交易标识变更段]
            var value7101F = GetValue(7101, "F", data);
            // 24个月（账户）还款状态
            var value7107 = GetValue(7107, "A", data);
            // 账号状态
            var value7109 = GetValue(7109, "A", data);
            // 业务种类细分
            var value7111 = GetValue(7111, "A", data);
            // 业务种类
            var value7117 = GetValue(7117, "A", data);
            // 拥有者信息提示
            var value7121 = GetValue(7121, "A", data);
            #endregion

            #region // 026 [还款月数] > [剩余还款月数]
            if (!string.IsNullOrEmpty(value4101) && !string.IsNullOrEmpty(value4105))
            {
                if (value4101 != "O" && value4101 != "U" && value4101 != "C" && value4105 != "O" && value4105 != "U" && value4105 != "C")
                {
                    if (Convert.ToInt32(value4101) <= Convert.ToInt32(value4105))
                    {
                        ShowError(message: "基础段中“还款月数” > “剩余还款月数”");
                    }
                }
            }
            #endregion

            #region // 029 [余额] <= [最大负债额]
            if (!string.IsNullOrEmpty(value1109) && !string.IsNullOrEmpty(value1103))
            {
                if (Convert.ToDouble(value1109) > Convert.ToDouble(value1103))
                {
                    ShowError(message: "基础段中“余额” <= “最大负债额”");
                }
            }
            #endregion

            #region // 020 [还款频率] = '07-一次性', [还款月数] = 'O' [剩余还款月数] = 'O' [还款频率] = '08-不定期',[还款月数] = 'U' [剩余还款月数] = 'U'
            if (!string.IsNullOrEmpty(value4111) && !string.IsNullOrEmpty(value4101) && !string.IsNullOrEmpty(value4105))
            {
                if (value4111 == "07" && value4101 != "O" && value4105 != "O")
                {
                    ShowError(message: "基础段中，若“还款频率”为“一次性”，则“还款月数”、“剩余还款月数”用字母“O”填充");
                }

                if (value4111 == "08" && value4101 != "U" && value4105 != "U")
                {
                    ShowError(message: "基础段中，若“还款频率”为“不定期”，则“还款月数”、“剩余还款月数”用“U”填充");
                }
            }
            #endregion

            #region // 028 [最近一次实际还款日期] > [开户日期]
            if (!string.IsNullOrEmpty(value2107) && !string.IsNullOrEmpty(value2101))
            {
                if (Convert.ToInt32(value2107) < Convert.ToInt32(value2101))
                {
                    ShowError(message: "基础段中“最近一次实际还款日期” >= “开户日期”");
                }
            }
            #endregion

            #region // 018 [业务种类] = '1-贷款',[授信额度] >= [最大负债额]
            if (value7117 == "1" && !string.IsNullOrEmpty(value1101) && !string.IsNullOrEmpty(value1103))
            {
                if (Convert.ToDouble(value1101) < Convert.ToDouble(value1103))
                {
                    ShowError(message: "基础段中“授信额度” >= “最大负债额”");
                }
            }
            #endregion

            #region // 015 [业务种类] = '2-信用卡',[到期日期] = '20991231'
            if (value7117 == "2" && !string.IsNullOrEmpty(value2103))
            {
                if (value2103 != "20991231")
                {
                    ShowError(message: "基础段中，当“业务种类”为“信用卡”时，“到期日期”必须为“20991231”");
                }
            }
            #endregion

            #region // 017 [业务种类] = '2-信用卡',[业务种类细分] = '71-贷记卡' or [业务种类细分] = '81-准贷记卡'
            if (value7117 == "2" && !string.IsNullOrEmpty(value7111))
            {
                if (value7111 != "71" && value7111 != "81")
                {
                    ShowError(message: "基础段中，“业务种类”为“信用卡”时，“业务种类细分”只能填写“准贷记卡”、“贷记卡”");
                }
            }
            #endregion

            #region // 015 [开户日期] <= [结算/应还款日期]
            if (!string.IsNullOrEmpty(value2101) && !string.IsNullOrEmpty(value2301))
            {
                if (Convert.ToInt32(value2101) > Convert.ToInt32(value2301))
                {
                    ShowError(message: "基础段中“开户日期” <= “结算/还款日期”");
                }
            }
            #endregion

            #region // 015 [开户日期] <= [到期日期]
            if (!string.IsNullOrEmpty(value2101) && !string.IsNullOrEmpty(value2103))
            {
                if (Convert.ToInt32(value2101) > Convert.ToInt32(value2103))
                {
                    ShowError(message: "基础段中“开户日期” <= “到期日期”");
                }
            }
            #endregion

            #region // 022 [业务种类] = '1-贷款' [账号状态] = '3-结算',[余额] = '0' [当前逾期期数] = '0' [当前逾期总额] = '0'
            if (value7117 == "1" && value7109 == "3")
            {
                if (value1109 != "0" || value4109 != "0" || value1111 != "0")
                {
                    ShowError(message: "基础段中，“业务种类”为“贷款”，且“账户状态为”结清”时，“余额、当前逾期期数、当前逾期总额”必须为零");
                }
            }
            #endregion

            #region // 021 [业务种类] = '1-贷款' [账号状态] = '2-逾期' or [账号状态] = '4-呆账',[当前逾期期数] != '0' [当前逾期总额] != '0' [累计逾期期数] != '0' [最高逾期期数] != '0'
            if (value7117 == "1" && (value7109 == "2" || value7109 == "4"))
            {
                if (value4109 == "0" || value1111 == "0" || value4312 == "0" || value4107 == "0")
                {
                    ShowError(message: "基础段中，业务种类”为“贷款”时，若“账户状态”为“逾期”或“呆账”，则“当前逾期期数、当前逾期总额、累计逾期期数、最高逾期期数”不能为零");
                }
            }
            #endregion

            #region // 030 [业务种类] = '2-信用卡' [业务种类细分] = '81-贷记卡',[余额] >= [当前逾期总额]
            if (value7117 == "2" && value7111 == "81" && !string.IsNullOrEmpty(value1109) && !string.IsNullOrEmpty(value1111))
            {
                if (Convert.ToDouble(value1109) < Convert.ToDouble(value1111))
                {
                    ShowError(message: "基础段中，“业务种类”为“信用卡”，且“业务种类细分”为“贷记卡”时，”余额”>=“当前逾期总额”");
                }
            }
            #endregion

            #region // 019 [业务种类] = "1-贷款",[还款频率] != "C"
            if (value7117 == "1" && !string.IsNullOrEmpty(value4111))
            {
                if (value4111 == "C")
                {
                    ShowError(message: "基础段中，“业务种类”为“贷款”时，“还款频率”必须为“信用卡还款频率”以外的数据字典中的值");
                }
            }
            #endregion

            #region // 019 [业务种类] = "2-信用卡",[还款频率] = "C"
            if (value7117 == "2" && !string.IsNullOrEmpty(value4111))
            {
                if (value4111 != "C")
                {
                    ShowError(message: "基础段中，“业务种类”为“信用卡”时，“还款频率”填“信用卡还款频率”");
                }
            }

            // 019 [业务种类] = "2-信用卡",[还款月数] = "C" [剩余还款月数] = "C"
            if (value7117 == "2" && !string.IsNullOrEmpty(value4101) && !string.IsNullOrEmpty(value4105))
            {
                if (value4101 != "C" || value4105 != "C")
                {
                    ShowError(message: "基础段中，“业务种类”为“信用卡”时，“还款月数”、“剩余还款月数”填“C”");
                }
            }
            #endregion

            #region // 016 [业务种类] = "1-贷款",[业务种类细分] = "11-个人住房贷款" or "12-个人商用房贷款" or "13-个人住房公积金贷款" or "21-个人汽车贷款" or "31-个人助学贷款" or "41-个人经营性贷款" or "51-农户贷款" or "91-个人消费贷款" or "99-其他"
            if (value7117 == "1" && !string.IsNullOrEmpty(value7111))
            {
                if (value7111 != "11" && value7111 != "12" && value7111 != "13"
                    && value7111 != "21" && value7111 != "31" && value7111 != "41"
                    && value7111 != "51" && value7111 != "91" && value7111 != "99")
                {
                    ShowError(message: "基础段中，“业务种类”为“贷款”时，“业务种类细分”只能填写“个人住房贷款”、“个人商用房贷款”、“个人住房公积金贷款”、“个人汽车贷款”、“个人助学贷款”、“个人经营性贷款”、“农户贷款”、“个人消费贷款”、“其他”");
                }
            }
            #endregion

            #region // 账户状态数据段规则ID，账户状态选项选中值
            var accountStatusId = new SegmentRules().GetIdByMetaAndInfoType(infoTypeId, 7109, "A");
            var accountStatusCode = value7109;

            // 016 [业务种类]= "1-贷款"，[账户状态] 必须填写[贷款]项下的代码
            if (value7117 == "1" && !string.IsNullOrEmpty(accountStatusId) && !string.IsNullOrEmpty(accountStatusCode))
            {
                var result = new CodeProofMethod().CodePoorfMethod(Convert.ToInt32(accountStatusId), accountStatusCode);
                if (result == false)
                {
                    ShowError(message: "基础段中，“业务种类”为“贷款”时，“账户状态”必须填写“贷款”项下的代码");
                }
            }

            // 017 [业务种类]= "2-信用卡"，[账户状态] 必须填写[信用卡]项下的代码
            if (value7117 == "2" && !string.IsNullOrEmpty(accountStatusId) && !string.IsNullOrEmpty(accountStatusCode))
            {
                var result = new CodeProofMethod().CodePoorfMethod(Convert.ToInt32(accountStatusId), accountStatusCode);
                if (result == false)
                {
                    ShowError(message: "基础段中，“业务种类”为“信用卡”时，“账户状态”必须填写“信用卡”项下的代码");
                }
            }
            #endregion

            #region // 031 [逾期31-60天未归还贷款本金]＋[逾期61-90天未归还贷款本金]＋[逾期91-180天未归还贷款本金]＋[逾期180天以上未归还贷款本金] <= [余额]＋2
            if (!string.IsNullOrEmpty(value1113) && !string.IsNullOrEmpty(value1115) && !string.IsNullOrEmpty(value1117) && !string.IsNullOrEmpty(value1119) && !string.IsNullOrEmpty(value1109))
            {
                var sum = Convert.ToInt32(value1113) + Convert.ToInt32(value1115) + Convert.ToInt32(value1117) + Convert.ToInt32(value1119);
                if (sum > (Convert.ToInt32(value1109) + 2))
                {
                    ShowError(message: "基础段中，“逾期31-60天未归还贷款本金”＋“逾期61-90天未归还贷款本金”＋“逾期91-180天未归还贷款本金”＋“逾期180天以上未归还贷款本金” <= “余额”＋2");
                }
            }
            #endregion

            #region // 033 [逾期31-60天未归还贷款本金]＋[逾期61-90天未归还贷款本金]＋[逾期91-180天未归还贷款本金]＋[逾期180天以上未归还贷款本金] <= [当前逾期总额]＋2
            if (!string.IsNullOrEmpty(value1113) && !string.IsNullOrEmpty(value1115) && !string.IsNullOrEmpty(value1117) && !string.IsNullOrEmpty(value1119) && !string.IsNullOrEmpty(value1111))
            {
                var sum = Convert.ToInt32(value1113) + Convert.ToInt32(value1115) + Convert.ToInt32(value1117) + Convert.ToInt32(value1119);
                if (sum > (Convert.ToInt32(value1111) + 2))
                {
                    ShowError(message: "基础段中，“逾期31-60天未归还贷款本金”＋“逾期61-90天未归还贷款本金”＋“逾期91-180天未归还贷款本金”＋“逾期180天以上未归还贷款本金” <= “当前逾期总额”＋2");
                }
            }
            #endregion

            #region // 032 [业务种类]= "1-贷款"，[当前逾期期数] <= [最高逾期期数] <= [累计逾期期数]
            if (value7117 == "1" && !string.IsNullOrEmpty(value4109) && !string.IsNullOrEmpty(value4107) && !string.IsNullOrEmpty(value4312))
            {
                var result = Convert.ToInt32(value4109) <= Convert.ToInt32(value4107) && Convert.ToInt32(value4107) <= Convert.ToInt32(value4312);
                if (!result)
                {
                    ShowError(message: "基础段中“业务种类”为“贷款”时，“当前逾期期数” <= “最高逾期期数” <= “累计逾期期数”");
                }
            }
            #endregion

            #region // 009 有效日期验证（出生日期不能大于当前日期）
            if (!string.IsNullOrEmpty(value2408))
            {
                if (Convert.ToInt32(value2408) > Convert.ToInt32(string.Format("{0:yyyyMMdd}", DateTime.Now)))
                {
                    ShowError(message: "出生日期不能大于当前日期");
                }
            }
            #endregion

            #region // 040 担保信息段中“证件类型”为“0-身份证”时，担保信息段中“证件号码”必须为15位或18位，且15位身份证号码的每一位必须都是数字，18位身份证号码的前17位必须都是数字，18位身份证号码的最后一位必须都是数字或大写的X。
            if (!string.IsNullOrEmpty(value5107) && !string.IsNullOrEmpty(value5109))
            {
                var value5107Array = value5107.Split('.');
                var value5109Array = value5109.Split('.');

                for (var i = 0; i < value5107Array.Length; i++)
                {
                    var reg = ValidFn.IdCard_Valid(value5109Array[i]);

                    if (value5107Array[i] == "0" && !reg)
                    {
                        ShowError(message: "担保信息段中,证件号码错误");
                    }
                }
            }
            #endregion

            #region // 担保信息段中，任意两个担保信息段的“证件类型、“证件号码”不能完全相同
            if (!string.IsNullOrEmpty(value5101) && !string.IsNullOrEmpty(value5107) && !string.IsNullOrEmpty(value5109))
            {
                var value5101Array = value5101.Split('.');
                var value5107Array = value5107.Split('.');
                var value5109Array = value5109.Split('.');

                var tempArray = new List<string>();
                for (var i = 0; i < value5101Array.Length; i++)
                {
                    if (!tempArray.Contains(value5107Array[i] + value5109Array[i]))
                    {
                        tempArray.Add(value5107Array[i] + value5109Array[i]);
                    }
                }

                if (tempArray.Count != value5101Array.Length)
                {
                    ShowError(message: "担保信息段中，任意两个担保信息段的“证件类型、“证件号码”不能完全相同");
                }
            }
            #endregion

            #region // 交易标识变更段中“金融机构代码”+“业务号”不能和基础段中“金融机构代码”+“业务号”相同
            if (!string.IsNullOrEmpty(value6101) && !string.IsNullOrEmpty(value6101F) && !string.IsNullOrEmpty(value7101) && !string.IsNullOrEmpty(value7101F))
            {
                if (value6101.Equals(value6101F) && value7101.Equals(value7101F))
                {
                    ShowError(message: "交易标识变更段中“金融机构代码”+“业务号”不能和基础段中“金融机构代码”+“业务号”相同");
                }
            }
            #endregion

            #region // 当基础段中的账户拥有者信息提示为“2-新账户开立”时，不能包含交易标识变更段  // 当基础段中的账户拥有者信息提示为“1-已开立账户”时，不能包含身份信息段、职业信息段、居住地址段

            if (!string.IsNullOrEmpty(value7121))
            {
                if (value7121.Equals("2") && data.F.Count > 0)
                {
                    ShowError(message: "当基础段中的账户拥有者信息提示为“新账户开立”时，不能包含交易标识变更段");
                }
                else if (value7121.Equals("1"))
                {
                    if (data.B.Count > 0 || data.C.Count > 0 || data.D.Count > 0)
                    {
                        ShowError(message: "当基础段中的账户拥有者信息提示为“已开立账户”时，不能包含身份信息段、职业信息段、居住地址段");
                    }
                }
            }
            #endregion

            #region // 新增验证

            #endregion
        }

        /// <summary>
        /// 通用验证2
        /// </summary>
        /// zouql   16.09.27
        /// <param name="infoTypeId">信息记录标识</param>
        /// <param name="data">数据</param>
        public void Valid2(int infoTypeId, MessageInfo data)
        {
            var result = true;

            // 067 基础段中“当前逾期期数”、“当前逾期总额”两数据项值或同时为零或同时不为零
            result = true;
            var value0671 = GetValue(4109, "A", data);
            var value0672 = GetValue(1111, "A", data);

            if (!string.IsNullOrEmpty(value0671) && !string.IsNullOrEmpty(value0672))
            {
                if ((value0671 == value0672 && value0671 == "0") || (value0671 != "0" && value0672 != "0"))
                {
                    result = false;
                }

                if (result)
                {
                    ShowError(message: " 基础段中“当前逾期期数”、“当前逾期总额”两数据项值或同时为零或同时不为零");
                }
            }

            // 043 特殊交易段的“变更月数”字段值必须为整数（允许数字前填正、负号）
            result = true;
            var value043 = GetValue(4418, "G", data);

            if (!string.IsNullOrEmpty(value043))
            {
                if (value043.IndexOf('+') != -1 || value043.IndexOf('-') != -1)
                {
                    value043 = value043.Substring(1, value043.Length - 1);
                }

                var tempInt = -1;
                result = !int.TryParse(value043, out tempInt);

                if (result)
                {
                    ShowError(message: "特殊交易段的“变更月数”字段值必须为整数（允许数字前填正、负号）");
                }
            }

            // 042 特殊交易段中“发生日期”>=基础段中“开户日期”，特殊交易段中“发生日期”<=当前日期
            result = true;
            var value0421 = GetValue(2101, "A", data);
            var value0422 = GetValue(2410, "G", data);

            if (!string.IsNullOrEmpty(value0421) && !string.IsNullOrEmpty(value0422))
            {
                if (Convert.ToInt32(value0421) <= Convert.ToInt32(value0422) && Convert.ToInt32(value0422) <= Convert.ToInt32(string.Format("{0:yyyyMMdd}", DateTime.Now)))
                {
                    result = false;
                }

                if (result)
                {
                    ShowError(message: "特殊交易段中“发生日期”>=基础段中“开户日期”，特殊交易段中“发生日期”<=当前日期");
                }
            }



            // 039 本单位工作起始年份”为有效年份时，“本单位工作起始年份”<= 当前年份
            result = true;
            var value039 = GetValue(2019, "C", data);

            if (!string.IsNullOrEmpty(value039))
            {
                if (Convert.ToInt32(value039) > 1900 && Convert.ToInt32(value039) <= Convert.ToInt32(string.Format("{0:yyyy}", DateTime.Now)))
                {
                    result = false;
                }

                if (result)
                {
                    ShowError(message: "本单位工作起始年份”为有效年份时，“本单位工作起始年份”<= 当前年份");
                }
            }

            // 038 身份信息段中“婚姻状况”为“未婚”时，配偶信息均为空
            result = true;
            var value0380 = GetValue(5111, "B", data);

            if (!string.IsNullOrEmpty(value0380) && value0380 == "10")
            {
                var value0381 = GetValue(5204, "B", data);
                var value0382 = GetValue(5208, "B", data);
                var value0383 = GetValue(5210, "B", data);
                var value0384 = GetValue(5206, "B", data);
                var value0385 = GetValue(3111, "B", data);

                if (string.IsNullOrEmpty(value0381) && string.IsNullOrEmpty(value0382)
                    && string.IsNullOrEmpty(value0383) && string.IsNullOrEmpty(value0384)
                    && string.IsNullOrEmpty(value0385))
                {
                    result = false;
                }

                if (result)
                {
                    ShowError(message: "身份信息段中“婚姻状况”为“未婚”时，配偶信息均为空");
                }
            }

            // 037 基础段中“证件类型”为“0-身份证”时，基础段中“证件号码”必须为15位或18位，且15位身份证号码的每一位必须都是数字，18位身份证号码的前17位必须都是数字，18位身份证号码的最后一位必须都是数字或大写的X。
            result = true;
            var value0371 = GetValue(5107, "A", data);
            var value0372 = GetValue(5109, "A", data);

            if (!string.IsNullOrEmpty(value0371) && !string.IsNullOrEmpty(value0372))
            {
                var reg = Regex.Match(value0372, @"(^[1-9][0-9]{5}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])[0-9]{3}$)").Groups.Count > 1;
                reg |= Regex.Match(value0372, @"(^[1-9][0-9]{5}((19[0-9]{2})|(200[0-9])|2011)(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])[0-9]{3}[0-9xX]$)").Groups.Count > 1;
                if (value0371 == "0")
                {
                    if (reg)
                    {
                        result = false;
                    }

                    if (result)
                    {
                        ShowError(message: "基础段中证件号码错误");
                    }
                }
            }

            // 036 基础段中“业务种类”为“贷款”时，若“账户拥有者信息提示”为“2-新开立账户”且“结算/应还款日期”所在月等于“开户日期”所在月,则“逾期未归还贷款本金”均为0
            result = true;
            var value0361 = GetValue(7117, "A", data);
            var value0362 = GetValue(7121, "A", data);

            if (!string.IsNullOrEmpty(value0361) && !string.IsNullOrEmpty(value0362))
            {
                // 日期
                var value0363 = GetValue(2301, "A", data);
                var value0364 = GetValue(2101, "A", data);

                // “业务种类”为“贷款”,“账户拥有者信息提示”为“2-新开立账户”
                if (value0361 == "1" && value0362 == "2" && !string.IsNullOrEmpty(value0363) && !string.IsNullOrEmpty(value0364))
                {
                    if (value0363.Substring(4, 2).Equals(value0364.Substring(4, 2)))
                    {
                        // 逾期
                        var value0365 = GetValue(1113, "A", data);
                        var value0366 = GetValue(1115, "A", data);
                        var value0367 = GetValue(1117, "A", data);
                        var value0368 = GetValue(1119, "A", data);

                        if (value0365.Equals("0") && value0366.Equals("0") && value0367.Equals("0") && value0368.Equals("0"))
                        {
                            result = false;
                        }

                        if (result)
                        {
                            ShowError(message: "基础段中“业务种类”为“贷款”时，若“账户拥有者信息提示”为“2-新开立账户”且“结算/应还款日期”所在月等于“开户日期”所在月,则所有的逾期未归还贷款本金项均为0");
                        }
                    }
                }
            }

            // 配偶证件类型与证件号码同时为空或不为空
            result = true;
            var value5208 = GetValue(5208, "A", data);
            var value5210 = GetValue(5210, "A", data);

            if (!(value5208.Length + value5210.Length == 0 || (value5210.Length > 0 && value5210.Length > 0)))
            {
                if (value5208.Equals(0))
                {
                    var reg = Regex.Match(value5210, @"(^[1-9][0-9]{5}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])[0-9]{3}$)").Groups.Count > 1;
                    reg |= Regex.Match(value5210, @"(^[1-9][0-9]{5}((19[0-9]{2})|(200[0-9])|2011)(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])[0-9]{3}[0-9xX]$)").Groups.Count > 1;
                    if (reg)
                    {
                        ShowError(message: "配偶证件号码未通过校验");
                    }
                }

                ShowError(message: "配偶证件类型与证件号码同时为空或不为空");
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// zouql   16.09.26
        /// <param name="segments">段数组</param>
        /// <param name="segmentRules">段规则数组</param>
        /// <param name="mates">mate数组</param>
        protected override void GetData(out string[] segments, out string[] segmentRules, out string[] mates)
        {
            segments = new string[] { "A", "B", "C", "D", "E", "G", "H", "I", "J", "K" };

            var segmentList = new List<string>();

            var mateList = new List<string>();

            /* A
            业务种类A1930、业务种类细分A2020、发生地点A2022、开户日期A1934、到期日期A1935、币种A2025、授信额度A2026、共享授信额度A2027、
            最大负债额A2028、担保方式A2029、还款频率A2030、还款月数A1942、剩余还款月数A1943、结算/应还款日期A1944、最近一次实际还款日期A2034、
            本月应还款金额A1946、本月实际还款金额A1947、余额A1948、当前逾期期数A1949、当前逾期总额A1950、逾期31 - 60天未归还贷款本金A1951、
            逾期61 - 90天未归还贷款本金A1952、逾期91 - 180天未归还贷款本金A1953、逾期180天以上未归还贷款本金A1954、累计逾期期数A1955、
            最高逾期期数A1956、五级分类状态A1957、账户状态A1958、24个月（账户）还款状态A1959、透支180天以上未付余额A1960、账户拥有者信息提示A1961、
            姓名A1962、证件类型A1963、证件号码A1964、预留字段A1965
            */
            var sgeA = new string[] {
                "A1930",
                "A2020",
                "A2022",
                "A1934",
                "A1935",
                "A2025",
                "A2026",
                "A2027",
                "A2028",
                "A2029",
                "A2030",
                "A1942",
                "A1943",
                "A1944",
                "A2034",
                "A1946",
                "A1947",
                "A1948",
                "A1949",
                "A1950",
                "A1951",
                "A1952",
                "A1953",
                "A1954",
                "A1955",
                "A1956",
                "A1957",
                "A1958",
                "A1959",
                "A1960",
                "A1961",
                "A1962",
                "A1963",
                "A1964",
                "A1965"
            };
            segmentList.AddRange(sgeA);

            /* B
            性别B1967、出生日期B1968、婚姻状况B1969、最高学历B1970、最高学位B1971、住宅电话B1972、手机号码B1973、单位电话B1974、电子邮箱B1975、
            通讯地址B1976、通讯地址邮政编码B1977、户籍地址B1978、配偶姓名B1979、配偶证件类型B1980、配偶证件号码B1981、配偶工作单位B1982、
            配偶联系电话B1983
            */
            var sgeB = new string[] {
                "B1967",
                "B1968",
                "B1969",
                "B1970",
                "B1971",
                "B1972",
                "B1973",
                "B1974",
                "B1975",
                "B1976",
                "B1977",
                "B1978",
                "B1979",
                "B1980",
                "B1981",
                "B1982",
                "B1983"
            };
            segmentList.AddRange(sgeB);

            /* C
            职业C1985、单位名称C1986、单位所属行业C1987、单位地址C1988、单位地址邮政编码C1989、本单位工作起始年份C1990、职务C1991、职称C1992、
            年收入C1993、工资账号C1994、工资账户开户银行C1995
            */
            var sgeC = new string[] {
                "C1985",
                "C1986",
                "C1987",
                "C1988",
                "C1989",
                "C1990",
                "C1991",
                "C1992",
                "C1993",
                "C1994",
                "C1995"
            };
            segmentList.AddRange(sgeC);

            /* D
            居住地址D1997、居住地址邮政编码D1998、居住状况D1999
            */
            var sgeD = new string[] {
                "D1997",
                "D1998",
                "D1999"
            };
            segmentList.AddRange(sgeD);

            /* E
            姓名E2001、证件类型E2002、证件号码E2003、担保金额E2004、担保状态E2005
           */
            var sgeE = new string[] {
                "E2001",
                "E2002",
                "E2003",
                "E2004",
                "E2005"
            };
            segmentList.AddRange(sgeE);

            /* G
            特殊交易类型G2011、发生日期G2012、变更月数G2015、发生金额G2013、明细信息G2014
           */
            var sgeG = new string[] {
                "G2011",
                "G2012",
                "G2015",
                "G2013",
                "G2014"
            };
            segmentList.AddRange(sgeG);

            segmentRules = segmentList.ToArray();

            /* A
            业务种类7117、业务种类细分7111、发生地点3141、开户日期2101、到期日期2103、币种1418、授信额度1101、共享授信额度1102、
            最大负债额1103、担保方式7115、还款频率4111、还款月数4101、剩余还款月数4105、结算/应还款日期2301、最近一次实际还款日期2107、
            本月应还款金额1105、本月实际还款金额1107、余额1109、当前逾期期数4109、当前逾期总额1111、逾期31-60天未归还贷款本金1113、
            逾期61-90天未归还贷款本金1115、逾期91-180天未归还贷款本金1117、逾期180天以上未归还贷款本金1119、累计逾期期数4312、
            最高逾期期数4107、五级分类状态7105、账户状态7109、24个月（账户）还款状态7107、透支180天以上未付余额1210、账户拥有者信息提示7121、
            姓名5101、证件类型5107、证件号码5109、预留字段8107
            */
            var mateA = new string[] {
                "7117",
                "7111",
                "3141",
                "2101",
                "2103",
                "1418",
                "1101",
                "1102",
                "1103",
                "7115",
                "4111",
                "4101",
                "4105",
                "2301",
                "2107",
                "1105",
                "1107",
                "1109",
                "4109",
                "1111",
                "1113",
                "1115",
                "1117",
                "1119",
                "4312",
                "4107",
                "7105",
                "7109",
                "7107",
                "1210",
                "7121",
                "5101",
                "5107",
                "5109",
                "8107"
            };
            mateList.AddRange(mateA);

            /* B
            性别5105、出生日期2408、婚姻状况5111、最高学历5113、最高学位5115、住宅电话3115、手机号码3117、单位电话3119、电子邮箱3105、
            通讯地址3113、通讯地址邮政编码3109、户籍地址3101、配偶姓名5204、配偶证件类型5208、配偶证件号码5210、配偶工作单位5206、
            配偶联系电话3111
            */
            var mateB = new string[] {
                "5105",
                "2408",
                "5111",
                "5113",
                "5115",
                "3115",
                "3117",
                "3119",
                "3105",
                "3113",
                "3109",
                "3101",
                "5204",
                "5208",
                "5210",
                "5206",
                "3111"
            };
            mateList.AddRange(mateB);

            /* C
            职业5119、单位名称5117、单位所属行业6103、单位地址3133、单位地址邮政编码3129、本单位工作起始年份2109、职务5121、职称5123、
            年收入5125、工资账号7123、工资账户开户银行6105
            */
            var mateC = new string[] {
                "5119",
                "5117",
                "6103",
                "3133",
                "3129",
                "2109",
                "5121",
                "5123",
                "5125",
                "7123",
                "6105"
            };
            mateList.AddRange(mateC);

            /* D
            居住地址3103、居住地址邮政编码3121、居住状况5127
            */
            var mateD = new string[] {
                "3103",
                "3121",
                "5127"
            };
            mateList.AddRange(mateD);

            /* E
            姓名5101、证件类型5107、证件号码5109、担保金额1121、担保状态7119
            */
            var mateE = new string[] {
                "5101",
                "5107",
                "5109",
                "1121",
                "7119"
            };
            mateList.AddRange(new[] { "1121", "7119" });

            /* G
            特殊交易类型7113、发生日期2410、变更月数4418、发生金额1416、明细信息8101
            */
            var mateG = new string[] {
                "7113",
                "2410",
                "4418",
                "1416",
                "8101"
            };
            mateList.AddRange(mateG);

            mates = mateList.ToArray();
        }

        /// <summary>
        /// 错误显示
        /// </summary>
        /// zouql   16.09.30
        /// <param name="message">错误信息</param>
        protected void ShowError(object message)
        {
            throw new ApplicationException(message.ToString());
        }

        /// <summary>
        /// 数据类型校验
        /// </summary>
        /// zouql   16.09.28
        /// <param name="data"></param>
        private void BaseTypeComare(MessageInfo data)
        {
            // 基础段必填验证
            if (data.A.Count == 0)
            {
                ShowError(message: "基础段必填");
            }

            // 段规则Code集合
            var paragraphCodes = new List<string>() { "A", "B", "C", "D", "E", "G", "H", "I", "J", "K" };

            // 同一metaCode对应的不同段的值的集合
            var values = new List<string>();

            // Meta访问实例
            var metaMapper = new DAL.BankCredit.MetaMapper();

            // RuleType访问实例
            var ruleTypeMapper = new DAL.BankCredit.RuleTypeMapper();

            // 段规则校验实例
            var comPare = new DataAndRuleComPare();

            // 遍历metaCode
            foreach (var metaCode in PData.Mates.Keys)
            {
                foreach (var item in dataDic)
                {
                    // 必填项
                    if (item.Value.Substring(0, 1).Equals("M") && item.Value.Substring(1, item.Value.Length - 1).Equals(metaCode))
                    {
                        var value = GetValue(Convert.ToInt32(metaCode), item.Key.Substring(0, 1), data);
                        var paragraphData = SearchParegraphCode(item.Key.Substring(0, 1), data);
                        if (string.IsNullOrEmpty(value) && paragraphData != null && paragraphData.Count > 0)
                        {
                            ShowError(message: item.Key + "必填");
                        }
                    }
                }

                // 清空values
                values.Clear();

                // 获取同一metaCode对应的不同段的值的集合
                paragraphCodes.ForEach(delegate (string item)
                {
                    var value = GetValue(Convert.ToInt32(metaCode), item, data);

                    if (!string.IsNullOrEmpty(value))
                    {
                        values.AddRange(value.Split('.'));
                    }
                }
                );

                // 值存在，进一步校验
                if (values.Count > 0)
                {
                    // 获取MetaInfo
                    var metaInfo = metaMapper.Find(Convert.ToInt32(metaCode)) ?? new MetaInfo();

                    // 获取RuleType
                    var ruleTypeInfo = ruleTypeMapper.Find(Convert.ToInt32(metaCode)) ?? new RuleTypeInfo();

                    for (var i = 0; i < values.Count; i++)
                    {
                        #region 校验类型
                        if (!comPare.VarificationData(metaInfo, values[i]))
                        {
                            ShowError(message: "类型校验未通过");
                        }
                        #endregion

                        #region 贷款卡编码、组织机构代码校验
                        if (metaCode.Equals("7503") && metaCode.Equals("7505"))
                        {
                            if (!ValidFn.IdCard_Valid(values[i]))
                            {
                                ShowError(message: "贷款卡编码校验未通过");
                            }
                        }
                        else if (metaCode.Equals("6507") && metaCode.Equals("6511"))
                        {
                            if (!ValidFn.IdCard_Valid(values[i]))
                            {
                                ShowError(message: "组织机构代码校验未通过");
                            }
                        }
                        #endregion
                        else
                        {
                            #region 金额、时间、整数校验
                            var valueInt = -1;

                            if (ruleTypeInfo.MoneyType)
                            {
                                // 验证金额
                                if (!int.TryParse(values[i], out valueInt) && valueInt <= 0)
                                {
                                    ShowError(message: "金额校验未通过");
                                }
                            }
                            else if (ruleTypeInfo.TimeType)
                            {
                                // 验证时间
                                if (!int.TryParse(values[i], out valueInt) && valueInt < 19000101 && valueInt > Convert.ToInt32(string.Format("{0:yyyyMMdd}", DateTime.Now)))
                                {
                                    ShowError(message: "时间校验未通过");
                                }
                            }
                            else if (ruleTypeInfo.TimeType)
                            {
                                // 验证整数
                                if (!int.TryParse(values[i], out valueInt) && valueInt < 0)
                                {
                                    ShowError(message: "整数校验未通过");
                                }
                            }
                            #endregion
                        }
                    }

                }
            }
        }

        /// <summary>
        /// 获取段规则标识
        /// </summary>
        /// zouql   16.09.27
        /// <param name="metaCode">数据元Id</param>
        /// <param name="paragraphCode">段Code</param>
        /// <param name="data">数据</param>
        /// <returns>段规则标识</returns>
        private string GetValue(int metaCode, string paragraphCode, MessageInfo data)
        {
            ////var seg = paragraphCode + new SegmentRules().GetIdByMetaAndInfoType(infoTypeId, metaCode, paragraphCode);

            var seg = string.Empty;

            foreach (var item in dataDic)
            {
                if (item.Key.Substring(0, 1).Equals(paragraphCode) && item.Value.Substring(1, item.Value.Length - 1).Equals(metaCode.ToString()))
                {
                    seg = item.Key;
                    break;
                }
            }

            // 获取指定段的数据
            var value = SearchParegraphCode(paragraphCode, data) ?? new List<Dictionary<string, string>>();

            // 返回字符串
            var resultStr = string.Empty;

            for (var i = 0; i < value.Count; i++)
            {
                if (value[i].ContainsKey(seg))
                {
                    resultStr += "." + value[i][seg].Trim();
                }
            }
            resultStr = resultStr.Trim().Trim('.');

            return resultStr.Trim().Trim('.');
        }

        /// <summary>
        /// 从MessageInfo中查找指定的段
        /// </summary>
        /// zouql   16.09.30
        /// <param name="paragraphCode">段Code</param>
        /// <param name="data">数据</param>
        /// <returns>段</returns>
        private List<Dictionary<string, string>> SearchParegraphCode(string paragraphCode, MessageInfo data)
        {
            List<Dictionary<string, string>> value;
            switch (paragraphCode)
            {
                default:
                    value = null;
                    break;
                case "A":
                    value = data.A;
                    break;
                case "B":
                    value = data.B;
                    break;
                case "C":
                    value = data.C;
                    break;
                case "D":
                    value = data.D;
                    break;
                case "E":
                    value = data.E;
                    break;
                case "F":
                    value = data.F;
                    break;
                case "G":
                    value = data.G;
                    break;
                case "H":
                    value = data.H;
                    break;
                case "I":
                    value = data.I;
                    break;
                case "J":
                    value = data.J;
                    break;
                case "K":
                    value = data.K;
                    break;
            }

            return value;
        }
    }
}
