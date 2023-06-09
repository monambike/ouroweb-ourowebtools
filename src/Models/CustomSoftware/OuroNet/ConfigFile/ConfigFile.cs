using Common.Server;
using Common.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common.Models
{
    public partial class OuroNet
    {
        public partial class ConfigFile
        {
            private static List<Instance> Servers { get; set; }

            public ConfigFile()
            {
                var connectionStringsServer = OuroWebTools.Settings.ConfigFile.Default.ConnectionStringsServer;
                var servers = new List<string> { connectionStringsServer };
                if (!string.IsNullOrWhiteSpace(connectionStringsServer))
                    Servers = ServerRequisitions.Sql.GetDatabases(servers);
            }

            public void OverriteAllConfigurationFiles()
            {
                Log.AppendToLogCustomText(Log.LogType.INFO, "Atualizando todos os arquivos de configuração...");
                OverriteInstalledSetupCustomSoftwareFile();
                OverriteAllDatabaseConnectionFiles();
                Log.AppendToLogCustomText(Log.LogType.INFO, "Finalizada a atualização dos arquivos de configuração.");

                Log.ShowNotificationClickHereToSeeLogFile("Arquivos de Configuração", "Finalizado o processo de atualização dos arquivos de configuração!");
            }

            private void OverriteAllDatabaseConnectionFiles()
            {
                OverriteInstalledSetupDatabaseConnectionFiles();
                OverriteWorkspaceTFSDatabaseConnectionFiles();
                OverriteWorkspaceTFSUnitTest();
            }

            private void OverriteInstalledSetupCustomSoftwareFile()
            {
                var path = @"C:\Custom Software\ERP\OuroNetApp";

                var ouroNetApp = new OuroNetApp();
                _ = ouroNetApp.MakeFileAsync(path);

                Log.AppendToLogUpdatedFile(path, ouroNetApp.FileNameWithExtension);
            }

            private void OverriteInstalledSetupDatabaseConnectionFiles()
            {
                var path = @"C:\inetpub\wwwroot";

                string ouroNet = "OuroNet";
                var folders = new List<string>
                {
                    $"{ouroNet}Cadastro",
                    $"{ouroNet}Financeiro",
                    $"{ouroNet}Movimento",
                    "OuroWebAPI"
                };
                folders = Collection.AppendStringAtEndFromItemsAtList("Teste", folders);

                UpdateAllDatabaseConnectionFiles(path, folders);
            }

            private void OverriteWorkspaceTFSDatabaseConnectionFiles()
            {
                var path = @"C:\DvpLocal\WorkspaceTFS\OuroNet\Scc\Producao\OuroNet\02-Source\02-Server";

                var ouroNetServerWCF = "OuroNet.Server.WCF.";
                var folders = new List<string>
                {
                    $"{ouroNetServerWCF}Cadastre",
                    $"{ouroNetServerWCF}Financial",
                    $"{ouroNetServerWCF}Movement",
                    "Custom.OuroNet.Server.WebApi"
                };

                UpdateAllDatabaseConnectionFiles(path, folders);
            }

            private void OverriteWorkspaceTFSUnitTest()
            {
                var path = @"C:\DvpLocal\WorkspaceTFS\OuroNet\Scc\Producao\OuroNet\03-Test\02-Server\02-Service";

                var folders = new List<string> { "Cadastro", "Financeiro", "Movimento", "WebApi" };
                folders = folders.Select(folder => $"Cadastro{folder}Service").ToList();

                UpdateAllDatabaseConnectionFiles(path, folders);
            }

            private void UpdateAllDatabaseConnectionFiles(string path, List<string> folders)
            {
                Log.AppendToLogCustomText(Log.LogType.INFO, $"Atualizando os arquivos de configuração de {path}.");

                foreach (var folder in folders)
                {
                    var fullFolderPath = Path.Combine(path, folder);

                    var connectionString = new ConnectionString();
                    _ = connectionString.MakeFileAsync(fullFolderPath);
                    Log.AppendToLogUpdatedFile(fullFolderPath, connectionString.FileNameWithExtension);

                    var configurationServer = new ConfigurationServer();
                    _ = configurationServer.MakeFileAsync(fullFolderPath);
                    Log.AppendToLogUpdatedFile(fullFolderPath, configurationServer.FileNameWithExtension);
                }

                Log.AppendToLogCustomText(Log.LogType.INFO, $"Foram atualziados os arquivos de configuração de {path}.");
            }
        }
    }
}
