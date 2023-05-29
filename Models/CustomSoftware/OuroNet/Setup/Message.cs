using System;
using System.Windows;
using Common.Utilities;

namespace Common.Models
{
    public partial class OuroNet
    {
        public partial class Setup
        {
            public static class Message
            {
                public static MessageBoxResult AlreadyExistsAskToOverrite(string setupSourcePath, string setupTargetPath)
                {
                    return Utilities.Message.Custom.Question(
                        string.Format(
                                        $@"Ao clicar em ""OK"" o Setup presente em ""{setupTargetPath}"" será apagado e substituído pelo"
                            + "{0}" + $@" Setup presente em ""{setupSourcePath}""."
                            + "{0}" + "Caso o caminho esteja apontando para o local incorreto ou não possua as alterações"
                            + "{0}" + "mais recentes e mesmo assim você decida gerar, a responsabilidade poderá recair sobre você."
                            + "{0}" + "Lembrando que é necessário:"
                            + "{0}" + @"- Dar ""Undo Checkout"" na solução inteira para não correr riscos de alterações não virem do TFS;"
                            + "{0}" + @"- Dar Clean e Rebuild, com o modo ""Debug"" e depois em ""Release"", para garantir que não"""
                            + "{0}" + @" há problemas de compilação em ambos os modos de compilação;"
                            + "{0}" + @"- Dar ""Get Last Version"", ou preferencialmente ""Get Specific Version"" com as duas Checkbox marcadas"
                            + "{0}" + "para garantir que você vai conseguir pegar as últimas alterações."
                            + "{0}"
                            + "{0}" + "Você está de acordo com as informações acima e gostaria de gerar o Setup?",
                            Environment.NewLine
                        )
                    );
                }

                public static MessageBoxResult SuccessTransferSetupAt(string setupPath) => Utilities.Message.Custom.Information($"O Setup foi movido com sucesso para {setupPath}.");

                public static MessageBoxResult NotFoundLocalSetup() => Utilities.Message.Custom.Information($"O Setup de alvo não foi encontrado.");
            }
        }
    }
}
