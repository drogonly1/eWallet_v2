using eWallet.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.OrderRequests.Dtos
{
    public class GetOrderPagingRequest : PagingRequestBase
    {
        public string TransId { get; set; }
    }
}
