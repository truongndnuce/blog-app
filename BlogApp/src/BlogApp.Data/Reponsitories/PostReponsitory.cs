using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Core.Domain.Content;
using BlogApp.Core.Reponsitories;
using BlogApp.Data.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Reponsitories
{
    public class PostReponsitory : ReponsitoryBase<Post,Guid> , IPostReponsitory
    {
        public PostReponsitory(BlogAppContext context) : base(context)
        {
        }

        public Task<List<Post>> GetPopularPostsAsync(int count)
        {
            return _context.Posts!.OrderByDescending(x => x.ViewCount).Take(count).ToListAsync();
        }
    }
}
