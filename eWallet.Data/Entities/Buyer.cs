using System;
using System.Collections.Generic;

namespace eWallet.Data.Entities;

public partial class Buyer
{
    public string BuyerId { get; set; } = null!;

    public string? Username { get; set; }

    public string? Password { get; set; }

    public decimal? Amount { get; set; }

    public virtual ICollection<PaymentRequest> PaymentRequests { get; } = new List<PaymentRequest>();
    public AppUser AppUser { get; set; }
    public Guid UserId { get; set; }
}
