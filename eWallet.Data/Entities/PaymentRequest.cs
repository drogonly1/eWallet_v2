using eWallet.Data.Enums;
using System;
using System.Collections.Generic;

namespace eWallet.Data.Entities;

public partial class PaymentRequest
{
    public int PaymentId { get; set; }

    public string? TransId { get; set; }

    public decimal? Amount { get; set; }

    public string? BuyerId { get; set; }

    public string? ResponseTime { get; set; }

    public string? Signature { get; set; }

    public virtual Buyer? Buyer { get; set; }

    public virtual OrderRequest? Trans { get; set; }
}
