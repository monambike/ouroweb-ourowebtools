using System;
using System.Windows;

namespace Common.Utilities
{
    public static partial class File
    {
        private static class Message
        {
            public static MessageBoxResult SuccessCreateFileAtPath(string filePath) => Utilities.Message.Custom.Information($@"O arquivo foi gerado com sucesso em ""{filePath}"".");

            public static MessageBoxResult FileAlreadyExistsAskToOverrite(string fileName, string filePath)
            {
                return Utilities.Message.Custom.Question(
                    string.Format(
                        $@"O arquivo ""{fileName}"" já existe em ""{filePath}""."
                        + "{0}"
                        + "{0}" + "Você gostaria de sobreescrever o arquivo?",
                        Environment.NewLine
                    )
                );
            }
        }
    }
}
