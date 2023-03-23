using eWallet.Data.Entities;
using eWallet.Services.Catalog.OrderRequests.Dtos;
using eWallet.Services.Catalog.PaymentRequests.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.PaymentRequests
{
    public interface IPaymentRequestService
    {
        Task<int> Create(PaymentRequestCreateRequest request);
        Task<int> Delete(int PaymentId);
        Task<List<PaymentRequest>> GetAll();
    }
}
