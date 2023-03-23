using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.OrderRequests.Dtos
{
    public class OrderInfo
    {
        public string TransId { get; set; }

        public decimal Amount { get; set; }

        public string ShopName { get; set; }

        public string OderInfo { get; set; }

        public DateTime DateTime { get; set; }
        public int StatusCode { get; set; }
    }
}
