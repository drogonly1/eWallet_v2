using eWallet.Services.Catalog.OrderRequests;
using eWallet.Services.Catalog.OrderRequests.Dtos;
using eWallet.Services.Catalog.System;
using eWallet.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eWallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IOrderRequestService _orderRequestService;
        private readonly ICryptoService _cryptoService;
        private readonly IServiceHandle _serviceHandle;
        public PayController(IOrderRequestService orderRequestService, ICryptoService cryptoService,
            IServiceHandle serviceHandle)
        {
            _orderRequestService = orderRequestService;
            _cryptoService = cryptoService;
            _serviceHandle = serviceHandle;
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromForm] OrderRequestCreateRequest request)
        {
            //Test client send request payment & Convert Json 

            //string jsons = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            request.ResponseTime = await _serviceHandle.DatetimeToTimestamp(DateTime.Now);
            string param = await _orderRequestService.ChangeToOrderPayment(request);
            string serectKey = "xUHfoPq35RGAHSJvuNc4AfR3YJ6RsTHG";
            string signature = _cryptoService.signSHA256(param, serectKey);
            request.Signature = signature;

            var result = await _orderRequestService.Create(request);
            if (result == null)
                return BadRequest(request);
            string jsons = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            ScannerQR.Instance.Start(result.TransId, jsons);
            return Ok(jsons);
        }
    }
}
