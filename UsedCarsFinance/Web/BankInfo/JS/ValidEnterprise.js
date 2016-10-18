// 判断值value在数组array中的位置
function ArrayIndexValue(array, value) {
    for (var i = 0; i < array.length; i++) {
        if (array[i] == value) {
            return i;
        }
    }

    return -1;
}

// 其他验证
function OtherValidEnterprise(value, options) {
    // 自定义验证
    $.extend($.fn.validatebox.defaults.rules, {
        EffectiveDate: {// 验证有效日期
            validator: function (value) {
                return value <= myformatter(new Date()) && value > '20050101';
            },
            message: '日期区间(20050101 , ' + myformatter(new Date()) + "]"
        },
        EffectiveProportion: {// 验证有效保证金比例
            validator: function (value) {
                return /^(\+|-)?\d+($|\d+$)/.test(value) && 0 <= value && value <= 100;
            },
            message: '比例区间 [0,100] ，且为整数'
        }
    });
    // 类型判断 - 添加验证(金额、时间、整数)
    options = ValidRuleTypeEnterprise(value, options);

    // MetaCode判断 - 添加验证
    options = ValidMetaCodeEnterprise(value, options);

    // 返回
    return options;
}

// 类型（RuleType）相关判断 - 添加验证
function ValidRuleTypeEnterprise(value, options) {
    if (value.RuleType.MoneyType) {
        // 金额类
        options += ",validType:['" + value.DataType + "','length[1," + value.Length + "]','Amount']";
    }
    else if (value.RuleType.TimeType) {
        // 时间类
        options += ",validType:['" + value.DataType + "','length[1," + value.Length + "]','Date','TimeTypeValid']";
    } else if (value.RuleType.IntegerType) {
        // 整数类
        options += ",validType:['" + value.DataType + "','length[1," + value.Length + "]','Integer']";
    }

    // 返回
    return options;
}

// MetaCode相关判断 - 添加验证
function ValidMetaCodeEnterprise(value, options) {
    var codes = [4505, 4503, 2503, 2591, 2501, 7609, 7619, 4511, 7503, 6511];
    if (codes.indexOf(value.MetaCode) != -1) {
        // 经营场地面积4505
        if (value.MetaCode == 4505) {
            options += ",validType:['" + value.DataType + "','length[1," + value.Length + "]','Integer']";
        }
            // 从业人数4503
        else if (value.MetaCode == 4503) {
            options += ",validType:['" + value.DataType + "','length[1," + value.Length + "]','PositiveInteger']";
        }
            // 借款人成立年份2503
        else if (value.MetaCode == 2503) {
            options += ",validType:['" + value.DataType + "','length[4,4]','EffectiveYear']";
        }
            // 报表年份2591
        else if (value.MetaCode == 2591) {
            options += ",validType:['" + value.DataType + "','length[4,4]']";
        }
            // 业务发生日期2501
        else if (value.MetaCode == 2501) {
            options += ",validType:['" + value.DataType + "','length[1," + value.Length + "]','EffectiveDate']";
        }
            // 抵押序号7609、质押序号7619
        else if (value.MetaCode == 7609 || value.MetaCode == 7619) {
            options += ",validType:['" + value.DataType + "','length[" + value.Length + "," + value.Length + "]']";
        }
            // 保证金比例4511
        else if (value.MetaCode == 4511) {
            options += ",validType:['EffectiveProportion','length[1," + value.Length + "]']";
        }
            // 贷款卡编码4511
        else if (value.MetaCode == 7503) {
            options += ",validType:['CreditCard','" + value.DataType + "','length[1," + value.Length + "]']";
        }// 组织机构代码4511
        else if (value.MetaCode == 6511) {
            options += ",validType:['" + value.DataType + "','length[1," + value.Length + "]','OrganizationCode["+true+"]']";
        }
    }
    else {
        // 接口规范102和授信额度1101、还款次数4507、展期次数4509、保函金额1539 (均>0)
        codes = [1511, 1517, 1519, 1523, 1525, 1527, 1531, 1535, 1539, 1543, 1545, 1547, 1551, 1557, 1559, 1571, 1573, 1577, 1101, 4507, 4509, 1539];
        if (codes.indexOf(value.MetaCode) != -1) {
            if (value.RuleType.MoneyType) { // 金额类
                options += ",validType:['" + value.DataType + "','length[1," + value.Length + "]','GreaterThanZero','Amount']";
            }
            else if (value.RuleType.TimeType) { // 时间类
                options += ",validType:['" + value.DataType + "','length[1," + value.Length + "]','GreaterThanZero','TimeTypeValid']";
            }
            else if (value.RuleType.IntegerType) { // 整数
                options += ",validType:['" + value.DataType + "','length[1," + value.Length + "]','GreaterThanZero','Integer']";
            }
            else { // 其他
                options += ",validType:['" + value.DataType + "','length[1," + value.Length + "]','GreaterThanZero','A']";
            }
        }
    }

    return options;
}


// 绑定事件
function BindInfoEventEnterprise(InfoTypeId) {
    // 贷款业务合同信息记录
    if (InfoTypeId == 10)
        LoanContractInfoValid();

        // 贷款业务借据信息记录
    else if (InfoTypeId == 11)
        LoanIousInfoValid();

        // 贷款业务还款信息记录
    else if (InfoTypeId == 12)
        LoanReimbursementInfoValid();

        // 保理业务信息记录
    else if (InfoTypeId == 14)
        FactoringInfoValid();

        // 票据贴现业务信息记录
    else if (InfoTypeId == 15)
        PaperInfoValid();

        // 融资协议信息记录
    else if (InfoTypeId == 16)
        FinanceAgreementInfoValid();

        // 融资业务还款信息记录
    else if (InfoTypeId == 18)
        FinanceReimbursementInfoValid();

        // 融资业务展期信息记录
    else if (InfoTypeId == 19)
        FinanceRolloverInfoValid

        // 信用证信息记录
    else if (InfoTypeId == 20)
        CreditCertInfoValid();

        // 保函业务信息记录
    else if (InfoTypeId == 21)
        LetterGuaranteeInfoValid();

        // 垫款业务信息记录
    else if (InfoTypeId == 30)
        AdvancesInfoValid();

        // 汇票业务信息记录
    else if (InfoTypeId == 22) {
        DraftInfoValid();
    }

        // 公开授信信息记录
    else if (InfoTypeId == 23) {
        PublicCreditInfoValid();
    }

        // 不良资产接收信息记录
    else if (InfoTypeId == 32) {
        BadAssetsReceivedInfoValid();
    }
        // 自然人质押信息记录
    else if (InfoTypeId == 25 || InfoTypeId == 26 || InfoTypeId == 29) {
        NaturalPersonPledgeInfoValid();
    }

    return InfoTypeId;
}

// 验证事件
function InfoValidEnterprise() {
    var InfoTypeId = uc.GetParams().infoTypeId;

    var result = true;
    // 贷款业务合同信息记录
    if (InfoTypeId == 10)
        result = result && LoanContractInfoDateValid();

        // 贷款业务借据信息记录
    else if (InfoTypeId == 11)
        result = result && LoanIousInfoDateValid();

        // 贷款业务还款信息记录
    else if (InfoTypeId == 12)
        result = result && LoanReimbursementInfoDateValid();

        // 保理业务信息记录
    else if (InfoTypeId == 14)
        result = result && FactoringInfoDateValid();

        // 票据贴现业务信息记录
    else if (InfoTypeId == 15)
        result = result && PaperInfoDateValid();

        // 融资协议信息记录
    else if (InfoTypeId == 16)
        result = result && FinanceAgreementInfoDateValid();

        // 融资业务还款信息记录
    else if (InfoTypeId == 18)
        result = result && FinanceReimbursementInfoDateValid();

        // 融资业务展期信息记录
    else if (InfoTypeId == 19)
        result = result && FinanceRolloverInfoDateValid();

        // 信用证信息记录
    else if (InfoTypeId == 20)
        result = result && CreditCertInfoDateValid

        // 保函业务信息记录
    else if (InfoTypeId == 21)
        result = result && LetterGuaranteeInfoDateValid();

        // 垫款业务信息记录
    else if (InfoTypeId == 30)
        result = result && AdvancesInfoDateValid

        // 汇票业务信息记录
    else if (InfoTypeId == 22)
        result = result && DraftInfoDateValid();

        // 公开授信信息记录
    else if (InfoTypeId == 23) {
        result = result && PublicCreditInfoDateValid();
    }

        // 不良资产接收信息记录
    else if (InfoTypeId == 32) {
        result = result && BadAssetsReceivedInfoDateValid();
    }

        // 自然人质押信息记录
    else if (InfoTypeId == 25 || InfoTypeId == 26 || InfoTypeId == 29) {
        result = result && NaturalPersonPledgeInfoDateValid();
    }

    return result;
}

// 错误提示
function MessageShow(param) {
    $.messager.show({ title: "错误提示", msg: param });
}

// 贷款业务合同信息记录
function LoanContractInfoValid() {
    // 合同生效日期必须小于终止日期
    if ($("input[meta_code=2511]")[1] != undefined && $("input[meta_code=2513]")[1] != undefined) {
        // 生效日期
        $("input[meta_code=2511]").eq(1).datebox({// onSelect事件
            onSelect: function (date) {
                LoanContractInfoDateValid();
            }
        });
        // 终止日期
        $("input[meta_code=2513]").eq(1).datebox({// onSelect事件
            onSelect: function (date) {
                LoanContractInfoDateValid();
            }
        });
    }

    // 担保标志为否，合同有效状态也为否
    if ($("select[meta_code=7523]")[1] != undefined && $("select[meta_code=7525]")[1] != undefined) {

        $("select[meta_code=7523]").eq(1).combobox({
            onChange: function () {
                if ($("select[meta_code=7523]").eq(1).combobox("getValue") == 2) {
                    // 合同有效状态修改
                    $("select[meta_code=7525]").eq(1).combobox({ readonly: true });
                    $("select[meta_code=7525]").eq(1).combobox("setValue", 2);
                }
                else {
                    // 合同有效状态修改恢复
                    $("select[meta_code=7525]").eq(1).combobox({ readonly: false });
                    $("select[meta_code=7525]").eq(1).combobox("setValue", "");
                }
            }
        });
    }

}
// 贷款业务合同信息记录 -- 合同日期验证
function LoanContractInfoDateValid() {
    if ($("input[meta_code=2511]")[1] != undefined && $("input[meta_code=2513]")[1] != undefined) {
        // 生效日期
        var StartValue = $("input[meta_code=2511]").eq(1).datebox('getValue');
        // 终止日期
        var EndValue = $("input[meta_code=2513]").eq(1).datebox('getValue')

        if (StartValue.length > 0 && EndValue.length > 0 && StartValue > EndValue) {
            MessageShow("合同信息段：合同生效日期必须小于等于终止日期");

            return false;
        }
    }

    return true;
}

// 贷款业务借据信息记录
function LoanIousInfoValid() {
    // 业务发生日期
    $("input[meta_code=2501]").eq(1).datebox({
        onSelect: function () {
            LoanIousInfoDateValid();
        }
    });

    // 借据放款日
    $("input[meta_code=2515]").eq(1).datebox({
        onSelect: function () {
            LoanIousInfoDateValid();
        }
    });
}
function LoanIousInfoDateValid() {
    if ($("input[meta_code=2501]")[1] != undefined && $("input[meta_code=2515]")[1] != undefined) {
        // 业务发生日期
        var StartValue = $("input[meta_code=2501]").eq(1).datebox('getValue');
        // 借据放款日
        var EndValue = $("input[meta_code=2515]").eq(1).datebox('getValue');

        if (StartValue.length > 0 && EndValue.length > 0 && StartValue < EndValue) {
            MessageShow("业务发生日期应大于等于借据放款日期");

            return false;
        }
    }

    return true;
}

// 贷款业务还款信息记录
function LoanReimbursementInfoValid() {
    // 业务发生日期
    $("input[meta_code=2501]").eq(1).datebox({
        onSelect: function () {
            LoanReimbursementInfoDateValid();
        }
    });

    // 还款日期
    $("input[meta_code=2519]").eq(1).datebox({
        onSelect: function () {
            LoanReimbursementInfoDateValid();
        }
    });
}
function LoanReimbursementInfoDateValid() {
    if ($("input[meta_code=2501]")[1] != undefined && $("input[meta_code=2519]")[1] != undefined) {
        // 业务发生日期
        var StartValue = $("input[meta_code=2501]").eq(1).datebox('getValue');
        // 还款日期
        var EndValue = $("input[meta_code=2519]").eq(1).datebox('getValue');

        if (StartValue.length > 0 && EndValue.length > 0 && StartValue < EndValue) {
            MessageShow("业务发生日期应大于等于还款日期");

            return false;
        }
    }

    return true;
}

// 保理业务信息记录
function FactoringInfoValid() {
    // 业务发生日期
    $("input[meta_code=2501]").eq(1).datebox({
        onSelect: function () {
            FactoringInfoDateValid();
        }
    });

    // 续做日期
    $("input[meta_code=2525]").eq(1).datebox({
        onSelect: function () {
            FactoringInfoDateValid();
        }
    });

    // 余额变化日期
    $("input[meta_code=2527]").eq(1).datebox({
        onSelect: function () {
            FactoringInfoDateValid();
        }
    });
}
function FactoringInfoDateValid() {
    if ($("input[meta_code=2501]")[1] != undefined && $("input[meta_code=2525]")[1] != undefined && $("input[meta_code=2527]")[1] != undefined) {
        // 业务发生日期
        var Value1 = $("input[meta_code=2501]").eq(1).datebox('getValue');
        // 续做日期
        var Value2 = $("input[meta_code=2525]").eq(1).datebox('getValue');
        // 余额变化日期
        var Value3 = $("input[meta_code=2527]").eq(1).datebox('getValue');

        if (Value1.length > 0 && Value2.length > 0 && Value1 <= Value2) {
            MessageShow("业务发生日期应大于续做日期");

            return false;
        }

        if (Value3.length > 0 && Value2.length > 0 && Value3 <= Value2) {
            MessageShow("余额变化日期应大于续做日期");

            return false;
        }

        if (Value3.length > 0 && Value1.length > 0 && Value3 > Value1) {
            MessageShow("余额变化日期应小于等于业务发生日期");

            return false;
        }
    }

    return true;
}

// 票据贴现信息记录
function PaperInfoValid() {
    // 业务发生日期
    $("input[meta_code=2501]").eq(1).datebox({
        onSelect: function () {
            PaperInfoDateValid();
        }
    });

    // 贴现日期
    $("input[meta_code=2529]").eq(1).datebox({
        onSelect: function () {
            PaperInfoDateValid();
        }
    });

    // 承兑到期日
    $("input[meta_code=2531]").eq(1).datebox({
        onSelect: function () {
            PaperInfoDateValid();
        }
    });
}
function PaperInfoDateValid() {
    if ($("input[meta_code=2501]")[1] != undefined && $("input[meta_code=2529]")[1] != undefined && $("input[meta_code=2531]")[1] != undefined) {
        // 业务发生日期
        var Value1 = $("input[meta_code=2501]").eq(1).datebox('getValue');
        // 贴现日期
        var Value2 = $("input[meta_code=2529]").eq(1).datebox('getValue');
        // 承兑到期日
        var Value3 = $("input[meta_code=2531]").eq(1).datebox('getValue');

        if (Value1.length > 0 && Value2.length > 0 && Value1 < Value2) {
            MessageShow("业务发生日期应大于等于贴现日期");

            return false;
        }

        if (Value3.length > 0 && Value2.length > 0 && Value3 < Value2) {
            MessageShow("承兑到期日应大于等于贴现日期");

            return false;
        }
    }

    return true;
}

// 融资协议信息记录
function FinanceAgreementInfoValid() {
    //融资协议金额应大于等于融资协议余额
    //融资协议金额信息段中若为多段，币种必须不一样

    // 融资协议金额
    $("input[meta_code=1527]").eq(1).textbox({
        onChange: function () {
            FinanceAgreementInfoDateValid();
        }
    }
    );

    // 融资协议余额
    $("input[meta_code=1529]").eq(1).textbox({
        onChange: function () {
            FinanceAgreementInfoDateValid();
        }
    });
}
function FinanceAgreementInfoDateValid() {
    // 融资协议金额
    var Value1 = $("input[meta_code=1527]").eq(1).textbox('getValue').trim();
    // 融资协议余额
    var Value2 = $("input[meta_code=1529]").eq(1).textbox('getValue').trim();

    // 币种
    var Currency = $("select[meta_code=1501]");

    if (Value1.length > 0 && Value2.length > 0 && Value1 < Value2) {
        MessageShow("融资协议金额应大于等于融资协议余额");

        return false;
    }
        // 多个金额信息段
    else if (Currency.length > 2) {
        var tempArray = new Array(), tempValue;

        // 存储币种Value
        for (var i = 1; i < Currency.length - 1; i++) {
            tempValue = Currency.eq(i).combobox('getValue');
            if (tempValue.length > 0 && tempArray.indexOf(tempValue) != -1) {
                tempArray.push(tempArray);
            }
        }

        // 币种Value重复
        if (Currency.length - 1 > tempArray.length) {
            MessageShow("融资协议金额信息段 - 币种必须不一样");

            return false;
        }

    }

    return true;
}

// 融资业务还款信息记录
function FinanceReimbursementInfoValid() {
    //业务发生日期应大于等于还款日期

    // 业务发生日期
    $("input[meta_code=2501]").eq(1).datebox({
        onSelect: function () {
            LoanReimbursementInfoDateValid();
        }
    });

    // 还款日期
    $("input[meta_code=2519]").eq(1).datebox({
        onSelect: function () {
            LoanReimbursementInfoDateValid();
        }
    });
}
function FinanceReimbursementInfoDateValid() {
    if ($("input[meta_code=2501]")[1] != undefined && $("input[meta_code=2519]")[1] != undefined) {
        // 业务发生日期
        var StartValue = $("input[meta_code=2501]").eq(1).datebox('getValue');
        // 还款日期
        var EndValue = $("input[meta_code=2519]").eq(1).datebox('getValue');

        if (StartValue.length > 0 && EndValue.length > 0 && StartValue < EndValue) {
            MessageShow("业务发生日期应大于等于还款日期");

            return false;
        }

        return true;
    }
}

// 融资业务展期信息记录
function FinanceRolloverInfoValid() {
    // 展期起始日期
    $("input[meta_code=2521]").eq(1).datebox({
        onSelect: function () {
            FinanceRolloverInfoDateValid();
        }
    });

    // 展期到期日期
    $("input[meta_code=2523]").eq(1).datebox({
        onSelect: function () {
            FinanceRolloverInfoDateValid();
        }
    });
}
function FinanceRolloverInfoDateValid() {
    if ($("input[meta_code=2521]")[1] != undefined && $("input[meta_code=2523]")[1] != undefined) {
        // 展期起始日期
        var StartValue = $("input[meta_code=2521]").eq(1).datebox('getValue');
        // 展期到期日期
        var EndValue = $("input[meta_code=2523]").eq(1).datebox('getValue');

        if (StartValue.length > 0 && EndValue.length > 0 && StartValue > EndValue) {
            MessageShow("展期起始日期应小于等于展期到期日期");

            return false;
        }

        return true;
    }
}

// 信用证信息记录
function CreditCertInfoValid() {
    // 业务发生日期
    $("input[meta_code=2501]").eq(1).datebox({
        onSelect: function () {
            CreditCertInfoDateValid();
        }
    });

    // 开证日期
    $("input[meta_code=2541]").eq(1).datebox({
        onSelect: function () {
            CreditCertInfoDateValid();
        }
    });

    // 信用证注销日期
    $("input[meta_code=2581]").eq(1).datebox({
        onSelect: function () {
            CreditCertInfoDateValid();
        }
    });

    // 余额报告日期
    $("input[meta_code=2545]").eq(1).datebox({
        onSelect: function () {
            CreditCertInfoDateValid();
        }
    });

    // 信用证状态为注销时才能填写注销日期
    $("select[meta_code=7501]").eq(1).combobox({
        onChange: function () {
            if ($("select[meta_code=7501]").eq(1).combobox("getValue") == 1) {
                // 信用证注销日期状态修改
                $("input[meta_code=2581]").eq(1).datebox('readonly', true)
                $("input[meta_code=2581]").eq(1).datebox('setValue', '')
            }
            else {
                // 信用证注销日期修改恢复
                $("input[meta_code=2581]").eq(1).datebox('readonly', false);
                $("input[meta_code=2581]").eq(1).datebox('setValue', '')
            }
        }
    });
}
function CreditCertInfoDateValid() {
    // 业务发生日期
    var Value1 = $("input[meta_code=2501]").eq(1).datebox('getValue');
    // 开证日期
    var Value2 = $("input[meta_code=2541]").eq(1).datebox('getValue');
    // 信用证注销日期
    var Value3 = $("input[meta_code=2581]").eq(1).datebox('getValue');
    // 余额报告日期
    var Value4 = $("input[meta_code=2545]").eq(1).datebox('getValue');

    if (Value1.length > 0 && Value2.length > 0 && Value1 < Value2) {
        MessageShow("业务发生日期应大于等于开证日");

        return false;
    }
    else if (Value1.length > 0 && Value3.length > 0 && Value1 < Value3) {
        MessageShow("业务发生日期应大于等于信用证注销日期");

        return false;
    }
    else if (Value2.length > 0 && Value4.length > 0 && Value4 < Value2) {
        MessageShow("余额报告日期应大于等于开证日期");

        return false;
    }
    else if (Value3.length > 0 && Value4.length > 0 && Value3 < Value4) {
        MessageShow("信用证注销日期应大于等于余额报告日期");

        return false;
    }

    return true;
}

// 保函业务信息记录
function LetterGuaranteeInfoValid() {
    // 保函金额
    $("input[meta_code=1539]").eq(1).textbox({
        onChange: function () {
            LetterGuaranteeInfoDateValid();
        }
    });

    // 保函余额
    $("input[meta_code=1541]").eq(1).textbox({
        onChange: function () {
            LetterGuaranteeInfoDateValid();
        }
    });

    // 业务发生日期
    $("input[meta_code=2501]").eq(1).datebox({
        onSelect: function () {
            LetterGuaranteeInfoDateValid();
        }
    });

    // 余额发生日期
    $("input[meta_code=2551]").eq(1).datebox({
        onSelect: function () {
            LetterGuaranteeInfoDateValid();
        }
    });

    // 保函开立日期
    $("input[meta_code=2547]").eq(1).datebox({
        onSelect: function () {
            LetterGuaranteeInfoDateValid();
        }
    });

    // 到期日期
    $("input[meta_code=2549]").eq(1).datebox({
        onSelect: function () {
            LetterGuaranteeInfoDateValid();
        }
    });
}
function LetterGuaranteeInfoDateValid() {
    // 保函金额
    var Value1 = $("input[meta_code=1539]").eq(1).textbox('getValue').trim();
    // 保函余额
    var Value2 = $("input[meta_code=1541]").eq(1).textbox('getValue').trim();


    // 业务发生日期
    var Value3 = $("input[meta_code=2501]").eq(1).datebox('getValue');
    // 余额发生日期
    var Value4 = $("input[meta_code=2551]").eq(1).datebox('getValue');
    // 保函开立日期
    var Value5 = $("input[meta_code=2547]").eq(1).datebox('getValue');
    // 保函到期日期
    var Value6 = $("input[meta_code=2549]").eq(1).datebox('getValue');

    if (Value1.length > 0 && Value2.length > 0 && Value1 < Value2) {
        MessageShow("保函金额应大于等于保函余额");

        return false;
    }
    else if (Value3.length > 0 && Value4.length > 0 && Value3 < Value4) {
        MessageShow("业务发生日期应大于等于余额发生日期");

        return false;
    }
    else if (Value4.length > 0 && Value5.length > 0 && Value4 < Value5) {
        MessageShow("余额发生日期应大于等于保函开立日期");

        return false;
    }
    else if (Value5.length > 0 && Value6.length > 0 && Value5 >= Value6) {
        MessageShow("保函到期日应大于应大于保函开立日期");

        return false;
    }

    return true;
}

// 垫款信息记录
function AdvancesInfoValid() {
    // 四级分类为空错误
    $("select[meta_code = 7539]").combobox({ 'required': true });

    // 垫款金额
    $("input[meta_code=1559]").eq(1).textbox({
        onChange: function () {
            AdvancesInfoDateValid();
        }
    });

    // 垫款余额
    $("input[meta_code=1561]").eq(1).textbox({
        onChange: function () {
            AdvancesInfoDateValid();
        }
    });

    // 业务发生日期
    $("input[meta_code=2501]").eq(1).datebox({
        onSelect: function () {
            AdvancesInfoDateValid();
        }
    });

    // 垫款日期
    $("input[meta_code=2571]").eq(1).datebox({
        onSelect: function () {
            AdvancesInfoDateValid();
        }
    });

    // 余额发生日期
    $("input[meta_code=2551]").eq(1).datebox({
        onSelect: function () {
            AdvancesInfoDateValid();
        }
    });



}
function AdvancesInfoDateValid() {
    // 垫款金额
    var Value1 = $("input[meta_code=1559]").eq(1).textbox('getValue').trim();
    // 垫款余额
    var Value2 = $("input[meta_code=1561]").eq(1).textbox('getValue').trim();

    // 业务发生日期
    var Value3 = $("input[meta_code=2501]").eq(1).datebox('getValue');
    // 垫款日期
    var Value4 = $("input[meta_code=2571]").eq(1).datebox('getValue');
    // 余额发生日期
    var Value5 = $("input[meta_code=2551]").eq(1).datebox('getValue');

    if (Value1.length > 0 && Value2.length > 0 && Value1 < Value2) {
        MessageShow("垫款金额应大于等于垫款余额");

        return false;
    }
    else if (Value3.length > 0 && Value4.length > 0 && Value3 < Value4) {
        MessageShow("业务发生日期应大于等于垫款日期");

        return false;
    }
    else if (Value3.length > 0 && Value5.length > 0 && Value3 < Value5) {
        MessageShow("业务发生日期应大于等于余额发生日期");

        return false;
    }

    return true;
}

// 汇票业务信息记录
function DraftInfoValid() {
    // 业务发生日期
    $("input[meta_code=2501]").eq(1).datebox({
        onSelect: function () {
            DraftInfoDateValid();
        }
    });

    // 汇票承兑日期
    $("input[meta_code=2553]").eq(1).datebox({
        onSelect: function () {
            DraftInfoDateValid();
        }
    });

    // 汇票付款日期
    $("input[meta_code=2557]").eq(1).datebox({
        onSelect: function () {
            DraftInfoDateValid();
        }
    });

}
function DraftInfoDateValid() {
    // 业务发生日期
    var Value1 = $("input[meta_code=2501]").eq(1).datebox('getValue');
    // 汇票承兑日期
    var Value2 = $("input[meta_code=2553]").eq(1).datebox('getValue');
    // 汇票付款日期
    var Value3 = $("input[meta_code=2557]").eq(1).datebox('getValue');

    if (Value1.length > 0 && Value2.length > 0 && Value1 < Value2) {
        MessageShow("业务发生日期应大于等于承兑日期");

        return false;
    }
    else if (Value2.length > 0 && Value3.length > 0 && Value2 >= Value3) {
        MessageShow("汇票承兑日期应小于等于汇票付款日期");

        return false;
    }

    return true;
}

// 公开授信信息记录
function PublicCreditInfoValid() {
    // 授信生效起始日期
    $("input[meta_code=2559]").eq(1).datebox({
        onSelect: function () {
            PublicCreditInfoDateValid();
        }
    });

    // 授信额度注销生效日期
    $("input[meta_code=2563]").eq(1).datebox({
        onSelect: function () {
            PublicCreditInfoDateValid();
        }
    });

    // 授信终止日期
    $("input[meta_code=2561]").eq(1).datebox({
        onSelect: function () {
            PublicCreditInfoDateValid();
        }
    });

}
function PublicCreditInfoDateValid() {
    // 授信额度注销生效日期应大于等于授信生效起始日期且小于等于授信终止日期

    // 授信生效起始日期
    var Value1 = $("input[meta_code=2559]").eq(1).datebox('getValue');
    // 授信注销生效日期
    var Value2 = $("input[meta_code=2563]").eq(1).datebox('getValue');
    // 授信终止日期
    var Value3 = $("input[meta_code=2561]").eq(1).datebox('getValue');

    if (Value1.length > 0 && Value2.length > 0 && Value2 < Value1) {
        MessageShow("授信注销生效日期应大于等于授信生效起始日期");

        return false;
    }
    else if (Value2.length > 0 && Value3.length > 0 && Value2 >= Value3) {
        MessageShow("授信注销生效日期应小于等于授信终止日期");

        return false;
    }

    return true;
}

// 不良资产接收信息记录
function BadAssetsReceivedInfoValid() {
    // 已回收金额不能为空
    $("input[meta_code = 1585]").textbox({ 'required': true });

    // 贷款卡编码
    $("input[meta_code=7503]").eq(1).textbox({
        onChange: function () {
            BadAssetsReceivedInfoDateValid();
        }
    });

    // 组织机构代码
    $("input[meta_code=6511]").eq(1).textbox({
        onChange: function () {
            BadAssetsReceivedInfoDateValid();
        }
    });

    // 登记注册号
    $("input[meta_code=5517]").eq(1).textbox({
        onChange: function () {
            BadAssetsReceivedInfoDateValid();
        }
    });

}
function BadAssetsReceivedInfoDateValid() {
    // 贷款卡编码
    var Value1 = $("input[meta_code=7503]").eq(1).textbox('getValue').trim();
    // 组织机构代码
    var Value2 = $("input[meta_code=6511]").eq(1).textbox('getValue').trim();
    // 登记注册号
    var Value3 = $("input[meta_code=5517]").eq(1).textbox('getValue').trim();

    if (Value1.length == 0 && Value2.length == 0 && Value2.length == 0) {
        MessageShow("贷款卡编码、组织机构代码、登记注册号不能同时为空");

        return false;
    }

    return true;
}

// 自然人质押信息记录
function NaturalPersonPledgeInfoValid() {
    // 业务发生日期
    $("input[meta_code=2501]").eq(1).datebox({
        onSelect: function () {
            NaturalPersonPledgeInfoDateValid();
        }
    });

    // 合同签订日期
    $("input[meta_code=2565]").eq(1).textbox({
        onChange: function () {
            BadAssetsReceivedInfoDateValid();
        }
    });
}
function NaturalPersonPledgeInfoDateValid() {
    // 业务发生日期2501
    var Value1 = $("input[meta_code=2501]").eq(1).datebox('getValue');
    // 合同签订日期2565
    var Value2 = $("input[meta_code=2565]").eq(1).datebox('getValue');

    if (Value1.length > 0 && Value2.length > 0 && Value1 < Value2) {
        MessageShow("业务发生日期应大于等于合同签订日期");

        return false;
    }

    return true;
}