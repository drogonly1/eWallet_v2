using eWallet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.OrderPaymentReceipts.Dtos
{
    public class OrderPaymentReceiptCreateRequest
    {
        public int? OprId { get; set; }

        public string TransId { get; set; }

        public decimal Amount { get; set; }

        public StatusCode StatusCode { get; set; }

        public string ResponseTime { get; set; }

        public string Signature { get; set; }
    }
}
