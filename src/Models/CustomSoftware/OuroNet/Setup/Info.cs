using Common.Utilities;
using System;
using System.Threading.Tasks;

namespace Common.Models
{
    public partial class OuroNet
    {
        public static class Info
        {
            public static async Task MakeSetupTransferenceInfoFile(string folderPath = null)
            {
                var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                folderPath = folderPath ?? desktopPath;
                const string fileName = "info.txt";

                await File.AskToOverriteAsync(fileName, folderPath, SetupTransferenceInfoToString());
            }

            public static string SetupTransferenceInfoToString()
                => string.Format(
                    "GERAÇÃO DE SETUP"
                    + "{0}" + @"Setup do ""OuroNet"" gerado em {1:dd/MM/yyyy} às {1:HH:mm:ss}"
                    + "{0}" + $"{UserInfoToString()}"
                    + "{0}" + "OUTRAS INFORMAÇÕES"
                    + "{0}" + $"{AdditionalUserInfoToString()}"
                    + "{0}" + $"{OperationalSystemInfoToString()}",

                    Environment.NewLine + Environment.NewLine,
                    DateTime.Now
                );

            public static new string ToString() => SetupTransferenceInfoToString();

            private static string UserInfoToString()
                => string.Format(
                    "Informações do Usuário"
                    //+ "{0}" + "Nome: " + System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName
                    + "{0}" + "Usuário: " + Environment.UserName
                    + "{0}" + "Nome da Máquina: " + Environment.MachineName,

                    Environment.NewLine
                );

            private static string AdditionalUserInfoToString()
                => string.Format(
                    "Informações Adicionais do Usuário"
                    //+ "{0}" + "Nome: " + System.DirectoryServices.AccountManagement.UserPrincipal.Current.Name
                    //+ "{0}" + "Nome Principal: " + System.DirectoryServices.AccountManagement.UserPrincipal.Current.UserPrincipalName
                    + "{0}" + "Domínio: " + Environment.UserDomainName
                    + "{0}" + "Nome no Registro de Identidade do Windows: " +
                    System.Security.Principal.WindowsIdentity.GetCurrent().Name,

                    Environment.NewLine
                );

            private static string OperationalSystemInfoToString()
                => string.Format(
                    "Informações do Sistema Operacional"
                    + "{0}" + "Ambiente de Trabalho: " + Environment.WorkingSet
                    + "{0}" + "Versão: " + Environment.Version
                    + "{0}" + "Versão do Sistema Operacional: " + Environment.OSVersion.VersionString,
                    Environment.NewLine
                );
        }
    }
}
