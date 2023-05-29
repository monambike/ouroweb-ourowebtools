using Microsoft.Toolkit.Uwp.Notifications;

namespace Common.Models
{
    public class Notification
    {
        public void SetupMade(string path)
        {
            new ToastContentBuilder()
                .AddText("Setup Gerado")
                .AddText(
                    "O setup foi gerado com sucesso. Clique aqui para a abrir a pasta" +
                    "onde ele se localiza."
                )
                .AddText($@"Setup gerado em: ""{path}""")
                .Show();
        }
    }
}
