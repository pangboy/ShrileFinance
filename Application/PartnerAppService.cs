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

            produceRepository.GetAll().ToList().ForEach(m => partner.Produces.Add(m));
            partner.Accounts = repository.GetByUser(new AppUser()).Approvers;
            partner.Approvers = partner.Accounts;

            repository.Create(partner);
            repository.Commit();
        }

        public void Modify(PartnerViewModel model)
        {
            var partner = Mapper.Map<Partner>(model);

            partner = repository.Get(model.Id.Value);

            var produces = model.Produces.Select(m => produceRepository.Get(m.Id)).ToList();

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
