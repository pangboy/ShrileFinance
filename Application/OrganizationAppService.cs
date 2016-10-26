namespace Application
{
    using System;
    using Core.Entities.Customers.Enterprise;
    using Core.Interfaces.Repositories;
    using ViewModels.OrganizationViewModels;

    public class OrganizationAppService
    {
        private readonly IOrganizationRepository repository;

        public OrganizationAppService(IOrganizationRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// yand    16.10.25
        /// <param name="model">实体</param>
        public void Create(BaseViewModel model)
        {
            var customer = new Core.Entities.Customers.Enterprise.Organization()
            {
                ////Id = model.Id,
                ////BasicAccountState = model.BasicAccountState,
                ////BusinessScope = model.BusinessScope,
                ////CertificateDueDate = model.CertificateDueDate,
                ////ContactPhone = model.ContactPhone,
                ////Country = model.Country,
                ////CustomerNumber = model.CustomerNumber,
                ////CustomerType = model.CustomerType,
                ////DataExtractionDate = model.DataExtractionDate,
                ////EconomicSectorsClassification = model.EconomicSectorsClassification,
                ////EconomicType = model.EconomicType,
                ////EnterpriseScale = model.EnterpriseScale,
                ////FinancialContactPhone = model.FinancialContactPhone,
                ////InstitutionChName = model.InstitutionChName,
                ////InstitutionCreditCode = model.InstitutionCreditCode,
                ////InstitutionsState = model.LoanCardCode,
                ////LoanCardCode = model.LoanCardCode,
                ////ManagementerCode = model.ManagementerCode,
                ////NewaccountlicenseNumber = model.NewaccountlicenseNumber,
                ////OfficeAddress = model.OfficeAddress,
                ////OrganizateCode = model.OrganizateCode,
                ////OrganizationCategory = model.OrganizationCategory,
                ////OrganizationCategorySubdivision = model.OrganizationCategorySubdivision,
                ////RegisterAddress = model.RegisterAddress,
                ////RegisterAdministrativeDivision = model.RegisterAdministrativeDivision,
                ////RegisterCapital = model.RegisterCapital,
                ////RegisterCapitalCurrency = model.RegisterCapitalCurrency,
                ////RegistrationNumber = model.RegistrationNumber,
                ////RegistrationNumberType = model.RegistrationNumberType,
                ////SetupDate = model.SetupDate,
                ////TaxpayerIdentifyIrsNumber = model.TaxpayerIdentifyIrsNumber,
                ////TaxpayerIdentifyLandNumber = model.TaxpayerIdentifyLandNumber,
                ////ExecutivesMajorParticipant = model.ExecutivesMajorParticipant,
                ////MainAssociatedEnterprise = model.MainAssociatedEnterprise,
                ////Shareholders = model.Shareholders,
                ////SuperInstitution = model.SuperInstitution
            };
            repository.Create(customer);
            repository.Commit();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yand    16.10.25
        /// <param name="model">实体</param>
        public void Modify(BaseViewModel model)
        {
            var customer = new Core.Entities.Customers.Enterprise.Organization()
            {
                ////Id = model.Id,
                ////BasicAccountState = model.BasicAccountState,
                ////BusinessScope = model.BusinessScope,
                ////CertificateDueDate = model.CertificateDueDate,
                ////ContactPhone = model.ContactPhone,
                ////Country = model.Country,
                ////CustomerNumber = model.CustomerNumber,
                ////CustomerType = model.CustomerType,
                ////DataExtractionDate = model.DataExtractionDate,
                ////EconomicSectorsClassification = model.EconomicSectorsClassification,
                ////EconomicType = model.EconomicType,
                ////EnterpriseScale = model.EnterpriseScale,
                ////FinancialContactPhone = model.FinancialContactPhone,
                ////InstitutionChName = model.InstitutionChName,
                ////InstitutionCreditCode = model.InstitutionCreditCode,
                ////InstitutionsState = model.LoanCardCode,
                ////LoanCardCode = model.LoanCardCode,
                ////ManagementerCode = model.ManagementerCode,
                ////NewaccountlicenseNumber = model.NewaccountlicenseNumber,
                ////OfficeAddress = model.OfficeAddress,
                ////OrganizateCode = model.OrganizateCode,
                ////OrganizationCategory = model.OrganizationCategory,
                ////OrganizationCategorySubdivision = model.OrganizationCategorySubdivision,
                ////RegisterAddress = model.RegisterAddress,
                ////RegisterAdministrativeDivision = model.RegisterAdministrativeDivision,
                ////RegisterCapital = model.RegisterCapital,
                ////RegisterCapitalCurrency = model.RegisterCapitalCurrency,
                ////RegistrationNumber = model.RegistrationNumber,
                ////RegistrationNumberType = model.RegistrationNumberType,
                ////SetupDate = model.SetupDate,
                ////TaxpayerIdentifyIrsNumber = model.TaxpayerIdentifyIrsNumber,
                ////TaxpayerIdentifyLandNumber = model.TaxpayerIdentifyLandNumber,
                ////ExecutivesMajorParticipant = model.ExecutivesMajorParticipant,
                ////MainAssociatedEnterprise = model.MainAssociatedEnterprise,
                ////Shareholders = model.Shareholders,
                ////SuperInstitution = model.SuperInstitution
            };
            repository.Modify(customer);
            repository.Commit();
        }

        /// <summary>
        /// 根据ID获取客户信息
        /// </summary>
        /// yand    16.10.25
        /// <param name="id">id</param>
        /// <returns></returns>
        public ViewModels.OrganizationViewModels.Organization Get(Guid id)
        {
            Core.Entities.Customers.Enterprise.Organization customer = repository.Get(id);
            return null;
        }
    }
}
