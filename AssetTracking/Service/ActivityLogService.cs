using Core;
using Core.Helper;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ActivityLogService : EntityService<ActivityLog>, IActivityLogService
    {
        IDbContext _context;
        IActivityLogTypeService _activityLogTypeService;

        public ActivityLogService(IDbContext context, IActivityLogTypeService activityLogTypeService)
            : base(context)
        {
            _context = context;
            _activityLogTypeService = activityLogTypeService;
        }

        public ActivityLog InsertActivityLog(string systemKeyword, string comment, string userName, params object[] commentParams)
        {
            if (string.IsNullOrEmpty(userName))
                return null;

            try
            {
                var activityType = _activityLogTypeService.Table.FirstOrDefault(at => at.SystemKeyword == systemKeyword);
                if (activityType == null || !activityType.Enabled)
                    return null;

                comment = CommonHelper.EnsureNotNull(comment);
                comment = string.Format(comment, commentParams);
                comment = CommonHelper.EnsureMaximumLength(comment, 4000);

                var activity = new ActivityLog();
                activity.ActivityLogTypeId = activityType.Id;
                activity.UserName = userName;
                activity.Comment = comment;
                activity.CreatedOn = DateTime.Now;

                this.Insert(activity);

                return activity;
            }
            catch
            {
                //Log exception
                return null;
            }
        }
    }
}
