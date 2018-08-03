using EfData.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EfData
{
    public class EfContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=IdentityDemo1;user id=sa;password=asdf.123;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), UserName = "admin", PasswordHash = "123456" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = Guid.NewGuid(), Name = "admin", NormalizedName = "管理员", ConcurrencyStamp = "" });
        }
    }
}
