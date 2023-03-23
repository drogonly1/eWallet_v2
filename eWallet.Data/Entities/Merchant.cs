using System;
using System.Collections.Generic;

namespace eWallet.Data.Entities;

public partial class Merchant
{
    public string ShopId { get; set; } = null!;

    public string? MerchantName { get; set; }

    public decimal? Amount { get; set; }

    public string AccessKey { get; set; } = null!;

    public string SerectKey { get; set; } = null!;

    public string? Address { get; set; }
    public string NotifyUrl { get; set; }
    public string ReturnUrl { get; set; }

    public virtual ICollection<OrderRequest> OderRequests { get; } = new List<OrderRequest>();

    public AppUser AppUser { get; set; }
    public Guid UserId { get; set; }
}
