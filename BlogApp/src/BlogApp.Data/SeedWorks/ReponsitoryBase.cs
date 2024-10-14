﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Core.SeedWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.Data.SeedWorks
{
    public class ReponsitoryBase <T,Key> : IRepository<T,Key> where T : class
    {
        private readonly DbSet<T> _dbSet;
         protected BlogAppContext _context;
        public ReponsitoryBase(BlogAppContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }
        public void Add(T entity)
        {
            _dbSet.AddAsync(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetByIdAsync(Key id)
        {
            return await _dbSet.FindAsync(id);
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
