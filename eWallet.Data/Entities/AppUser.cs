using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Buyer> Buyers { get; } = new List<Buyer>();
        public virtual ICollection<Merchant> Merchants { get; } = new List<Merchant>();
    }
}
