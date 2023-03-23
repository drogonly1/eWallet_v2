using eWallet.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.Buyers.Dtos
{
    public class GetBuyerPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
