using eWallet.Data.EF;
using eWallet.Data.Entities;
using eWallet.Services.Catalog.OrderPaymentReceipts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.OrderPaymentReceipts
{
    public class OrderPaymentReceiptService : IOrderPaymentReceiptService
    {
        private readonly EWalletDbContext _context;
        public OrderPaymentReceiptService(EWalletDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(OrderPaymentReceiptCreateRequest request)
        {
            var order = new OrderPaymentReceipt()
            {
                TransId = request.TransId,
                Signature = request.Signature,
                ResponseTime = request.ResponseTime,
                Amount = request.Amount,
                StatusCode = ((int)request.StatusCode),
            };
            _context.OrderPaymentReceipts.Add(order);
            await _context.SaveChangesAsync();
            return 0;
        }

        public Task<int> Delete(int OprId)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderPaymentReceipt>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
