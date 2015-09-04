using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFRepository.Specification;
using System.Linq.Expressions;

namespace EFRepository.Entities.Specification
{
    public class CustomSpecification<T> : CompositeSpecification<T> where T : Entity
    {
        public CustomSpecification(Expression<Func<T, bool>> expression)
            : base(expression)
        {
        }
    }
}
