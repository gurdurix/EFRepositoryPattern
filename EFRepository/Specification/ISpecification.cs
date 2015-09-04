using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace EFRepository.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Predicate { get; }
        ISpecification<T> And(ISpecification<T> specification);
        ISpecification<T> And(Expression<Func<T, bool>> predicate);
        ISpecification<T> Or(ISpecification<T> specification);
        ISpecification<T> Or(Expression<Func<T, bool>> predicate);
        ISpecification<T> Not(ISpecification<T> specification);
        ISpecification<T> Not(Expression<Func<T, bool>> predicate);
    }
}
