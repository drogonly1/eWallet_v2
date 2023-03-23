using eWallet.Data.EF;
using eWallet.Data.Entities;
using eWallet.Services.Catalog.ConfirmOrderRequests.Dtos;
using eWallet.Services.Catalog.OrderRequests.Dtos;
using eWallet.Services.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.ConfirmOrderRequests
{
    public class ConfirmOrderRequestService : IConfirmOrderRequestService
    {
        private readonly EWalletDbContext _context;
        private readonly ICryptoService _cryptoService;
        private readonly string _URL;
        private readonly IServiceHandle _serviceHandle;
        public ConfirmOrderRequestService(EWalletDbContext context, 
            ICryptoService cryptoService,
            IServiceHandle serviceHandle)
        {
            _context = context;
            _cryptoService = cryptoService;
            _URL = "https://localhost:7299/Payment/pay?";
            _serviceHandle = serviceHandle;
        }

        public Task<string> ChangeToJsonString(ConfirmOrderCreateRequest request)
        {
            string rawHash = "transId=" + request.TransId.ToString()
                            + "&statusCode=" + request.StatusCode.ToString()
                            + "&payUrl=" + request.PayUrl;

            return Task.FromResult(rawHash);
        }

        public async Task<ConfirmOrderCreateRequest> Create(ConfirmOrderCreateRequest request)
        {
            OrderRequest? orderRequest = await _context.OderRequests.FirstOrDefaultAsync(c => c.TransId == request.TransId);
            if (orderRequest == null)
                return null;

            string serectKey = orderRequest.Shop.SerectKey;
            
            // Chua ma hoa param
            string param = await ChangeToJsonString(request);
            string signature = _cryptoService.signSHA256(param, serectKey);

            request.Signature = signature;

            var order = new ConfirmOrderRequest()
            {
                PayUrl = "https://localhost:7299/Payment/pay?"
                        + "transId=" + orderRequest.TransId
                        + "&statusCode=0"
                        + "&amount=" + orderRequest.Amount
                        + "&orderInfo=" + orderRequest.OderInfo,
                Signature = signature,
                StatusCode = request.StatusCode,
                TransId = request.TransId,
            };
            
            _context.ConfirmOderRequests.Add(order);
            await _context.SaveChangesAsync();
            return request;
        }

        public Task<int> Delete(int CorId)
        {
            throw new NotImplementedException();
        }

        public async Task<ConfirmOrderRequest[]> GetAll()
        {
            var confirms = await _context.ConfirmOderRequests.ToArrayAsync();
            return confirms;
        }

        public Task<ConfirmOrderRequest> Update(OrderRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
