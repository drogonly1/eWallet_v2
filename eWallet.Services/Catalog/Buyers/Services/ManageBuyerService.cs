using eWallet.Data.EF;
using eWallet.Data.Entities;
using eWallet.Services.Catalog.Buyers.Dtos;
using eWallet.Services.Dtos;
using eWallet.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.Buyers.Services
{
    public class ManageBuyerService : IManageBuyerService
    {
        private readonly EWalletDbContext _context;
        public ManageBuyerService (EWalletDbContext context)
        {
            _context = context;
        }
        public async Task<string> Create(BuyerCreateRequest request)
        {
            var buyer = new Buyer()
            {
                BuyerId = request.BuyerId,
                Username = request.Username,
                UserId = request.UserId,
                Password = request.Password,
                Amount = 0
            };
            _context.Buyers.Add(buyer);
            await _context.SaveChangesAsync();
            return buyer.BuyerId;
        }
        public Task<int> Update(BuyerUpdateRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<int> Delete(string buyerId)
        {
            var buyer = await _context.Buyers.FindAsync(buyerId);
            if (buyer == null) throw new EWalletException($"Cannot find a buyer: {buyerId}");
            _context.Buyers.Remove(buyer);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Buyer>> GetAll()
        {
            var buyers = new List<Buyer>();
            buyers = _context.Buyers.ToList();
            if (buyers == null)
            {
                throw new EWalletException($"Cannot find a buyer");
            }
            return buyers;
        }

        public Task<bool> Pay(string buyerId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Refund(string buyerId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Admit(string buyerId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<BuyerViewModel>> GetAllPaging(GetBuyerPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Buyer> GetById(string buyerId)
        {
            var buyer = await _context.Buyers.FindAsync(buyerId);
            if (buyer == null) throw new EWalletException($"Cannot find a buyer: {buyerId}");
            return buyer;
        }
    }
}
