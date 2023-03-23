using eWallet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.ConfirmOrderRequests.Dtos
{
    public class ConfirmOrder
    {
        public string TransId { get; set; }

        public int StatusCode { get; set; }

        public string PayUrl { get; set; }

    }
}
