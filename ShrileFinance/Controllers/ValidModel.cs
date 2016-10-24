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
        private readonly ModelStateDictionary modelState;

        private ValidModel(ModelStateDictionary modelState)
        {
            this.modelState = modelState;
        }

        #region ShowError
        [NonAction]
        public static string ShowError(ModelStateDictionary modelState)
        {
            return new ValidModel(modelState).Show();
        }

        [NonAction]
        public string Show()
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
        #endregion
    }
}
