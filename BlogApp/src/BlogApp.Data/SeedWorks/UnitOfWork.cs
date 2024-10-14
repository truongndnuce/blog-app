﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Core.SeedWorks;

namespace BlogApp.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogAppContext _context;

        public UnitOfWork(BlogAppContext context)
        {
            _context = context;
        }
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
