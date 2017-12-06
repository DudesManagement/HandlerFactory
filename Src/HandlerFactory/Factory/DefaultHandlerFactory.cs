using System;
using System.Collections.Generic;
using System.Text;

namespace Dudes.HandlerFactory.Factory
{
    class DefaultHandlerFactory<T> : IHandlerFactory<T>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Resolve()
        {
            throw new NotImplementedException();
        }

        public T Resolve(string packageID, Uri feedSource)
        {
            throw new NotImplementedException();
        }

        public T Resolve(string packageID, Uri feedSource, string handlerFullNameSpace)
        {
            throw new NotImplementedException();
        }
    }
}
