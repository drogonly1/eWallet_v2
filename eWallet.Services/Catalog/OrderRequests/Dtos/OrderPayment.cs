using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.OrderRequests.Dtos
{
    public class OrderRequestCreateRequest
    {
        public string TransId { get; set; }

        public decimal Amount { get; set; }

        public string ShopId { get; set; }

        public string OderInfo { get; set; }

        public string ResponseTime { get; set; }
        public string Signature { get; set; }
    }
}
