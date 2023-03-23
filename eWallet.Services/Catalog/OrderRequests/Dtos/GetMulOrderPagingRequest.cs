using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.OrderRequests.Dtos
{
    public class GetMulOrderPagingRequest
    {
        public DateTime? DateTimeTo { get; set; }
        public DateTime? DateTimeFrom { get; set; }
        public string? TransId { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }
    }
}
