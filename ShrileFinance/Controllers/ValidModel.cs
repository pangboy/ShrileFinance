namespace Web.Controllers.BankCredit
{
    using System.Text;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;

    /// <summary>
    /// 输出Model验证错误信息
    /// </summary>
    public class ValidModel : ApiController
    {
        #region ShowError
        /// <summary>
        /// 输出模型验证得到的所有错误信息
        /// </summary>
        /// <param name="modelState">模型验证</param>
        /// <returns>错误信息</returns>
        [NonAction]
        public static string ShowError(ModelStateDictionary modelState)
        {
            var errorMessage = new StringBuilder();

            if (!modelState.IsValid)
            {
                foreach (var value in modelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errorMessage.Append(error.ErrorMessage + "\t");
                    }
                }

                errorMessage.Append("\n");
            }

            return errorMessage.ToString();
        }

        /// <summary>
        /// 输出模型验证得到的第一条错误信息
        /// </summary>
        /// <param name="modelState">模型验证</param>
        /// <returns>错误信息</returns>
        [NonAction]
        public static string ShowErrorFirst(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                foreach (var value in modelState.Values)
                {
                    return value.Errors[0].ErrorMessage;
                }
            }

            return string.Empty;
        }
        #endregion
    }
}
