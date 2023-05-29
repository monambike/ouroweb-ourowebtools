using Microsoft.Toolkit.Uwp.Notifications;

namespace ScriptPackage.Desktop.App
{
    public class Notification
    {
        public static void UpdatingDatabase(string instance, string database)
        {

            new ToastContentBuilder()
                .AddText("Atualização de Base")
                .AddText(
                    "A base está sendo atualizada. Você pode cancelar a operação à qualquer momento "
                  + "utilizando o ícone da bandeja."
                )
                //.AddText("A base começou a ser atualizada, você pode cancelar o processo à qualquer momento.")
                .AddProgressBar(
                    $@"Server: ""{instance}"" | Database: ""{database}""",
                    0, true,
                    $"Atualizando Base", "Rodando Pacotes..."
                )
                .Show();
        }
    }
}
