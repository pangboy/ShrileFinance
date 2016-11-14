namespace Data.Repositories
{
    using System;
    using System.Linq;
    using Core.Entities;
    using Core.Entities.Partner;
    using Core.Interfaces.Repositories;

    public class PartnerRepository : BaseRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(MyContext context) : base(context)
        {
        }

        public Partner GetByUser(AppUser user)
        {
            // TODO: 模拟数据
            var approvers = Context.Set<AppUser>().GroupBy(m => m.Roles.FirstOrDefault()).Select(m => m.FirstOrDefault()).ToList();

            return new Partner {
                Approvers = approvers
            };
        }
    }
}
