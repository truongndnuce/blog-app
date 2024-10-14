
using AutoMapper;
using BlogApp.Core.Domain.Content;
using BlogApp.Core.Models;
using BlogApp.Core.Models.Content;
using BlogApp.Core.Reponsitories;
using BlogApp.Data.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Reponsitories
{
    public class PostReponsitory : ReponsitoryBase<Post,Guid> , IPostReponsitory
    {
        private readonly IMapper _mapper;

        public PostReponsitory(BlogAppContext context , IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public Task<List<Post>> GetPopularPostsAsync(int count)
        {
            return _context.Posts!.OrderByDescending(x => x.ViewCount).Take(count).ToListAsync();
        }
        public async Task<PageResult<PostInListDto>> GetPostsPagingAsync(string? keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10)
        {
            var query = _context.Posts!.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }

            var totalRow = await query.CountAsync();

            query = query.OrderByDescending(x => x.DateCreated)
                .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);

            return new PageResult<PostInListDto>
            {
                Results = await _mapper.ProjectTo<PostInListDto>(query).ToListAsync(),
                CurrentPage = pageIndex,
                RowCount = totalRow,
                PageSize = pageSize
            };

        }
    }
}
