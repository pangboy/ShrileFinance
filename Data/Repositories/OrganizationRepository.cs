namespace Data.Repositories
{
    using System.Data.Entity;
    using Core.Entities.Customers.Enterprise;
    using Core.Interfaces.Repositories;

    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(DbContext context) : base(context)
        {
        }
    }
}
