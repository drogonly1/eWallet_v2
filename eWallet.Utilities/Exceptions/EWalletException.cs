using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Utilities.Exceptions
{
    public class EWalletException : Exception
    {
        public EWalletException()
        {
        }

        public EWalletException(string message)
            : base(message)
        {
        }

        public EWalletException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
