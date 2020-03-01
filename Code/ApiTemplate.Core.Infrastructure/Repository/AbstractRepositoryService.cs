using Microsoft.EntityFrameworkCore;
using ApiTemplate.Core.Domain.Interfaces;
using ApiTemplate.Core.Infrastructure.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiTemplate.Core.Infrastructure.Repository
{
    public abstract class AbstractRepositoryService<TKey, T> : IRepositoryService<TKey, T>
        where T : class, IDomainEntity<TKey>
    {
        #region Private Fields

        protected readonly ApiTemplateContext _context;

        #endregion Private Fields

        #region Protected Constructors

        protected AbstractRepositoryService(ApiTemplateContext context)
        {
            _context = context;
        }

        #endregion Protected Constructors

        #region Public Methods

        public virtual TKey Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public virtual IEnumerable<TKey> Add(IEnumerable<T> entityList)
        {
            _context.Set<T>().AddRange(entityList);
            _context.SaveChanges();
            return entityList.Select(e => e.Id);
        }

        public virtual async Task<TKey> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public virtual async Task<IEnumerable<TKey>> AddAsync(IEnumerable<T> entityList)
        {
            await _context.Set<T>().AddRangeAsync(entityList);
            _context.SaveChanges();
            return entityList.Select(e => e.Id);
        }

        public virtual int Count()
        {
            return _context.Set<T>().Count();
        }

        public virtual async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public virtual void Delete(T deleted)
        {
            _context.Set<T>().Remove(deleted);
            _context.SaveChanges();
        }

        public virtual void Delete(IEnumerable<T> deletedList)
        {
            _context.Set<T>().RemoveRange(deletedList);
            _context.SaveChanges();
        }

        public virtual bool Exist(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public virtual async Task<bool> ExistAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public virtual IEnumerable<T> Filter(out int recordsFiltered, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IQueryable<T>> include = null, int? start = null,
            int? pageSize = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            recordsFiltered = query.Count();

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (start != null && pageSize != null)
            {
                query = query.Skip(start.Value).Take(pageSize.Value);
            }

            return query;
        }

        public virtual T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual IQueryable<T> Query(Func<IQueryable<T>, IQueryable<T>> include = null)
        {
            var query = _context.Set<T>().AsQueryable();

            if (include != null)
                query = include(query);

            return query;
        }

        public virtual IQueryable<T> Query(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> include = null)
        {
            var query = _context.Set<T>().Where(predicate);

            if (include != null)
                query = include(query);

            return query;
        }

        public virtual void Update(T updated)
        {
            if (updated != null)
            {
                _context.Set<T>().Update(updated);
            }
        }

        public virtual void Update(IEnumerable<T> updatedList)
        {
            if (updatedList != null)
            {
                _context.Set<T>().UpdateRange(updatedList);
            }
        }

        #endregion Public Methods
    }
}