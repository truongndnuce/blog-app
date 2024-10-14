using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Core.Domain.Content;
using BlogApp.Core.SeedWorks;

namespace BlogApp.Core.Reponsitories
{
    public interface IPostReponsitory : IRepository<Post,Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);
    }
}
