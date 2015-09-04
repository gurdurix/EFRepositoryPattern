using System;
using System.Collections.Generic;
using System.Linq;
using EFRepository.Entities;
using System.Data.Entity;
using System.Data;
using EFRepository.Specification;

namespace EFRepository
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        #region Private Members

        private DbContext _context;
        private DbSet<TEntity> _dbSet;
        private Guid _userLoggedId;

        #endregion

        #region Ctor

        public Repository(DbContext context, Guid userLoggedId)
        {
            _context = context;
            _userLoggedId = userLoggedId;
            _dbSet = context.Set<TEntity>();
        }

        #endregion

        #region IRepository Members

        public TEntity Insert(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            entity.Created = DateTime.Now;
            entity.CreatedBy = _userLoggedId;
            entity.Active = true;
            return _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            entity.Updated = DateTime.Now;
            entity.UpdatedBy = _userLoggedId;
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(ISpecification<TEntity> specification)
        {
            TEntity entityToDelete = GetEntityBy(specification);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);
        }

        public IList<TEntity> GetAllEntities(ISpecification<TEntity> specification)
        {
            return _dbSet.Where(specification.Predicate).ToList();
        }

        public TEntity GetEntityBy(ISpecification<TEntity> specification)
        {
            TEntity entity = null;

            var queryResult = _dbSet.Where(specification.Predicate);
            if (queryResult.ToList().Any())
                entity = queryResult.SingleOrDefault();

            return entity;
        }

        #endregion
    }
}