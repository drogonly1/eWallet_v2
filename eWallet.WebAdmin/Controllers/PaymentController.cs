using eWallet.WebAdmin.Services.Pay;
using eWallet.WebAdmin.Services.Pay.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace eWallet.WebAdmin.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IpayService _payService;
        public PaymentController(IpayService payService)
        {
            _payService = payService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Pay()
        {
            HttpRequest request = HttpContext.Request;
            var query = new ParamInfo
            {
                TransId = request.Query["transId"].ToString(),
                StatusCode = request.Query["statusCode"].ToString(),
                Amount = request.Query["amount"].ToString(),
                OderInfo = request.Query["orderInfo"].ToString()
            };
            return await Task.Run(() => View(query));
        }
        [HttpPost]
        public IActionResult SubmitPayment() => Redirect("https://www.google.com/");
    }
}
