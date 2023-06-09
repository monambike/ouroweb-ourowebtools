using System.Reflection;
using System.Windows;

namespace Common.Utilities
{
    public static partial class Message
    {
        public static class Custom
        {
            public static MessageBoxResult Information(string message) => DefaultTemplate(message , "Caixa de Informação", MessageBoxButton.OK , MessageBoxImage.Asterisk);

            public static MessageBoxResult Error(string message) => DefaultTemplate(message , "Erro", MessageBoxButton.OK , MessageBoxImage.Error);
            
            public static MessageBoxResult Warning(string message) => DefaultTemplate(message , "Aviso", MessageBoxButton.OK , MessageBoxImage.Warning);

            public static MessageBoxResult Question(string message) => DefaultTemplate(message , "Caixa de Confirmação", MessageBoxButton.YesNo , MessageBoxImage.Question);

            private static MessageBoxResult DefaultTemplate(string message, string title, MessageBoxButton messageBoxButton, MessageBoxImage messageBoxImage) => MessageBox.Show(message, $"{title} - {Assembly.GetEntryAssembly().GetName().Name}", messageBoxButton, messageBoxImage);
        }
    }
}
