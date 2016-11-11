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
            var approvers = Context.Set<AppUser>().GroupBy(m => m.RoleId).Select(m => m.First()).ToList();

            return new Partner {
                Approvers = approvers
            };
        }
    }
}
