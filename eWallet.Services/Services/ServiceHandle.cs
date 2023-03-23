using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.Services.Services
{
    public class ServiceHandle : IServiceHandle
    {
        public async Task<DateTime> ResponetimeToDatetime(string responeTiome)
        {
            return DateTime.Now;
        }
        public async Task<string> DatetimeToTimestamp(DateTime dateTime)
        {
            var UnixTimeStamp = dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            string timeStamp = Convert.ToInt64(UnixTimeStamp).ToString();
            return timeStamp;
        }
        public async Task<DateTime> TimestampToDatetime(string value)
        {
            var timeStamptoDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(long.Parse(value)).ToUniversalTime();
            DateTime time = timeStamptoDateTime;
            return time;
        }
    }
}
