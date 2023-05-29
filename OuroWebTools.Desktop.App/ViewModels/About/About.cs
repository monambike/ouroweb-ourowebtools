namespace OuroWebTools.Desktop.ViewModels
{
    internal partial class AboutViewModel
    {
        internal ApplicationInfo Application { get; set; } = new ApplicationInfo
        {
            Title = AssemblyInfo.Title,

            Description = AssemblyInfo.Description,

            Version = AssemblyInfo.Version,

            Copyright = AssemblyInfo.Copyright,

            Company = AssemblyInfo.Company
        };

        internal class ApplicationInfo
        {
            internal string Title { get; set; }

            internal string Description { get; set; }

            internal string Version { get; set; }

            internal string Copyright { get; set; }

            internal string Company { get; set; }
        }
    }
}
