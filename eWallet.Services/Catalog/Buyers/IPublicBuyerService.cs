using eWallet.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.Buyers
{
    public interface IPublicBuyerService
    {
        Task<int> Create(BuyerCreateRequest request);
        Task<int> Update(BuyerUpdateRequest request);
        Task<BuyerViewModel> Get();
    }
}
