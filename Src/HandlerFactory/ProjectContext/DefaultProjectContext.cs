using System.Xml.Linq;
using NuGet.Packaging;
using NuGet.ProjectManagement;



namespace Horus.HandlerFactory.ProjectContext
{
    public class DefaultProjectContext : INuGetProjectContext
    {
        public void Log(MessageLevel level, string message, params object[] args)
        {
            // Do your logging here...
        }

        public FileConflictAction ResolveFileConflict(string message) => FileConflictAction.Ignore;

        public PackageExtractionContext PackageExtractionContext { get; set; }

        public XDocument OriginalPackagesConfig { get; set; }

        public ISourceControlManagerProvider SourceControlManagerProvider => null;

        public ExecutionContext ExecutionContext => null;

        public void ReportError(string message)
        {
        }

        public NuGetActionType ActionType { get; set; }
        public TelemetryServiceHelper TelemetryService { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }

}