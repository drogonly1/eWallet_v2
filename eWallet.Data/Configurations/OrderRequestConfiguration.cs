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
    public class OrderRequestConfiguration : IEntityTypeConfiguration<OrderRequest>
    {
        public void Configure(EntityTypeBuilder<OrderRequest> entity)
        {
            entity.HasKey(e => e.TransId);

            entity.ToTable("OderRequests");

            entity.Property(e => e.TransId)
                .HasMaxLength(30)
                .HasColumnName("transId");
            entity.Property(e => e.Amount)
                .HasMaxLength(30)
                .HasColumnName("amount");
            entity.Property(e => e.OderInfo)
                .HasMaxLength(50)
                .HasColumnName("oderInfo");
            entity.Property(e => e.ResponseTime)
                .HasMaxLength(30)
                .HasColumnName("responseTime");
            entity.Property(e => e.ShopId)
                .HasMaxLength(10)
                .HasColumnName("shopId");
            entity.Property(e => e.Signature).HasColumnName("signature");

            entity.HasOne(d => d.Shop).WithMany(p => p.OderRequests)
                .HasForeignKey(d => d.ShopId)
                .HasConstraintName("FK_OderRequest_Merchant");
        }
    }
}
