using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Provides access to the singleton instance of the engine.
    /// </summary>
    public class EngineContext
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize()
        {
            if (Singleton<IEngine>.Instance == null)
            {
                Singleton<IEngine>.Instance = CreateEngineInstance();
                Singleton<IEngine>.Instance.Initialize();
            }
            return Singleton<IEngine>.Instance;
        }

        protected static IEngine CreateEngineInstance()
        {
            return new DeltaEngine();
        }

        /// <summary>
        /// Gets the singleton Nop engine used to access Nop services.
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Initialize();
                }
                return Singleton<IEngine>.Instance;
            }
        }
    }
}
