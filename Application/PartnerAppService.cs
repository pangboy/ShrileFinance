namespace Application
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Partner;
    using Core.Interfaces.Repositories;
    using ViewModels.PartnerViewModels;
    using X.PagedList;

    public class PartnerAppService
    {
        private readonly IPartnerRepository repository;
        private readonly AppUserManager userManager;
        private readonly IProduceRepository produceRepository;

        public PartnerAppService(
            IPartnerRepository repository,
            AppUserManager userManager,
            IProduceRepository produceRepository)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.produceRepository = produceRepository;
        }

        public PartnerViewModel Get(Guid key)
        {
            var partner = repository.Get(key);

            return Mapper.Map<PartnerViewModel>(partner);
        }

        public void Create(PartnerViewModel model)
        {
            var partner = Mapper.Map<Partner>(model);

            var produceIds = model.Produces.Select(m => m.Id);
            partner.Produces = produceRepository.GetAll(m => produceIds.Contains(m.Id)).ToList();

            partner.Approvers = userManager.Users.Where(m => model.Approvers.Contains(m.Id)).ToList();

            if (partner.Approvers.Select(m => m.RoleId).Count() != 5)
            {
                throw new Core.Exceptions.InvalidOperationAppException("每个角色有且仅有一个审批用户.");
            }

            repository.Create(partner);
            repository.Commit();
        }

        public void Modify(PartnerViewModel model)
        {
            var partner = repository.Get(model.Id.Value);
            Mapper.Map(model, partner);

            var produceIds = model.Produces.Select(m => m.Id);
            partner.Produces.Clear();
            partner.Produces = produceRepository.GetAll(m => produceIds.Contains(m.Id)).ToList();

            partner.Approvers.Clear();
            partner.Approvers = userManager.Users.Where(m => model.Approvers.Contains(m.Id)).ToList();

            if (partner.Approvers.Select(m => m.RoleId).Count() != 5)
            {
                throw new Core.Exceptions.InvalidOperationAppException("每个角色有且仅有一个审批用户.");
            }

            repository.Modify(partner);
            repository.Commit();
        }

        public IPagedList<PartnerViewModel> List(string searchString, int page, int size)
        {
            var partners = repository.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                partners.Where(m => m.Name.Contains(searchString)
                    || m.ControllerName.Contains(searchString));
            }

            var list = partners.ToPagedList(page, size);

            var models = Mapper.Map<IPagedList<PartnerViewModel>>(list);

            return models;
        }
    }
}
