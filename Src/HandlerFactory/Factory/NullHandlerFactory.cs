using System;
using System.Collections.Generic;
using System.Text;

namespace Dudes.HandlerFactory.Factory
{
    public class NullHandlerFactory : IHandlerFactory<object>
    {
        public object Resolve()
        {
            return null;
        }

        public object Resolve(string packageID, Uri feedSource)
        {
            return null;
        }

        public object Resolve(string packageID, Uri feedSource, string handlerFullNameSpace)
        {
            return null;
        }

        public void Dispose() {

        }
    }
}
