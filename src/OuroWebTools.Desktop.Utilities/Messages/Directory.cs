using System.Windows;

namespace Common.Utilities
{
    public static partial class Message
    {
        public static class Directory
        {
            public static MessageBoxResult NotFound(string path)
            {
                return Custom.Warning($@"O diretório ""{path}"" não foi encontrado.");
            }
        }
    }
}
