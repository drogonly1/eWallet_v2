using eWallet.Data.Entities;
using eWallet.Services.Catalog.Buyers.Dtos;
using eWallet.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.Buyers
{
    public interface IManageBuyerService
    {
        Task<string> Create(BuyerCreateRequest request);
        Task<int> Update(BuyerUpdateRequest request);
        Task<int> Delete(string buyerId);
        Task<bool> Pay(string buyerId, decimal amount);
        Task<bool> Refund(string buyerId, decimal amount);
        Task<bool> Admit(string buyerId, decimal amount);
        Task<List<Buyer>> GetAll();
        Task<Buyer> GetById(string Id);
        Task<PagedResult<BuyerViewModel>> GetAllPaging(GetBuyerPagingRequest request);
    }
}
