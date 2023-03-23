using eWallet.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> entity)
        {
            entity.ToTable("AppUsers");

            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.FristName).HasMaxLength(200);
            entity.Property(e => e.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
