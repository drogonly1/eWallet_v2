using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Services
{
    public interface ICryptoService
    {
        string signSHA256(string message, string key);
    }
}
