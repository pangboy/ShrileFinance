namespace Data.Repositories
{
    using System.Data.Entity;
    using Core.Entities.Customers.Enterprise.Organizate;
    using Core.Interfaces.Repositories;

    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }
    }
}
