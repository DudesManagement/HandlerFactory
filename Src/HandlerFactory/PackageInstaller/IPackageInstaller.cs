using Horus.HandlerFactory.PackageSearcher;

namespace Horus.HandlerFactory.PackageInstaller
{
    internal interface IPackageInstaller
    {
        void installPackagesFromProvidedAppSettingsFileAsync();
    }
}