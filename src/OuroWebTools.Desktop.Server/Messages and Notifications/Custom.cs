using Microsoft.Toolkit.Uwp.Notifications;

namespace Common.Server
{
    internal static partial class Messages
    {
        internal static class Custom
        {
            public static void Error(string message) => new ToastContentBuilder().AddText("Erro no Servidor").AddText(message).Show();
        }
    }
}
