using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horus.HandlerFactory.PackageSearcher
{
    internal interface IPackageSearcher
    {
        /// <summary>
        /// search for packages with given package ID, and return enumerable of the packages found metadata
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IPackageSearchMetadata>> GetPackagesMetaDataAsync();

        /// <summary>
        /// search for packages with given package ID, and return one single package metadata by default it will be the first in the enumerable
        /// </summary>
        /// <returns></returns>
        Task<IPackageSearchMetadata> GetSinglePackageMetaDataAsync();

        /// <summary>
        /// search for packages with given package ID, and return enumerable of the packages found metadata
        /// can pass a filter to it to be applied during the search
        /// </summary>
        /// <param name="searchFilter"></param>
        /// <returns></returns>
        Task<IEnumerable<IPackageSearchMetadata>> GetPackagesMetaDataFullSearchAsync(SearchFilter searchFilter);

        SourceRepository GetSourceRepository();
    }
}
