using eWallet.Data.Entities;
using eWallet.Services.Catalog.ConfirmOrderRequests.Dtos;
using eWallet.Services.Catalog.OrderPaymentReceipts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.OrderPaymentReceipts
{
    public interface IOrderPaymentReceiptService
    {
        Task<int> Create(OrderPaymentReceiptCreateRequest request);
        Task<int> Delete(int OprId);
        Task<List<OrderPaymentReceipt>> GetAll();
    }
}
