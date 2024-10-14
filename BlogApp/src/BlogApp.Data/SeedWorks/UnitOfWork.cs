using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Core.Reponsitories;
using BlogApp.Core.SeedWorks;
using BlogApp.Data.Reponsitories;

namespace BlogApp.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogAppContext _context;

        public UnitOfWork(BlogAppContext context , IMapper mapper)
        {
            _context = context;
            Posts = new PostReponsitory(context, mapper);
        }

        public IPostReponsitory Posts { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
