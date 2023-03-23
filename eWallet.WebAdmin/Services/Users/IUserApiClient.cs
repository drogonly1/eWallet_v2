using eWallet.Services.Catalog.System.Users.Dtos;

namespace eWallet.WebAdmin.Services.Users
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<string> Registry(RegisterRequest request);
    }
}
