namespace Common.Models
{
    public partial class OuroNet
    {
        public partial class ConfigFile
        {
            public class OuroNetApp : Base
            {
                public override string FileNameWithExtension => "OuroNetApp.exe.config";

                protected override string ConfigFileContentToString()
                {
var result =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<configuration>
  <configSections>
    <section name=""entityFramework"" type=""System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" requirePermission=""false"" />
    <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
    
  </configSections>
  <startup>
    <supportedRuntime version=""v4.0"" sku="".NETFramework,Version=v4.5"" />
  </startup>
  <system.serviceModel>
    <bindings>
      <basicHttpBinding>
        <binding name=""EndPointBasicHttp"" closeTimeout=""00:05:00"" openTimeout=""00:05:00"" receiveTimeout=""00:05:00"" sendTimeout=""00:05:00"" maxBufferPoolSize=""2147483647"" maxBufferSize=""2147483647"" maxReceivedMessageSize=""2147483647"" transferMode=""Streamed"" useDefaultWebProxy=""false"" messageEncoding=""Text"">
          <readerQuotas maxDepth=""64"" maxStringContentLength=""2147483647"" maxArrayLength=""2147483647"" maxBytesPerRead=""4096"" maxNameTableCharCount=""16384"" />
          <security mode=""None"" />
        </binding>
      </basicHttpBinding>
      <netTcpBinding>
        <binding name=""EndPointNetTcp"" closeTimeout=""00:05:00"" openTimeout=""00:05:00"" receiveTimeout=""00:05:00"" sendTimeout=""00:05:00"" transactionFlow=""false"" maxBufferPoolSize=""2147483647"" maxBufferSize=""2147483647"" maxReceivedMessageSize=""2147483647"" portSharingEnabled=""false"">
          <readerQuotas maxDepth=""64"" maxStringContentLength=""2147483647"" maxArrayLength=""2147483647"" maxBytesPerRead=""4096"" maxNameTableCharCount=""16384"" />
          <reliableSession enabled=""false"" />
          <security mode=""None"">
            <transport clientCredentialType=""None"" protectionLevel=""None"" />
            <message clientCredentialType=""None"" />
          </security>
        </binding>
      </netTcpBinding>
    </bindings>
    <client>
      <endpoint address=""http://localhost/OuroNetCadastroTeste/Cadastro.svc""
        binding=""basicHttpBinding"" bindingConfiguration=""EndPointBasicHttp""
        contract=""CadastroService.ICadastro"" name=""EndPointBasicHttp"" />
      <endpoint address=""net.tcp://localhost/OuroNetCadastroTeste/Cadastro.svc""
        binding=""netTcpBinding"" bindingConfiguration=""EndPointNetTcp""
        contract=""CadastroService.ICadastro"" name=""EndPointNetTcp"" />
      <endpoint address=""http://localhost/OuroNetMovimentoTeste/Movimento.svc""
        binding=""basicHttpBinding"" bindingConfiguration=""EndPointBasicHttp""
        contract=""MovimentoService.IMovimento"" name=""EndPointBasicHttp"" />
      <endpoint address=""net.tcp://localhost/OuroNetMovimentoTeste/Movimento.svc""
        binding=""netTcpBinding"" bindingConfiguration=""EndPointNetTcp""
        contract=""MovimentoService.IMovimento"" name=""EndPointNetTcp"" />
      <endpoint address=""http://localhost/OuroNetFinanceiroTeste/Financial.svc""
        binding=""basicHttpBinding"" bindingConfiguration=""EndPointBasicHttp""
        contract=""FinanceiroService.IFinancial"" name=""EndPointBasicHttp"" />
      <endpoint address=""net.tcp://localhost/OuroNetFinanceiroTeste/Financial.svc""
        binding=""netTcpBinding"" bindingConfiguration=""EndPointNetTcp""
        contract=""FinanceiroService.IFinancial"" name=""EndPointNetTcp"" />
    </client>
  </system.serviceModel>
  <runtime>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""Newtonsoft.Json"" publicKeyToken=""30ad4fe6b2a6aeed"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-6.0.0.0"" newVersion=""6.0.0.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""System.Data.SQLite"" publicKeyToken=""db937bc2d44ff139"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-1.0.104.0"" newVersion=""1.0.104.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""BouncyCastle.Crypto"" publicKeyToken=""0e99375e54769942"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-1.8.9.0"" newVersion=""1.8.9.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""ICSharpCode.SharpZipLib"" publicKeyToken=""1b03e6acf1164f73"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-1.3.3.11"" newVersion=""1.3.3.11"" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
  <entityFramework>
    <defaultConnectionFactory type=""System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework"">
      <parameters>
        <parameter value=""v12.0"" />
      </parameters>
    </defaultConnectionFactory>
    <providers>
      <provider invariantName=""System.Data.SQLite"" type=""System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6"" />
      <provider invariantName=""System.Data.SqlClient"" type=""System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer"" />
      <provider invariantName=""System.Data.SQLite.EF6"" type=""System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6"" />
    </providers>
  </entityFramework>
  <system.data>
    <DbProviderFactories>
      <remove invariant=""System.Data.SQLite"" />
      <add name=""SQLite Data Provider"" invariant=""System.Data.SQLite"" description="".Net Framework Data Provider for SQLite"" type=""System.Data.SQLite.SQLiteFactory, System.Data.SQLite"" />
      <remove invariant=""System.Data.SQLite.EF6"" />
      <add name=""SQLite Data Provider (Entity Framework 6)"" invariant=""System.Data.SQLite.EF6"" description="".NET Framework Data Provider for SQLite (Entity Framework 6)"" type=""System.Data.SQLite.EF6.SQLiteProviderFactory, System.Data.SQLite.EF6"" />
    </DbProviderFactories>
  </system.data>
  <connectionStrings>
    <add name=""OuroNetSqliteContext"" connectionString=""Data Source=.\OuroNet.sqlite"" providerName=""System.Data.SQLite"" />
  </connectionStrings>
</configuration>";

                    return result;
                }
            }
        }
    }
}
