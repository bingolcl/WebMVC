using Core;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;

namespace Service
{
    public class KeepAliveTask : ITask
    {
        private readonly IActiveDirectoryService _activeDirectoryService;
        private readonly IActivityLogService _activityLogService;
        private readonly ILogService _logService;

        public KeepAliveTask(IActiveDirectoryService activeDirectoryService,
                                      IActivityLogService activityLogService,
                                      ILogService logService)
        {
            _activeDirectoryService = activeDirectoryService;
            _activityLogService = activityLogService;
            _logService = logService;
        }

        public void Execute()
        {
            try
            {
                string url = "http://localhost:12345/" + "keepalive/index";
                using (var wc = new WebClient())
                {
                    wc.DownloadString(url);
                }
            }
            catch (Exception exc)
            {
                _logService.InsertLog(LogLevel.Error, exc.Message, exc.ToString());
                return;
            }            
        }
    }
}
