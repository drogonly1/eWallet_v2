using eWallet.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Data.Configurations
{
    public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> entity)
        {
            entity.ToTable("Buyers");

            entity.Property(e => e.BuyerId)
                .HasMaxLength(10)
                .HasColumnName("buyerId");
            entity.Property(e => e.Amount)
                .HasMaxLength(30)
                .HasColumnName("amount");
            entity.Property(e => e.Password)
                .HasMaxLength(32);
            entity.Property(e => e.Username)
                .HasMaxLength(32);

            entity.HasOne(d => d.AppUser).WithMany(d => d.Buyers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Buyer_AppUser");
        }
    }
}
