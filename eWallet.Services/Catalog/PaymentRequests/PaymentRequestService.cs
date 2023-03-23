using eWallet.Data.EF;
using eWallet.Data.Entities;
using eWallet.Services.Catalog.PaymentRequests.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.PaymentRequests
{
    public class PaymentRequestService : IPaymentRequestService
    {
        private readonly EWalletDbContext _context;
        public PaymentRequestService(EWalletDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(PaymentRequestCreateRequest request)
        {
            var order = new PaymentRequest()
            {
                TransId = request.TransId,
                Amount = request.Amount,
                BuyerId = request.BuyerId,
                ResponseTime = request.ResponseTime,
                Signature = request.Signature
            };
            _context.PaymentRequests.Add(order);
            await _context.SaveChangesAsync();
            return order.PaymentId;
        }

        public Task<int> Delete(int PaymentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PaymentRequest>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
