﻿namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Customers.Enterprise;
    using Core.Interfaces.Repositories;
    using ViewModels;
    using ViewModels.OrganizationViewModels;
    using X.PagedList;

    public class OrganizationAppService
    {
        private readonly IOrganizationRepository repository;

        public OrganizationAppService(IOrganizationRepository repository)
        {
            this.repository = repository;
        }

        public void Create(OrganizationViewModel model)
        {
            var customer = Mapper.Map<Organization>(model.Base);
            customer = Mapper.Map(model, customer);

            customer.AssociatedEnterprises = Mapper.Map<ICollection<AssociatedEnterprise>>(model.AssociatedEnterprises);
            customer.BigEvent = Mapper.Map<ICollection<BigEvent>>(model.BigEvent);
            customer.Litigation = Mapper.Map<ICollection<Litigation>>(model.Litigation);
            customer.Managers = Mapper.Map<ICollection<Manager>>(model.Managers);
            customer.Shareholders = Mapper.Map<ICollection<Stockholder>>(model.Shareholders);

            if (model.FinancialAffairs != null)
            {
                customer.FinancialAffairs = new FinancialAffairs()
                {
                    Id = Guid.Empty,
                    Year = model.FinancialAffairs.Year,
                    TypeSubdivision = model.FinancialAffairs.TypeSubdivision,
                    AuditFirm = model.FinancialAffairs.AuditFirm,
                    AuditorName = model.FinancialAffairs.AuditorName
                };

                customer.FinancialAffairs.IncomeExpenditur = Mapper.Map<ICollection<InstitutionIncomeExpenditure>>(model.FinancialAffairs.IncomeExpenditur);
                customer.FinancialAffairs.InstitutionLiabilities = Mapper.Map<ICollection<InstitutionLiabilities>>(model.FinancialAffairs.InstitutionLiabilities);
                customer.FinancialAffairs.Liabilities = Mapper.Map<ICollection<Liabilities>>(model.FinancialAffairs.Liabilities);
                customer.FinancialAffairs.Profit = Mapper.Map<ICollection<Profit>>(model.FinancialAffairs.Profit);
                customer.FinancialAffairs.CashFlow = Mapper.Map<ICollection<CashFlow>>(model.FinancialAffairs.CashFlow);
            }

            repository.Create(customer);

            repository.Commit();
        }

        public void Modify(OrganizationViewModel model)
        {
            var customer = repository.Get(model.Base.Id.Value);
            Mapper.Map(model.Base, customer);
            Mapper.Map(model, customer);

            // 映射财务
            if (model.FinancialAffairs != null)
            {
                new UpdateBind().Bind(customer.FinancialAffairs.Liabilities, model.FinancialAffairs.Liabilities);
                new UpdateBind().Bind(customer.FinancialAffairs.CashFlow, model.FinancialAffairs.CashFlow);
                new UpdateBind().Bind(customer.FinancialAffairs.IncomeExpenditur, model.FinancialAffairs.IncomeExpenditur);
                new UpdateBind().Bind(customer.FinancialAffairs.InstitutionLiabilities, model.FinancialAffairs.InstitutionLiabilities);
                new UpdateBind().Bind(customer.FinancialAffairs.Profit, model.FinancialAffairs.Profit);
            }

            new UpdateBind().Bind(customer.BigEvent, model.BigEvent);
            new UpdateBind().Bind(customer.Litigation, model.Litigation);
            new UpdateBind().Bind(customer.Managers, model.Managers);
            new UpdateBind().Bind(customer.Shareholders, model.Shareholders);
            new UpdateBind().Bind(customer.AssociatedEnterprises, model.AssociatedEnterprises);

            repository.Modify(customer);
            repository.Commit();
        }

        public OrganizationViewModel Get(Guid id)
        {
            Core.Entities.Customers.Enterprise.Organization customer = repository.Get(id);

            var model = Mapper.Map<OrganizationViewModel>(customer);
            model.Base = Mapper.Map<BaseViewModel>(customer);

            return model;
        }

        public CreditOraganizateViewModel GetCreditOrganizate(Guid id)
        {
            Organization customer = repository.Get(id);
            CreditOraganizateViewModel model = new CreditOraganizateViewModel()
            {
                CustomerNumber = customer.CustomerNumber,
                LoanCardCode = customer.LoanCardCode,
                InstitutionChName = customer.Property.InstitutionChName,
                ManagementerCode = customer.ManagementerCode,
                RegisterAddress = customer.Property.RegisterAddress,
                RegisterCapital = customer.Property.RegisterCapital,
                SetupDate = customer.Property.SetupDate
            };

            return model;
        }

        public List<OrganizateComboViewModel> GetAll()
        {
            var customer = repository.GetAll();
            List<OrganizateComboViewModel> custviewmodelList = new List<OrganizateComboViewModel>();
            if (customer != null)
            {
                foreach (var item in customer)
                {
                    custviewmodelList.Add(new OrganizateComboViewModel()
                    {
                        InstitutionChName = item.Property.InstitutionChName,
                        Id = item.Id
                    });
                }
            }

            return custviewmodelList;
        }

        /// <summary>
        /// 带分页查询
        /// </summary>
        /// yand    16.10.30
        /// <param name="serach">查询条件</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <returns></returns>
        public PagedListViewModel<OragnizateListItemViewModel> GetPageList(string serach, int pageNumber, int pageSize)
        {
            if (string.IsNullOrEmpty(serach))
            {
                serach = string.Empty;
            }

            var pagedlist =
                repository
                .PagedList(m => m.Property.InstitutionChName.Contains(serach), pageNumber, pageSize);

            var list = pagedlist.Select(m =>
                new OragnizateListItemViewModel
                {
                    Id = m.Id,
                    CustomerNumber = m.CustomerNumber,
                    InstitutionChName = m.Property.InstitutionChName,
                    InstitutionCreditCode = m.InstitutionCreditCode,
                    LoanCardCode = m.LoanCardCode,
                    ManagementerCode = m.ManagementerCode,
                    CreatedDate = m.CreatedDate
                });

            return new PagedListViewModel<OragnizateListItemViewModel>(new PagedList<OragnizateListItemViewModel>(pagedlist.GetMetaData(), list));
        }
    }
}
