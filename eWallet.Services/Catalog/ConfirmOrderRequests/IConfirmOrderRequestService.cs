using eWallet.Data.Entities;
using eWallet.Services.Catalog.ConfirmOrderRequests.Dtos;
using eWallet.Services.Catalog.OrderRequests.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.ConfirmOrderRequests
{
    public interface IConfirmOrderRequestService
    {
        Task<ConfirmOrderCreateRequest> Create(ConfirmOrderCreateRequest request);
        Task<ConfirmOrderRequest> Update(OrderRequest request);
        Task<int> Delete(int CorId);
        Task<ConfirmOrderRequest[]> GetAll();
        Task<string> ChangeToJsonString(ConfirmOrderCreateRequest request);
    }
}
