using Horus.HandlerFactory.Constants;
using Horus.Logger;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Horus.HandlerFactory.Configurations
{
    public class DefaultConfiguration : IConfiguration
    {
        public string feedURL { get; private set; }
        public string packageID { get; private set; }
        public string version { get; private set; }

        private static IConfigurationRoot Configuration;
        private readonly string ConfigurationFileName;
        private readonly ILogger _logger;

        public DefaultConfiguration(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            ConfigurationFileName = ConfigurationConstants.DefaultConfigurationFileName;

            _logger.DEBUG(string.Format("Reading configurations from the file \"{0}\" from the directory {1}", ConfigurationFileName, Directory.GetCurrentDirectory()));

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile(ConfigurationFileName);

            Configuration = builder.Build();

            _logger.DEBUG(string.Format("Reading and saving the following key-value pair configurations, Key: \"{0}\", Value: \"{1}\"", feedURL, Configuration[ConfigurationConstants.FeedURL]));
            feedURL = Configuration[ConfigurationConstants.FeedURL];
            _logger.DEBUG(string.Format("Reading and saving the following key-value pair configurations, Key: \"{0}\", Value: \"{1}\"", packageID, Configuration[ConfigurationConstants.PackageID]));
            packageID = Configuration[ConfigurationConstants.PackageID];
            _logger.DEBUG(string.Format("Reading and saving the following key-value pair configurations, Key: \"{0}\", Value: \"{1}\"", version, Configuration[ConfigurationConstants.Version]));
            version = Configuration[ConfigurationConstants.Version];

        }
    }
}
