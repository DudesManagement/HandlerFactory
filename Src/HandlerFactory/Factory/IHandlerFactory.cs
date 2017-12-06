using System;
using System.Collections.Generic;
using System.Text;

namespace Dudes.HandlerFactory.Factory
{
    public interface IHandlerFactory <T>
    {
        /// <summary>
        /// Resolve all the appropriate handler
        /// </summary>
        /// <returns> The corresponding handler object </returns>
        T Resolve();

        /// <summary>
        /// Resolve all the appropriate handler, given the packageID and the feed source
        /// </summary>
        /// <param name="packageID"> Name of the package to use </param>
        /// <param name="feedSource"> The url or the local path where you can find the packages repository to pull the package from </param>
        /// <returns> The corresponding handler object </returns>
        T Resolve(string packageID, Uri feedSource);

        /// <summary>
        /// Resolve all the appropriate handler, given the packageID, the feed source and the default namespace
        /// </summary>
        /// <param name="packageID"> Name of the package to use </param>
        /// <param name="feedSource"> The url or the local path where you can find the packages repository to pull the package from </param>
        /// <param name="handlerFullNameSpace"> The full namespace where we can find the handler </param>
        /// <returns> The corresponding handler object </returns>
        T Resolve(string packageID, Uri feedSource, string handlerFullNameSpace);

        /// <summary>
        /// Disposing the 
        /// </summary>
        void Dispose();
    }
}
