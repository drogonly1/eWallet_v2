using eWallet.Data.Enums;
using System;
using System.Collections.Generic;

namespace eWallet.Data.Entities;

public partial class ConfirmOrderRequest
{
    public int CorId { get; set; }

    public string? TransId { get; set; }

    public int StatusCode { get; set; }

    public string? PayUrl { get; set; }

    public string? Signature { get; set; }

    public virtual OrderRequest? Trans { get; set; }
}
