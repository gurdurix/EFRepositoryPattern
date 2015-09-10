using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFRepository.Entities
{
    public class UserProfile : Entity
    {
        #region Ctor
        
        public UserProfile() { }
        public UserProfile(string name, string description)
        {
            Name = name;
            Description = description;
        }

        #endregion Ctor

        #region Public Members

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }

        #endregion Public Members
    }
}