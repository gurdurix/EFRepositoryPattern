using EFRepository.Context;
using EFRepository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using EFRepository.Extension;

namespace EFRepository.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            // Define a new user's guid.
            Guid userId = Guid.NewGuid();

            // Add profiles user.
            var profiles = new List<UserProfile>()
            {
                new UserProfile("Administrator", "System administrator group")
                {
                    Created = DateTime.Now,
                    CreatedBy = userId,
                    Active = true
                }
            };
            profiles.ForEach(profile => { context.UserProfile.AddOrUpdate(p => p.Id, profile); });
            context.SaveChanges();

            // Add users.
            var users = new List<User>()
            {
                new User("Leonel Vasconcelos", "gurdurix", "4321".Encrypt(), profiles.Single(p => p.Name.Equals("Administrator")))
                {
                    Created = DateTime.Now,
                    CreatedBy = userId,
                    Active = true
                }
            };
            users.ForEach(user => { context.User.AddOrUpdate(p => p.Id, user); });
            context.SaveChanges();
        }
    }
}