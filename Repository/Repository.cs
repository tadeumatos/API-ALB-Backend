using System;
using System.Linq;
using System.Linq.Expressions;
using API_ALB.Context;
using Microsoft.EntityFrameworkCore;

namespace API_ALB.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context=context;
            
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
           return _context.Set<T>()
             .Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State=EntityState.Modified;
            _context.Set<T>().Update(entity);
        }

    }
}