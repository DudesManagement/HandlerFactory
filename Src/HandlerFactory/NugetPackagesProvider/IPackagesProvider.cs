using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horus.HandlerFactory.NugetPackagesProvider
{
    internal interface IPackagesSearcher
    {
        /// <summary>
        /// search for packages with given package ID, and return list of the packages found metadata
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IPackageSearchMetadata>> GetPackagesMetaDataAsync();

        /// <summary>
        /// search for packages with given package ID, and return list of the packages found metadata
        /// can pass a filter to it to be applied during the search
        /// </summary>
        /// <param name="searchFilter"></param>
        /// <returns></returns>
        Task<IEnumerable<IPackageSearchMetadata>> GetPackagesMetaDataFullSearchAsync(SearchFilter searchFilter);
    }
}
