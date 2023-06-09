using System;

namespace Common.Models
{
    public partial class OuroNet
    {
        public partial class ConfigFile
        {
            public class ConfigurationServer : Base
            {
                public override string FileNameWithExtension => "custom.configuration.server.config";

                protected override string ConfigFileContentToString()
                {
                    string result =
$@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<custom.configuration.server>
  <products>
    <product name=""OuroWeb"" encryptionType=""Crypto"" serializationType=""Json"" compressionType=""GZipCompression"">
      <enterprises>
        <enterprise key=""1"" enterpriseName=""nenhuma dentro do arquivo 'connectionStrings.config' ou 'custom.configuration.server.config'"">
          <databases>
            {GetListOfDatabasesToString()}
          </databases>
        </enterprise>
      </enterprises>
    </product>
  </products>
</custom.configuration.server>";

                    return result;
                }

                private static string GetListOfDatabasesToString()
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
            <database name=""{database.Name}"" key=""OuroWeb_{database.Name}"">
              <auxiliarydatabases>
                <auxdatabase name=""OuroReports"" key=""OuroReports_{database.Name}""/>
              </auxiliarydatabases>
            </database>";
                        });

                        result += $"{Environment.NewLine}";
                    });

                    return result;
                }
            }
        }
    }
}
