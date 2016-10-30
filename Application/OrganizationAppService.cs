namespace Application
{
    using System;
    using AutoMapper;
    using Core.Interfaces.Repositories;
    using System.Collections;
    using System.Collections.Generic;

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
        public void Create(ViewModels.OrganizationViewModels.OrganizationViewModel model)
        {
            var customer = Mapper.Map<Core.Entities.Customers.Enterprise.Organization>(model.Base);

            customer = Mapper.Map(model, customer);
            repository.Create(customer);
            repository.Commit();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yand    16.10.25
        /// <param name="model">实体</param>
        public void Modify(ViewModels.OrganizationViewModels.OrganizationViewModel model)
        {
            var customer = new Core.Entities.Customers.Enterprise.Organization()
            {
              
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
        public ViewModels.OrganizationViewModels.OrganizationViewModel Get(Guid id)
        {
            Core.Entities.Customers.Enterprise.Organization customer = repository.Get(id);

            var model = Mapper.Map<ViewModels.OrganizationViewModels.OrganizationViewModel>(customer);
            model.Base = Mapper.Map<ViewModels.OrganizationViewModels.BaseViewModel>(customer);

            return model;
        }
    }
}
