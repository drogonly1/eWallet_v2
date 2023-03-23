using System;
using System.Collections.Generic;

namespace eWallet.Data.Entities;

public partial class OrderRequest
{
    public string TransId { get; set; } = null!;

    public decimal Amount { get; set; }

    public string? ShopId { get; set; }

    public string? OderInfo { get; set; }

    public string? ResponseTime { get; set; }

    public string? Signature { get; set; }

    public virtual ConfirmOrderRequest? ConfirmOderRequests { get; set; }

    public virtual OrderPaymentReceipt? OrderPaymentReceipts { get; set; }

    public virtual PaymentRequest? PaymentRequests { get; set; }

    public virtual Merchant Shop { get; set; }
}
