using eWallet.Data.EF;
using eWallet.Data.Entities;
using eWallet.Services.Catalog.Buyers;
using eWallet.Services.Catalog.ConfirmOrderRequests;
using eWallet.Services.Catalog.OrderRequests;
using eWallet.Services.Catalog.OrderRequests.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eWallet.Api.Controllers
{
    class res
    {
        public List<Buyer> data {get;set;}
        public bool loading { get;set;}
        public string message { get;set;}
    }
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class orderqueryController : ControllerBase
    {
        private readonly IOrderRequestService _orderRequestService;
        private readonly IManageBuyerService _manageBuyerService;
        private readonly IConfirmOrderRequestService _confirmOrderRequestService;
        EWalletDbContext context = new EWalletDbContext();
        public orderqueryController(IOrderRequestService orderRequestService, IConfirmOrderRequestService confirmOrderRequestService, IManageBuyerService manageBuyerService)
        {
            _orderRequestService = orderRequestService;
            _confirmOrderRequestService = confirmOrderRequestService;
            _manageBuyerService= manageBuyerService;
        }
        // GET: api/<orderqueryController>
        [HttpGet("layemdi")]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var orders = await _manageBuyerService.GetAll();
            res rp = new res();
            rp.data = orders;
            rp.loading = false;
            rp.message = "dau du";
            return Ok(orders);
            //return Ok("Successful");
        }

        // GET api/<orderqueryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<orderqueryController>

        // PUT api/<orderqueryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<orderqueryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
