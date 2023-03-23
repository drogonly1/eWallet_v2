using eWallet.Data.EF;
using eWallet.Data.Entities;
using eWallet.Data.Enums;
using eWallet.Services.Catalog.ConfirmOrderRequests;
using eWallet.Services.Catalog.ConfirmOrderRequests.Dtos;
using eWallet.Services.Catalog.OrderRequests.Dtos;
using eWallet.Services.Dtos;
using eWallet.Services.Services;
using eWallet.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.OrderRequests
{
    public class OrderRequestService : IOrderRequestService
    {
        private readonly EWalletDbContext _context;
        private readonly IServiceHandle _serviceHandle;
        private readonly ICryptoService _cryptoService;
        private readonly IConfirmOrderRequestService _confirmOrderRequestService;
        public OrderRequestService(EWalletDbContext context, 
            IServiceHandle serviceHandle, 
            ICryptoService cryptoService,
            IConfirmOrderRequestService confirmOrderRequestService)
        {
            _context = context;
            _serviceHandle = serviceHandle;
            _cryptoService = cryptoService;
            _confirmOrderRequestService = confirmOrderRequestService;
        }

        public Task<string> ChangeToOrderPayment(OrderRequestCreateRequest request)
        {
            string rawHash = "transid=" + request.TransId.ToString()
                            + "&amount=" + request.Amount.ToString()
                            + "&shopid=" + request.ShopId.ToString()
                            + "&orderinfo=" + request.OderInfo.ToString()
                            + "&responetime=" + request.ResponseTime.ToString();

            return Task.FromResult(rawHash);
        }

        public async Task<ConfirmOrderCreateRequest> Create(OrderRequestCreateRequest request)
        {
            Merchant? merchant = await _context.Merchants.FirstOrDefaultAsync(c => c.ShopId == request.ShopId);
            if (merchant == null)
                return null;
            string serectKey = merchant.SerectKey;
            string param = await ChangeToOrderPayment(request);

            string signature = _cryptoService.signSHA256(param, serectKey);

            if (signature != request.Signature)
                return null;

            var order = new OrderRequest()
            {
                TransId = request.TransId,
                Amount = request.Amount,
                ShopId = request.ShopId,
                OderInfo = request.OderInfo,
                ResponseTime = request.ResponseTime,
                Signature = signature
            };
            _context.OderRequests.Add(order);
            await _context.SaveChangesAsync();

            // Respone for merchant
            var confrimRequest = new ConfirmOrderCreateRequest
            {
                TransId = order.TransId,
                PayUrl = "https://localhost:7299/Payment/pay?" 
                        + "transId=" + order.TransId 
                        + "&statusCode=0"
                        + "&amount=" + order.Amount
                        + "&orderInfo=" + order.OderInfo,
                StatusCode = 0,
                Signature = "",
            };
            var confirm = await _confirmOrderRequestService.Create(confrimRequest);

            return confirm;
        }

        public Task<int> Delete(string transId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderInfo>> GetAll()
        {
            //OrderRequest[] orderRequests = await _context.OderRequests.ToArrayAsync();
            //if (orderRequests==null) throw new EWalletException($"Cannot find orderRequests");
            //return orderRequests;
            DateTime time = await _serviceHandle.ResponetimeToDatetime("123456789");
            var query = from order in _context.OderRequests
                        join conf in _context.ConfirmOderRequests on order.TransId equals conf.TransId
                        select new OrderInfo
                        {
                            TransId = order.TransId,
                            ShopName = order.Shop.MerchantName,
                            OderInfo = order.OderInfo,
                            Amount = order.Amount,
                            DateTime = time,
                            StatusCode = conf.StatusCode
                        };
            return query.ToList();
        }

        public async Task<OrderRequest> GetById(string transId)
        {
            var order = await _context.OderRequests.FindAsync(transId);
            if (order == null) throw new EWalletException($"Cannot find orderRequests");
            return order;
        }

        public async Task<string> UpdateConfirm(ConfirmOrderRequest request)
        {
            var update = await _context.OderRequests.FindAsync(request.TransId);
            if (update == null) throw new EWalletException($"Cannot find orderRequests");
            update.ConfirmOderRequests = request;
            await _context.SaveChangesAsync();
            return update.TransId;
        }
    }
}
