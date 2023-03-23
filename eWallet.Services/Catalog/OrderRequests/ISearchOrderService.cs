using eWallet.Services.Catalog.OrderRequests.Dtos;
using eWallet.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.OrderRequests
{
    public interface ISearchOrderService
    {
        PagedResult<OrderViewModel> GetAllByTransId(GetOrderPagingRequest request);
        PagedResult<OrderViewModel> GetAllByDate(GetOrderPagingRequest request);
    }
}
