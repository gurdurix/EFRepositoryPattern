using EFRepository.Context;
using System.Data.Entity.Infrastructure;

namespace EFRepository.Migrations
{
    internal class MigrationsContextFactory : IDbContextFactory<SystemContext>
    {
        public SystemContext Create()
        {
            return new SystemContext("Default");
        }
    }
}