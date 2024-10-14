
using BlogApp.Core.Domain.Content;
using BlogApp.Core.Models.Content;
using BlogApp.Core.Models;
using BlogApp.Core.SeedWorks;

namespace BlogApp.Core.Reponsitories
{
    public interface IPostReponsitory : IRepository<Post,Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);
        Task<PageResult<PostInListDto>> GetPostsPagingAsync(string? keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10);

    }
}
