using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace UsuarioApi.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        private IConfiguration _configuration;
        public UserDbContext(DbContextOptions<UserDbContext> opt, IConfiguration configuration) : base(opt)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //CRIANDO A ROLE PADRÃO
            IdentityUser<int> admin = new IdentityUser<int>
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 99999,

            };
            //GERANDO SENHA COMO HASH
            PasswordHasher<IdentityUser<int>> hasher = new();
            admin.PasswordHash = hasher.HashPassword(admin, _configuration.GetValue<string>("adminInfo:password"));

            builder.Entity<IdentityUser<int>>().HasData(admin);
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>
                {
                    Id = 99999,
                    Name="admin",
                    NormalizedName = "ADMIN"
                });
            builder.Entity<IdentityRole<int>>().HasData(
               new IdentityRole<int>
               {
                   Id = 99998,
                   Name = "regular",
                   NormalizedName = "REGULAR"
               });

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    RoleId = 99999,
                    UserId = 99999
                });
        }

    }
}

