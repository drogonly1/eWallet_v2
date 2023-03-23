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
    public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> entity)
        {
            entity.HasKey(e => e.ShopId);

            entity.ToTable("Merchants");

            entity.Property(e => e.ShopId)
                .HasMaxLength(10)
                .HasColumnName("shopId");
            entity.Property(e => e.AccessKey)
                .HasMaxLength(100)
                .HasColumnName("accessKey");
            entity.Property(e => e.Address)
                .HasMaxLength(50);
            entity.Property(e => e.Amount)
                .HasMaxLength(30)
                .HasColumnName("amount");
            entity.Property(e => e.MerchantName).HasMaxLength(30);
            entity.Property(e => e.SerectKey)
                .HasMaxLength(100)
                .HasColumnName("serectKey");

            entity.HasOne(d => d.AppUser).WithMany(p => p.Merchants)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Merchant_AppUser");
        }
    }
}
