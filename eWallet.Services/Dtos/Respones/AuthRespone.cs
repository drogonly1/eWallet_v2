using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Dtos.Respones
{
    public class UserRes
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CreateDate { get; set; }
    }
    public class AuthRespone
    {
        public UserRes data { get; set; }
        public string token { get; set; }
        public string message { get; set; }
    }
}
