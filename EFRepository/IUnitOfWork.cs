using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFRepository.Entities;

namespace EFRepository
{
    public interface IUnitOfWork : IDisposable
    {
        void CreateRepository<T>() where T : Entity;
        IRepository<T> GetRepository<T>() where T : Entity;
        void SaveChanges();
    }
}
