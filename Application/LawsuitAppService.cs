namespace Application
{
    using Application.ViewModels.LitigationViewModels;
    using Core.Entities.Concern;

    public class LawsuitAppService
    {
        public bool Create(LitigationViewModel model)
        {
            var litigation = new Litigation()
            {
                ChargedSerialNumber = model.ChargedSerialNumber,
                Currency = model.Currency,
                DateTime = model.DateTime,
                Money = model.Money,
                ProsecuteName = model.ProsecuteName,
                Reason = model.Reason,
                Result = model.Result
            };

            var litigationBasePeriod = new LitigationBasePeriod()
            {
                BorrowName = model.BorrowName,
                BusinessDate = model.BusinessDate,
                LoanCardCode = model.LoanCardCode
            };

            return true;
        }
    }
}
