using Common.Utilities;
using System.Threading.Tasks;
using System.Windows;

namespace Common.Models
{
    public partial class OuroNet
    {
        public partial class Setup
        {
            public abstract partial class Base
            {
                public string SetupFolderNameLocalTfs => GetType().Name;
                
                private string OuroNetLocalTfsPath => $@"c:\dvplocal\workspacetfs\ouronet\scc\{VersionPathLocalTfs}\04-Setup\{SetupFolderNameLocalTfs}\Release";
                
                private string VersionPathLocalTfs => (ChosenVersion == LastVersion) ? @"producao\ouronet"
                    : $@"versoes\{LastVersion.Sob}\subversao\{LastVersion.Sub}";

                public string FolderPathServer => GetType().Name;

                private string OuroNetServerPath => $@"\\vm-srvfile01\fontes\application\ouronet\teste\{LastVersion.Sob}\setups\{LastVersion.Sub}\{FolderPathServer}";

                private string OuroNetTargetPath => (OuroNetTargetPath == "isLocal") ? @"C:\__Auxilio\" : OuroNetServerPath;

                protected Base()
                {

                }

                protected async Task CopyLocalSetupToPath()
                {
                    Directory.CopyDirectoryAndFiles(OuroNetLocalTfsPath, OuroNetServerPath);

                    await Info.MakeSetupTransferenceInfoFile();
                }

                public void OverriteTargetSetupWithSourceSetup()
                {
                    if (!SetupExists(OuroNetLocalTfsPath))
                        if (Message.NotFoundLocalSetup() == MessageBoxResult.OK)
                            return;

                    if (SetupExists(OuroNetTargetPath))
                        if (Message.AlreadyExistsAskToOverrite(OuroNetLocalTfsPath, OuroNetTargetPath) == MessageBoxResult.No)
                            return;

                    CopyLocalSetupToPath()
                        .ContinueWith(task => Message.SuccessTransferSetupAt(OuroNetTargetPath));
                }

                public virtual bool SetupExists(string path) => true;

                private class InnerVersion
                {
                    public string Sob { get; set; }

                    public string Sub { get; set; }

                    public string Whole => $"{Sob}.{Sub}";
                }
            }
        }
    }
}
