using System;
using System.Collections.Generic;
using eWallet.Data.Configurations;
using eWallet.Data.Entities;
using eWallet.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eWallet.Data.EF;

public partial class EWalletDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public EWalletDbContext()
    {
    }

    public EWalletDbContext(DbContextOptions<EWalletDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Buyer> Buyers { get; set; }

    public virtual DbSet<ConfirmOrderRequest> ConfirmOderRequests { get; set; }

    public virtual DbSet<Merchant> Merchants { get; set; }

    public virtual DbSet<OrderRequest> OderRequests { get; set; }

    public virtual DbSet<OrderPaymentReceipt> OrderPaymentReceipts { get; set; }

    public virtual DbSet<PaymentRequest> PaymentRequests { get; set; }
    public virtual DbSet<AppUser> AppUsers { get; set; }
    public virtual DbSet<AppRole> AppRoles { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-KAETF7H\\SQLEXPRESS;Initial Catalog=db_a912b4_reactjsapinet;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BuyerConfiguration());
        modelBuilder.ApplyConfiguration(new ConfirmOrderRequestConfiguration());
        modelBuilder.ApplyConfiguration(new MerchantConfiguration());
        modelBuilder.ApplyConfiguration(new OrderPaymentReceiptConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentRequestConfiguration());
        modelBuilder.ApplyConfiguration(new OrderRequestConfiguration());

        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(k => new {k.UserId, k.RoleId});
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(k => k.UserId);

        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppUserRoleClaims");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserUserTokens").HasKey(k => k.UserId);

        modelBuilder.Seed();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
