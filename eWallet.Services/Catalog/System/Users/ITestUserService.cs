using eWallet.Services.Catalog.System.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.System.Users
{
    public interface ITestUserService
    {
        Task<ResponeAuth> TestAuth(LoginRequest request);
    }
}
