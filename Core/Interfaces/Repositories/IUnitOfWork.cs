namespace Core.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
