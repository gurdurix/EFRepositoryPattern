using EFRepository.Content;
using EFRepository.Context;
using EFRepository.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace EFRepository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        #region Private Members

        private Dictionary<Type, object> reposiroties = null;
        private SystemContext context;
        private bool disposed = false;
        private Guid _userLoggedId;

        #endregion Private Members

        #region Ctor

        public UnitOfWork(Guid userLoggedId, string connStrName)
        {
            CreateContext(userLoggedId, connStrName);
        }

        public UnitOfWork(Guid userLoggedId)
        {
            CreateContext(userLoggedId, string.Empty);
        }

        #endregion Ctor

        #region Internal Members

        private void CreateContext(Guid userLoggedId, string connStrName)
        {
            _userLoggedId = userLoggedId;
            if (!_userLoggedId.Equals(Guid.Empty))
            {
                reposiroties = new Dictionary<Type, object>();

                if (string.IsNullOrEmpty(connStrName) || string.IsNullOrWhiteSpace(connStrName))
                {
                    if (ConfigurationManager.ConnectionStrings["Default"] != null)
                        context = new SystemContext("Default");
                    else
                        throw new ConfigurationErrorsException(ExceptionMsg.DefaultConnStringNotFound);
                }
                else
                    this.context = new SystemContext(connStrName);


            }
            else throw new ArgumentNullException(ExceptionMsg.UserLoggedIdMandatory);
        }

        #endregion

        #region IUnitOfWork Members

        public void CreateRepository<T>() where T : Entity
        {
            if (!reposiroties.Keys.Contains(typeof(IRepository<T>)))
                reposiroties.Add(typeof(IRepository<T>), new Repository<T>(context, _userLoggedId));
        }

        public IRepository<T> GetRepository<T>() where T : Entity
        {
            object value = null;
            IRepository<T> repository = null;

            reposiroties.TryGetValue(typeof(IRepository<T>), out value);
            if (value != null)
                repository = value as IRepository<T>;
            else
                throw new NotSupportedException(string.Format(ExceptionMsg.EntityNotSupported, typeof(T).Name));

            return repository;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    reposiroties = null;
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IUnitOfWork Members
    }
}