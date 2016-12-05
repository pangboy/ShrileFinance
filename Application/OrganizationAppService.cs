namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
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
            var customer = Mapper.Map<Core.Entities.Customers.Enterprise.Organization>(model.Base);

            customer = Mapper.Map(model, customer);
            repository.Create(customer);

            repository.Commit();
        }

        public void Modify(OrganizationViewModel model)
        {
            var customer = Mapper.Map<Core.Entities.Customers.Enterprise.Organization>(model.Base);
            customer = Mapper.Map(model, customer);

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
                });

            return new PagedListViewModel<OragnizateListItemViewModel>(new PagedList<OragnizateListItemViewModel>(pagedlist.GetMetaData(), list));
        }
    }
}
