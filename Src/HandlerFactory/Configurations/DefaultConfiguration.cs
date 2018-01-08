using Horus.Common.Tools.BaseConfigurationsReader;
using Horus.HandlerFactory.Constants;
using Horus.Logger;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Horus.HandlerFactory.Configurations
{
    public class DefaultConfiguration : JsonBaseConfigurationsReader, IConfiguration
    {
        public string feedURL { get; private set; }
        public string packageID { get; private set; }
        public string version { get; private set; }

        private readonly ILogger _logger;

        public DefaultConfiguration(ILogger logger):base(logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            BuildConfiguration();

            feedURL = GetManadatoryConfiguration(ConfigurationConstants.FeedURL);
            packageID = GetManadatoryConfiguration(ConfigurationConstants.PackageID);
            version = GetManadatoryConfiguration(ConfigurationConstants.Version);

        }
    }
}
