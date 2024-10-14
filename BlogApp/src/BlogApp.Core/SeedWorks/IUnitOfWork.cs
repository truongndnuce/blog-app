namespace BlogApp.Core.SeedWorks
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();

    }
}
