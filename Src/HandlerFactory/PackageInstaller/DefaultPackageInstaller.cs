using System;
using System.Collections.Generic;
using Horus.HandlerFactory.PackageSearcher;
using NuGet.Common;
using NuGet.Configuration;
using NuGet.PackageManagement;
using NuGet.Packaging.Core;
using NuGet.ProjectManagement;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Protocol.Core.v2;

namespace Horus.HandlerFactory.PackageInstaller
{
    internal class DefaultPackageInstaller : IPackageInstaller
    {
        private readonly IPackageSearcher _packageSearcher;

        DefaultPackageInstaller(IPackageSearcher packageSearcher){
            _packageSearcher = packageSearcher ?? throw new ArgumentNullException(nameof(_packageSearcher));
        }

        public async void installPackagesFromProvidedAppSettingsFileAsync()
        {
            var serachResult = await _packageSearcher.GetSinglePackageMetaDataAsync();
            var identity = serachResult.Identity;
            var rootPath = @"myPathToTheFolder";
            ISettings settings = Settings.LoadDefaultSettings(rootPath, null, new MachineWideSettings());
            PackageSourceProvider packageSourceProvider = new PackageSourceProvider(settings);
            ISourceRepositoryProvider sourceRepositoryProvider =
            new SourceRepositoryProvider(packageSourceProvider, GetV3AndV2Providers());
            NuGet.ProjectManagement.NuGetProject project = new NuGet.ProjectManagement.FolderNuGetProject(rootPath);
            NuGetPackageManager packageManager = new NuGetPackageManager(sourceRepositoryProvider, settings, packagesPath)
            {
                PackagesFolderNuGetProject = project
            };
        }

        private List<Lazy<INuGetResourceProvider>> GetV3AndV2Providers()
        {
            List<Lazy<INuGetResourceProvider>> providers = new List<Lazy<INuGetResourceProvider>>();
            providers.AddRange(Repository.Provider.GetCoreV3());  // Add v3 API support
            providers.AddRange(Repository.Provider.GetCoreV2());  // Add v2 API support
            return providers;
        }
    }
    public class MachineWideSettings : IMachineWideSettings
    {
        private readonly Lazy<IEnumerable<Settings>> _settings;

        public MachineWideSettings()
        {
            var baseDirectory = NuGetEnvironment.GetFolderPath(NuGetFolderPath.MachineWideConfigDirectory);
            _settings = new Lazy<IEnumerable<Settings>>(
                        () => global::NuGet.Configuration.Settings.LoadMachineWideSettings(baseDirectory));
        }

        public IEnumerable<Settings> Settings => _settings.Value;
    }
}

/* 
    PackageIdentity identity = new PackageIdentity(...);
    ISourceRepositoryProvider sourceRepositoryProvider = ...;  // See part 2
    string rootPath = "...";
    string packagesPath = "...";
    ISettings settings = Settings.LoadDefaultSettings(rootPath, null, new MachineWideSettings());
    NuGetProject project = new FolderNuGetProject(rootPath);
    NuGetPackageManager packageManager = new NuGetPackageManager(sourceRepositoryProvider, settings, packagesPath)
    {
        PackagesFolderNuGetProject = project
    };
    bool allowPrereleaseVersions = true;
    bool allowUnlisted = false;
    ResolutionContext resolutionContext = new ResolutionContext(
        DependencyBehavior.Lowest, allowPrereleaseVersions, allowUnlisted, VersionConstraints.None);    
    INuGetProjectContext projectContext = new ProjectContext();
    IEnumerable<SoureRepository> sourceRepositories = ...;  // See part 2
    await packageManager.InstallPackageAsync(packageManager.PackagesFolderNuGetProject,
        identity, resolutionContext, projectContext, sourceRepositories,
        Array.Empty<SourceRepository>(),  // This is a list of secondary source respositories, probably empty
        CancellationToken.None);
 */