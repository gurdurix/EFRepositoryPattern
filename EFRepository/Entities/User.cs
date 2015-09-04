using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EFRepository.Entities
{
    public class User : Entity
    {
        #region Ctor

        public User() { }
        public User(Guid id) : base(id) { }
        public User(string userName, string login, string password, UserProfile userProfile)
        {
            UserName = userName;
            Login = login;
            Password = password;
            ProfileUser = userProfile;
        }

        #endregion Ctor

        #region Public Members

        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid UserProfileId { get; set; }
        [ForeignKey("UserProfileId")]
        public virtual UserProfile ProfileUser { get; set; }
        
        #endregion Public Members
    }
}