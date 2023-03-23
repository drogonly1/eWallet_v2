using eWallet.Services.Catalog.System.Users.Dtos;
using eWallet.Services.Dtos.Respones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Catalog.System.Users
{
    public interface IUserService
    {
        Task<AuthRespone> Authencate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
