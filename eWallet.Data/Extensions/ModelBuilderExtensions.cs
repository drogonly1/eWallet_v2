using eWallet.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var ADMIN_ID = new Guid("BA9A22F7-4843-4638-8B9B-BA3241973892");
            var ROLE_ID = new Guid("1083FDBE-1F26-4AA6-BDDC-D06FA6BC523E");

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = ROLE_ID,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "some-admin-email@nonce.fake",
                NormalizedEmail = "some-admin-email@nonce.fake",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456"),
                SecurityStamp = string.Empty,
                FristName = "Administrator",
                LastName = "Role",
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            modelBuilder.Entity<Buyer>().HasData(new Buyer
            {
                BuyerId = "default",
                Amount = 0,
                Username = "default",
                Password = "default",
                UserId = ADMIN_ID,
            });
            modelBuilder.Entity<Buyer>().HasData(new Buyer
            {
                BuyerId = "buyer001",
                Amount = 0,
                Username = "admin",
                Password = "admin",
                UserId = ADMIN_ID,
            });
            modelBuilder.Entity<Merchant>().HasData(new Merchant
            {
                AccessKey = "xUHfoPq35RGAHSJvuNc4AfR3YJ6RsTHG",
                Address = "",
                Amount = 0,
                MerchantName = "admin",
                SerectKey = "xUHfoPq35RGAHSJvuNc4AfR3YJ6RsTHG",
                ShopId = "admin",
                UserId = ADMIN_ID,
                NotifyUrl = "https://localhost:7299/Pay/NotifyURL",
                ReturnUrl = "https://localhost:7299/Pay/ReturnURL",
            });
        }
    }
}
