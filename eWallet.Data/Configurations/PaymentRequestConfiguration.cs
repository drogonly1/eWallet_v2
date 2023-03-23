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
    public class PaymentRequestConfiguration : IEntityTypeConfiguration<PaymentRequest>
    {
        public void Configure(EntityTypeBuilder<PaymentRequest> entity)
        {
            entity.HasKey(e => e.PaymentId);

            entity.ToTable("PaymentRequests");

            entity.Property(e => e.PaymentId).HasColumnName("paymentId");
            entity.Property(e => e.Amount)
                .HasMaxLength(30)
                .HasColumnName("amount");
            entity.Property(e => e.BuyerId)
                .HasMaxLength(10)
                .HasColumnName("buyerId");
            entity.Property(e => e.ResponseTime)
                .HasMaxLength(30)
                .HasColumnName("responseTime");
            entity.Property(e => e.Signature).HasColumnName("signature");
            entity.Property(e => e.TransId)
                .HasMaxLength(30)
                .HasColumnName("transId");

            entity.HasOne(d => d.Buyer).WithMany(p => p.PaymentRequests)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK_PaymentRequest_Buyer");

            entity.HasOne(d => d.Trans).WithOne(p => p.PaymentRequests)
                .HasForeignKey<PaymentRequest>(d => d.TransId)
                .HasConstraintName("FK_PaymentRequest_OderRequest");
        }
    }
}
