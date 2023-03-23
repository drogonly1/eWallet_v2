using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.PaymentRequests.Dtos
{
    public class PaymentRequestCreateRequest
    {
        public int? PaymentId { get; set; }

        public string TransId { get; set; }

        public decimal Amount { get; set; }

        public string BuyerId { get; set; }

        public string ResponseTime { get; set; }

        public string Signature { get; set; }
    }
}
