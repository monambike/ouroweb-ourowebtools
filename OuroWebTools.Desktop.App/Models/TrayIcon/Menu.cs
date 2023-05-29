using Common.Models;
using System;
using System.Windows.Forms;

namespace OuroWebTools.Desktop
{
    internal partial class TrayIcon
    {
        internal static partial class Menu
        {
            internal static void RefillMenuItems()
            {
                notifyIcon.ContextMenu.MenuItems.Clear();

                notifyIcon.ContextMenu.MenuItems.AddRange(GetOpenExternalAppsMenuItems());
                notifyIcon.ContextMenu.MenuItems.AddRange(new MenuItem[] { new MenuItem("-") });
                notifyIcon.ContextMenu.MenuItems.AddRange(GetCopySetupMenuItems());
                notifyIcon.ContextMenu.MenuItems.AddRange(GetCopyTemplatesMenuItems());
                notifyIcon.ContextMenu.MenuItems.AddRange(new MenuItem[] { new MenuItem("-") });
                notifyIcon.ContextMenu.MenuItems.AddRange(GetFurtherItemsMenuItems());
                notifyIcon.ContextMenu.MenuItems.AddRange(new MenuItem[] { new MenuItem("-") });
                notifyIcon.ContextMenu.MenuItems.AddRange(GetFooterMenuItems());
            }

            internal static MenuItem[] GetOpenExternalAppsMenuItems()
            {
                var menuItems = new MenuItem[]
                {
                    new MenuItem("Abrir", new MenuItem[]
                    {
                        new MenuItem("Transferência de Setup",
                            delegate { OpenExternalApplication.OpenApplication(OpenExternalApplication.Application.SetupTransference); } ),
                        new MenuItem("Atualizar Base (SQL Executor)",
                            delegate { OpenExternalApplication.OpenApplication(OpenExternalApplication.Application.SqlExecutor); } ),
                        new MenuItem("Gerar Pacote (Script Executor)",
                            delegate { OpenExternalApplication.OpenApplication(OpenExternalApplication.Application.ScriptPackage); } ),
                        new MenuItem("-"),
                        new MenuItem("FollowWeb",
                            delegate { OpenExternalApplication.OpenApplication(OpenExternalApplication.Application.FollowWeb); } ),
                        new MenuItem("Registro de Hora de Trabalho",
                            delegate { OpenExternalApplication.OpenApplication(OpenExternalApplication.Application.WorkTimeRegister); } ),
                        new MenuItem("-"),
                        new MenuItem("Criar Configuração ou Permissão (ObjetosWeb)",
                            delegate { OpenExternalApplication.OpenApplication(OpenExternalApplication.Application.ObjectsWeb); } ),
                        new MenuItem("Criptografia de Senhas da OuroWeb (CryptFast)",
                            delegate { OpenExternalApplication.OpenApplication(OpenExternalApplication.Application.CryptFast); } )
                    })
                };

                return menuItems;
            }

            internal static MenuItem[] GetCopySetupMenuItems()
            {
                var menuItems = new MenuItem[]
                {
                    new MenuItem("Copiar Setup para", new MenuItem[]
                    {
                        new MenuItem("Minha Máquinha", delegate (object sender, EventArgs e) {
                            var version = new Common.Server.SingleVersion();

                            var ouroNetSetup = new OuroNet.Setup(version);
                            ouroNetSetup.TransferAllSetups();
                        }),
                        new MenuItem("Pasta do Teste do Servidor", delegate (object sender, EventArgs e) {
                            var version = new Common.Server.SingleVersion();

                            var ouroNetSetup = new OuroNet.Setup(version);
                            ouroNetSetup.TransferAllSetups();
                        })
                    })
                };

                return menuItems;
            }

            internal static MenuItem[] GetCopyTemplatesMenuItems()
            {
                int pendenciaId = Settings.CurrentWorkingOn.Default.IssueNumber;

                var menuItems = new MenuItem[]
                {
                    new MenuItem(
                        "Copiar Templates", new MenuItem[]
                        {
                            new MenuItem(Template.CheckinPendencia.TemplateName,
                                delegate (object sender, EventArgs e) { new Template.CheckinPendencia(pendenciaId).CopyToClipboard(); } ),
                            new MenuItem(Template.CheckinRetornoDeIncidente.TemplateName,
                                delegate (object sender, EventArgs e) { new Template.CheckinRetornoDeIncidente(pendenciaId).CopyToClipboard(); } ),
                            new MenuItem(Template.TaskNote.TemplateName,
                                delegate (object sender, EventArgs e) { new Template.TaskNote(pendenciaId).CopyToClipboard(); } )
                        }
                    )
                };

                return menuItems;
            }

            internal static MenuItem[] GetFurtherItemsMenuItems()
            {
                var menuItems = new MenuItem[]
                {
                    new MenuItem("Atualizar Arquivos de Configuração",
                        delegate (object sender, EventArgs e) { new OuroNet.ConfigFile().OverriteAllConfigurationFiles(); } ),
                    new MenuItem("Copiar Caminho do OuroWeb",
                        delegate (object sender, EventArgs e) { OuroWeb.CopyFullPathToClipboard(); } )
                };

                return menuItems;
            }

            internal static MenuItem[] GetFooterMenuItems()
            {
                var menuItems = new MenuItem[]
                {
                    new MenuItem("Configurações",
                        delegate (object sender, EventArgs e) { Views.Settings.SettingsView.Instance.Show(); }),
                    new MenuItem("Sobre o Aplicativo",
                        delegate (object sender, EventArgs e) { Views.AboutView.Instance.Show(); } ),
                    new MenuItem("Sair",
                        delegate (object sender, EventArgs e) { Common.Utilities.Application.Exit(); } )
                };

                return menuItems;
            }
        }
    }
}
