using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFRepository.Specification;
using System.Linq.Expressions;

namespace EFRepository.Entities.Specification
{
    public class FindEntityByIdSpecification<T> : CompositeSpecification<T> where T : Entity
    {
        public FindEntityByIdSpecification(Guid id)
            : base(p => p.Id.Equals(id))
        {
        }
    }
}
