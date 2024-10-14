using BlogApp.Core.Reponsitories;

namespace BlogApp.Core.SeedWorks
{
    public interface IUnitOfWork
    {
        IPostReponsitory Posts { get; }
        Task<int> CompleteAsync();

    }
}
