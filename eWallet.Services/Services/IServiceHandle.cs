using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Services
{
    public interface IServiceHandle
    {
        Task<DateTime> ResponetimeToDatetime(string responeTiome);
        Task<string> DatetimeToTimestamp(DateTime dateTime);
        Task<DateTime> TimestampToDatetime(string value);
    }
}
