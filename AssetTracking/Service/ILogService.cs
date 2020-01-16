using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ILogService : IEntityService<Log>
    {
        void InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", string userName = "");
    }
}
