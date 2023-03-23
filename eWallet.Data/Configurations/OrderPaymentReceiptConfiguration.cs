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
    public class OrderPaymentReceiptConfiguration : IEntityTypeConfiguration<OrderPaymentReceipt>
    {
        public void Configure(EntityTypeBuilder<OrderPaymentReceipt> entity)
        {
            entity.HasKey(e => e.OprId);

            entity.ToTable("OrderPaymentReceipts");

            entity.Property(e => e.OprId).HasColumnName("oprId");
            entity.Property(e => e.Amount)
                .HasMaxLength(30)
                .HasColumnName("amount");
            entity.Property(e => e.ResponseTime)
                .HasMaxLength(30)
                .HasColumnName("responseTime");
            entity.Property(e => e.Signature).HasColumnName("signature");
            entity.Property(e => e.StatusCode)
                .HasMaxLength(10)
                .HasColumnName("statusCode");
            entity.Property(e => e.TransId)
                .HasMaxLength(30)
                .HasColumnName("transId");

            entity.HasOne(d => d.Trans).WithOne(p => p.OrderPaymentReceipts)
                .HasForeignKey<OrderPaymentReceipt>(d => d.TransId)
                .HasConstraintName("FK_OrderPaymentReceipt_OderRequest");
        }
    }
}
