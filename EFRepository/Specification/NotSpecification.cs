using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace EFRepository.Specification
{
    internal class NotSpecification<T> : CompositeSpecification<T>
    {
        public NotSpecification(Expression<Func<T, bool>> left, ISpecification<T> right)
        {
            base.Predicate = left.AndAlso(right.Predicate.Not());
        }

        public NotSpecification(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            base.Predicate = left.AndAlso(right.Not());
        }
    }
}
