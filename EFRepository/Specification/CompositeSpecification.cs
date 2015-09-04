using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace EFRepository.Specification
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        #region Ctor

        public CompositeSpecification()
        {
        }

        public CompositeSpecification(ISpecification<T> specification)
        {
            this.Predicate = specification.Predicate;
        }

        public CompositeSpecification(Expression<Func<T, bool>> predicate)
        {
            this.Predicate = predicate;
        }

        #endregion Ctor

        #region Public Properties

        public Expression<Func<T, bool>> Predicate { get; set; }

        #endregion Public Properties

        #region Public Members

        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this.Predicate, specification);
        }

        public ISpecification<T> And(Expression<Func<T, bool>> predicate)
        {
            return new AndSpecification<T>(this.Predicate, predicate);
        }

        public ISpecification<T> Or(ISpecification<T> specification)
        {
            return new OrSpecification<T>(this.Predicate, specification);
        }

        public ISpecification<T> Or(Expression<Func<T, bool>> predicate)
        {
            return new OrSpecification<T>(this.Predicate, predicate);
        }

        public ISpecification<T> Not(ISpecification<T> specification)
        {
            return new NotSpecification<T>(this.Predicate, specification);
        }

        public ISpecification<T> Not(Expression<Func<T, bool>> predicate)
        {
            return new NotSpecification<T>(this.Predicate, predicate);
        }

        #endregion Public Members
    }
}
