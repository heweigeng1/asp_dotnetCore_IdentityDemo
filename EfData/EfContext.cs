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
            modelBuilder.Entity<User>(b=> {
                b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256);
                b.Property(u => u.NormalizedEmail).HasMaxLength(256);
                b.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();


            });


            modelBuilder.Entity<UserLogin>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            modelBuilder.Entity<UserToken>().HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            modelBuilder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), UserName = "admin", PasswordHash = "123456" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = Guid.NewGuid(), Name = "admin", NormalizedName = "管理员", ConcurrencyStamp = "" });
        }
    }
}
