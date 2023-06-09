using System;

namespace Common.Models
{
    public partial class OuroNet
    {
        public partial class ConfigFile
        {
            public class ConnectionString : Base
            {
                public override string FileNameWithExtension => "connectionStrings.config";

                protected override string ConfigFileContentToString()
                {
                    var result =
$@"<?xml version=""1.0"" encoding=""utf-8""?>
<configuration>
  <configSections>
    <section name = ""dataConfiguration"" type=""Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSettings, Microsoft.Practices.EnterpriseLibrary.Data"" requirePermission=""false"" />
  </configSections>
  <dataConfiguration defaultDatabase = ""OuroWeb_MilfarmaVs1007_DVP"" />
  <connectionStrings>
    {GetListOfConnectionStringsToString()}
  </connectionStrings>
</configuration>";

                    return result;
                }

                private string GetListOfConnectionStringsToString()
                {
                    string result = "";

                    Servers.ForEach(server =>
                    {
                        result +=
    $@"
    <!-- {server.Name} -->";

                        server.Databases.ForEach(
                        database =>
                        {
                            result +=
    $@"
    <add name=""OuroWeb_{database.Name}""
         connectionString=""Data Source={server.Name};Initial Catalog={database.Name};User ID=ouro;Password=nc7895al63;Application Name=OuroWeb""
         providerName=""System.Data.SqlClient"" />";
                        }
                        );
                        
                        result += $"{Environment.NewLine}";
                    }
                    );


                    return result;
                }
            }
        }
    }
}
