namespace Application
{
    using System;
    using Core.Entities;
    using Core.Interfaces.Repositories;

    public class UserAppService
    {
        private readonly IUserRepository repository;

        public UserAppService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public User GetUser(Guid userId)
        {
            var user = repository.Get(userId);

            return user;
        }

        public void CreateUser()
        {
            var user = new User();

            repository.Create(user);
            repository.Commit();
        }
    }
}
