using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFRepository.Entities;
using EFRepository.Specification;
using EFRepository.Entities.Specification;

namespace EFRepository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(ISpecification<TEntity> specification);
        void Delete(TEntity entity);
        IList<TEntity> GetAllEntities(ISpecification<TEntity> specification);
        TEntity GetEntityBy(ISpecification<TEntity> specification);
    }
}
