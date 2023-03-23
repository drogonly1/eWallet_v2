using Microsoft.AspNetCore.Mvc;

namespace eWallet.Web.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Pay()
        {
            return View();
        }
        public IActionResult Pay(string request)
        {
            return View();
        }
    }
}
