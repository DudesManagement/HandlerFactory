using Horus.HandlerFactory.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.HandlerFactory.Factory
{
    class DefaultHandlerFactory<T> : IHandlerFactory<T>
    {
        private readonly IConfiguration _configuration;
        DefaultHandlerFactory(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
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
