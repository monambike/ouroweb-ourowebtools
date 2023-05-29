using Microsoft.Toolkit.Uwp.Notifications;

namespace ScriptPackage.Model
{
    public class Notification
    {
        public class UpdateDatabase
        {
            public static void UpdatingDatabase(string instance, string database, string version, string path)
            {
                new ToastContentBuilder()
                    .AddText("Atualização de Base")
                    .AddText(
                        "A base está sendo atualizada. Você pode cancelar a operação à qualquer momento "
                      + "utilizando o ícone da bandeja."
                      + "\n"
                      + $@"Caminho atual: ""{path}"""
                    )
                    //.AddText("Caminho atual: ""{path}""")
                    //.AddText("A base começou a ser atualizada, você pode cancelar o processo à qualquer momento.")
                    .AddProgressBar(
                        $@"{instance} | {database}",
                        0, true,
                        $"{version}", $@"Rodando Pacotes..."
                    )
                    .AddArgument("open_current_running_package_folder")
                    .Show();
            }

            public static void FinishedWithSuccess()
            {
                new ToastContentBuilder()
                    .AddText("Atualização de Base")
                    .AddText("A base foi atualizada com êxito!")
                    .Show();
            }
        }
    }
}
