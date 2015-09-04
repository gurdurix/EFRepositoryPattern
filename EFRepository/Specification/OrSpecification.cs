using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace EFRepository.Specification
{
    internal class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(Expression<Func<T, bool>> left, ISpecification<T> right)
        {
            base.Predicate = left.Or(right.Predicate);
        }

        public OrSpecification(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            base.Predicate = left.Or(right);
        }
    }
}
