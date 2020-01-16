using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Service
{
    public class LogService : EntityService<Log>, ILogService
    {
        IDbContext _context;

        public LogService(IDbContext context)
            : base(context)
        {
            _context = context;
        }

        public void InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", string userName = "")
        {
            WebHelper webHelper = new WebHelper(new HttpContextWrapper(HttpContext.Current) as HttpContextBase);
            var log = new Log
            {
                LogLevelId = (int)logLevel,
                ShortMessage = shortMessage,
                FullMessage = fullMessage,
                IpAddress = webHelper.GetCurrentIpAddress(),
                UserName = userName,
                PageUrl = webHelper.GetThisPageUrl(true),
                ReferrerUrl = webHelper.GetUrlReferrer(),
                CreatedOn = DateTime.Now
            };

            this.Insert(log);
        }
    }
}
