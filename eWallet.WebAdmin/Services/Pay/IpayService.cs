using eWallet.WebAdmin.Services.Pay.Dtos;

namespace eWallet.WebAdmin.Services.Pay
{
    public interface IpayService
    {
        Task<ParamInfo> StringToPramObj(string param);
    }
}
