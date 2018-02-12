using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NuGet.Protocol.Core.Types;
using NuGet.Protocol;
using NuGet.Protocol.Core.v2;
using Horus.Logger;
using Horus.HandlerFactory.Configurations;
using NuGet.Configuration;
using System.Threading;

namespace Horus.HandlerFactory.PackageSearcher
{
    internal class DefaultPackageSearcher : IPackageSearcher
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public DefaultPackageSearcher(ILogger logger, IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        
        public async Task<IEnumerable<IPackageSearchMetadata>> GetPackagesMetaDataAsync()
        {
            _logger.DEBUG($"started searching for packages metadata from the providers, using V3 and V2 protocols");

            var sourceRepository = GetSourceRepository();

            PackageMetadataResource packageMetadataResource = await sourceRepository.GetResourceAsync<PackageMetadataResource>();

            return await packageMetadataResource.GetMetadataAsync(_configuration.packageID, true, true, null, CancellationToken.None);
        }

        public async Task<IEnumerable<IPackageSearchMetadata>> GetPackagesMetaDataFullSearchAsync(SearchFilter searchFilter)
        {
            _logger.DEBUG($"started performing full search for packages metadata from the providers, using V3 and V2 protocols");

            var sourceRepository = GetSourceRepository();

            PackageSearchResource searchResource = await sourceRepository.GetResourceAsync<PackageSearchResource>();

            return await searchResource.SearchAsync(_configuration.packageID, searchFilter, 0, 10, null, CancellationToken.None);
        }

        private List<Lazy<INuGetResourceProvider>> GetV3AndV2Providers()
        {
            List<Lazy<INuGetResourceProvider>> providers = new List<Lazy<INuGetResourceProvider>>();
            providers.AddRange(Repository.Provider.GetCoreV3());  // Add v3 API support
            providers.AddRange(Repository.Provider.GetCoreV2());  // Add v2 API support
            return providers;
        }

        private SourceRepository GetSourceRepository()
        {
            var providers = GetV3AndV2Providers();

            PackageSource packageSource = new PackageSource(_configuration.feedURL);
            SourceRepository sourceRepository = new SourceRepository(packageSource, providers);

            return sourceRepository;
        }
    }
}
