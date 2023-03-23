using eWallet.Data.Entities;
using eWallet.Services.Catalog.Buyers;
using eWallet.Services.Catalog.ConfirmOrderRequests.Dtos;
using eWallet.Services.Catalog.OrderRequests.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.OrderRequests
{
    public interface IOrderRequestService
    {
        Task<ConfirmOrderCreateRequest> Create(OrderRequestCreateRequest request);
        Task<string> UpdateConfirm(ConfirmOrderRequest request);
        Task<int> Delete(string transId);
        Task<List<OrderInfo>> GetAll();
        Task<OrderRequest> GetById(string transId);
        Task<string> ChangeToOrderPayment(OrderRequestCreateRequest request);
    }
}
