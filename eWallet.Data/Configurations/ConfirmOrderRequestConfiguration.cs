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
    public class ConfirmOrderRequestConfiguration : IEntityTypeConfiguration<ConfirmOrderRequest>
    {
        public void Configure(EntityTypeBuilder<ConfirmOrderRequest> entity)
        {
            entity.HasKey(e => e.CorId);

            entity.ToTable("ConfirmOderRequests");

            entity.Property(e => e.CorId).HasColumnName("corId");
            entity.Property(e => e.PayUrl).HasColumnName("payUrl");
            entity.Property(e => e.Signature).HasColumnName("signature");
            entity.Property(e => e.StatusCode)
                .HasMaxLength(10)
                .HasColumnName("statusCode");
            entity.Property(e => e.TransId)
                .HasMaxLength(30)
                .HasColumnName("transId");

            entity.HasOne(d => d.Trans).WithOne(p => p.ConfirmOderRequests)
                .HasForeignKey<ConfirmOrderRequest>(d => d.TransId)
                .HasConstraintName("FK_ConfirmOderRequest_OderRequest");
        }
    }
}
