using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFRepository.Specification;
using System.Linq.Expressions;

namespace EFRepository.Entities.Specification
{
    public class FindEntitySpecification<T> : CompositeSpecification<T> where T : Entity
    {
        public FindEntitySpecification(Expression<Func<T, bool>> expression)
            : base(expression)
        {
        }
    }
}
