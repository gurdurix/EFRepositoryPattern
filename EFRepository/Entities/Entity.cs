using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EFRepository.Entities
{
    public abstract class Entity
    {
        #region Ctor

        public Entity() { }
        public Entity(Guid id) { Id = id; }

        #endregion Ctor

        #region Properties

        public Guid Id { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        #endregion Public Properties

        #region Members Public
        
        public override bool Equals(object obj) => this.Id.Equals(((Entity)obj).Id);

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString() => Id.ToString();

        #endregion Members Public
    }
}
