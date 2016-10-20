using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Web.Controllers.BankCredit
{
    /// <summary>
    /// 输出Model验证错误信息
    /// </summary>
    public class ValidModel : ApiController
    {
        private ValidModel()
        {
        }

        private static ValidModel ShowValidError { get; set; }

        #region ShowError
        [NonAction]
        public static string ShowError(ModelStateDictionary modelState)
        {
            ShowValidError = ShowValidError ?? new ValidModel();

            return ShowValidError.Show(modelState);
        }

        [NonAction]
        public string Show(ModelStateDictionary modelState)
        {
            var errorMessage = string.Empty;

            if (!modelState.IsValid)
            {
                foreach (var err in modelState.Values)
                {
                    foreach (var e in err.Errors)
                    {
                        errorMessage += e.ErrorMessage + "\t";
                    }
                }

                errorMessage += "\n";
            }

            return errorMessage;
        }
        #endregion
    }
}
