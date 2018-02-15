using System;
using Horus.HandlerFactory.PackageSearcher;
using NuGet.Packaging.Core;

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
        }
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