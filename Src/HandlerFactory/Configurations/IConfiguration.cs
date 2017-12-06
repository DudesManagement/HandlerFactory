using System;
using System.Collections.Generic;
using System.Text;

namespace Dudes.HandlerFactory.Configurations
{
    internal interface IConfiguration
    {
        /// <summary>
        /// Default feed URL to search the package in
        /// </summary>
        string feedURL { get; }

        /// <summary>
        /// Default package ID defined in the appsetting.json
        /// </summary>
        string packageID { get; }

        /// <summary>
        /// Default package version sepicifed in the appsetting.json, = Null if not given
        /// </summary>
        string version { get; }

    }
}
