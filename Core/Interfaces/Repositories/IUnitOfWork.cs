namespace Core.Interfaces.Repositories
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork
    {
        int Commit();
    }
}
