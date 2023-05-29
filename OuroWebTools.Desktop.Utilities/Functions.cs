using Microsoft.Toolkit.Uwp.Notifications;
using System.Windows;

namespace Common.Utilities
{
    public static class Functions
    {
        public static void CopyToClipboard(string titleContentCopied, string bodyContentCopied, string contentToCopy)
        {
            Clipboard.SetText(contentToCopy);

            new ToastContentBuilder()
                .AddText($"{titleContentCopied} Copiado")
                .AddText($@"O {bodyContentCopied} foi copiado para a área de transferência.")
                .Show();
        }
    }
}
