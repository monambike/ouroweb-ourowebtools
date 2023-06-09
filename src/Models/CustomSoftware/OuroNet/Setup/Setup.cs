using Common.Server;
using System.Collections.Generic;
using static Common.Server.ServerRequisitions.FollowWeb;

namespace Common.Models
{
    public partial class OuroNet
    {
        public partial class Setup
        {
            public static string LocalTfsPathOuroNet => @"c:\dvplocal\workspacetfs\ouronet\scc\producao\ouronet\";

            public static SingleVersion LastVersion { get; set; }

            public static SingleVersion ChosenVersion { get; set; }

            private static List<Application> Application { get; set; }


            public Setup(SingleVersion chosenVersion)
            {
                Application = GetOuroNetVersions();
                LastVersion = GetLatestOuroNetVersion();
                ChosenVersion = chosenVersion;
            }

            public void TransferAllSetups()
            {
                OverriteAllClientSetups();
                OverriteAllServerSetups();
            }

            private void OverriteAllClientSetups()
            {
                new Client.App().OverriteTargetSetupWithSourceSetup();

                new Client.WinService.Cce().OverriteTargetSetupWithSourceSetup();
                new Client.WinService.CceAutomaticAnswer().OverriteTargetSetupWithSourceSetup();
                new Client.WinService.Farma().OverriteTargetSetupWithSourceSetup();
                new Client.WinService.PagBco().OverriteTargetSetupWithSourceSetup();
                new Client.WinService.Whatsapp().OverriteTargetSetupWithSourceSetup();
            }

            private void OverriteAllServerSetups()
            {
                new Server.Cadastro().OverriteTargetSetupWithSourceSetup();
                new Server.Financeiro().OverriteTargetSetupWithSourceSetup();
                new Server.Movimento().OverriteTargetSetupWithSourceSetup();
                new Server.WebApi().OverriteTargetSetupWithSourceSetup();
            }
        }
    }
}
