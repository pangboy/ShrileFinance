namespace Application.Mappings
{
    using AutoMapper;
    using Core.Entities.Loan;
    using ViewModels.Loan.CreditViewModel;
    using ViewModels.Loan.LoanViewModels;

    public class LoanDomainToViewModelProfile : Profile
    {
        public LoanDomainToViewModelProfile()
        {
            CreateMap<Loan, LoanViewModel>();
            CreateMap<PaymentHistory, PaymentHistoryViewModel>();
            CreateMap<CreditContract, CreditContractViewModel>()
                .ForMember(d => d.GuranteeContract, o => o.Ignore())
                .ForMember(d => d.GuarantyContract, o => o.Ignore());

            CreateMap<GuarantyContract, GuarantyContractViewModel>()
                .Include<GuarantyContractPledge, GuarantyContractPledgeViewModel>()
                .Include<GuarantyContractMortgage, GuarantyContractMortgageViewModel>()
                .ForMember(d => d.Guarantor, o => o.MapFrom(t => t.Guarantor))
                .ConstructUsing(m =>
                {
                    if (m is GuarantyContractPledge)
                    {
                        return new GuarantyContractPledgeViewModel();
                    }
                    else if (m is GuarantyContractMortgage)
                    {
                        return new GuarantyContractMortgageViewModel();
                    }

                    return new GuarantyContractViewModel();
                });
            CreateMap<GuarantyContractPledge, GuarantyContractPledgeViewModel>();
            CreateMap<GuarantyContractMortgage, GuarantyContractMortgageViewModel>();

            CreateMap<Guarantor, GuarantorViewModel>()
                .Include<GuarantorOrganization, GuarantyOrganizationViewModel>()
                .Include<GuarantorPerson, GuarantyPersonViewModel>()
                .ConstructUsing(m =>
                {
                    if (m is GuarantorOrganization)
                    {
                        return new GuarantyOrganizationViewModel();
                    }
                    else if (m is GuarantorPerson)
                    {
                        return new GuarantyPersonViewModel();
                    }
                    else
                    {
                        return null;
                    }
                });
            CreateMap<GuarantorOrganization, GuarantyOrganizationViewModel>();
            CreateMap<GuarantorPerson, GuarantyPersonViewModel>();
        }
    }
}
