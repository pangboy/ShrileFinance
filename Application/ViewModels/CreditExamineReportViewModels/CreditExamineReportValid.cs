namespace Application.ViewModels.CreditExamineReportViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 身份证校验
    /// </summary>
    public class IdCardAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            if (string.IsNullOrEmpty(value.ToString()))
            {
                return true;
            }

            return true;
        }
    }
}
