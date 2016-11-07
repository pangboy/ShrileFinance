namespace Application
{
    using System;
    using AutoMapper;
    using Core.Interfaces.Repositories;
    using X.PagedList;
    using ViewModels.OrganizationViewModels;
    using ViewModels;
    using System.Linq;

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

            try
            {
                //var organizate = repository.Get(model.Base.Id);
                //// organizate.Managers.RemoveRange(0, organizate.Managers.Count);
                // organizate.Managers.Clear();
                // organizate.Shareholders.Clear();
                // organizate.BigEvent.Clear();
                // organizate.Litigation.Clear();
                // organizate.AssociatedEnterprises.Clear();
                // organizate = Mapper.Map(model, organizate);
                // organizate.Managers.RemoveAt(0);
                repository.Modify(customer);

                repository.Commit();
            }
            catch (Exception ex)
            {
            }
        }

        public OrganizationViewModel Get(Guid id)
        {
            Core.Entities.Customers.Enterprise.Organization customer = repository.Get(id);

            var model = Mapper.Map<OrganizationViewModel>(customer);
            model.Base = Mapper.Map<BaseViewModel>(customer);

            return model;
        }

        /// <summary>
        /// 带分页查询
        /// </summary>
        /// yand    16.10.30
        /// <param name="Serach">查询条件</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <returns></returns>
        public PagedListViewModel<OragnizateListItemViewModel> GetPageList(string Serach, int pageNumber, int pageSize)
        {
            var pagedlist =
                repository
                .PagedList(m => m.Property.InstitutionChName == Serach, pageNumber, pageSize);

            var list = pagedlist.Select(m =>
                new OragnizateListItemViewModel
                {
                    Id=m.Id,
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
