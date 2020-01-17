using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Interface that should be implemented by each task
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// Execute task
        /// </summary>
        void Execute();
    }
}
