using HealthcareSystem.Domain.BaseEntities;
using HealthcareSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthcareSystem.Infrastructure.Persistence
{
    public class AuthDbContext : IdentityDbContext
    {
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> contextOptions)
            : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(@"DataSource=HealthcareSystem.db;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // This needs to go before the other rules!

            builder.Entity<IdentityUser>().ToTable("System_Users");
            builder.Entity<IdentityRole>().ToTable("System_Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("System_UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("System_UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("System_UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("System_RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("System_UserTokens");
            builder.Entity<RefreshToken>().ToTable("System_RefreshTokens");
        }
    }

}
