using eWallet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.Buyers
{
    public class BuyerUpdateRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public decimal Amount { get; set; }
    }
}
