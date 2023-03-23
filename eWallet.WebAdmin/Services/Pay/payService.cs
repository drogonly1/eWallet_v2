using Azure.Core;
using eWallet.WebAdmin.Services.Pay.Dtos;
using System;

namespace eWallet.WebAdmin.Services.Pay
{
    public class payService : IpayService
    {
        public Task<ParamInfo> StringToPramObj(string param)
        {
            /// Descrypt query
            ///...
            /// 

            string[] listUri = param.Split(new char[] { '&' });
            string[] transId = listUri[0].Split(new char[] { '=' });
            string[] statusCode = listUri[1].Split(new char[] { '=' });
            var paramInfo = new ParamInfo
            {
                TransId = transId[1],
                StatusCode = statusCode[1],
            };
            return Task.FromResult(paramInfo);
        }
    }
}
