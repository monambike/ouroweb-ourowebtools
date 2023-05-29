using System;
using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace OuroWebTools.Desktop
{
    internal partial class TrayIcon
    {
        private static Window Window { get; set; } = null;

        internal static NotifyIcon notifyIcon = new NotifyIcon()
        {
            Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location),
            Visible = true,
            ContextMenu = new ContextMenu()
        };

        /// <summary>
        /// Method for when you click at tray icon open a window.
        /// </summary>
        /// <param name="window"></param>
        internal TrayIcon(Window window)
        {
            Window = window;

            SetEventForNotifyIconClick();
            Menu.RefillMenuItems();
        }

        private static void SetEventForNotifyIconClick()
        {
            notifyIcon.Click += delegate (object sender, EventArgs e)
            {
                MouseEventArgs mouseEventArgs = (MouseEventArgs)e;

                if (mouseEventArgs.Button == MouseButtons.Left)
                {
                    Window.ShowInTaskbar = true;
                    Window.Show();
                }
            };
        }

        //private static void Logoff()
        //{
        //    Common.Utilities.Application.Exit();
        //}

        //private static void UpdateDatabase()
        //{
        //    var instance = @"SRV-DVP01\SQLDVP17";
        //    var database = "MilFarmaVs1013_DVP17";
        //    var versao = "10.1.3";
        //    var path = @"\\vm-srvfile01\fontes\aplication\ouronet\10.1\teste\scripts\sub versão\10.1.3";

        //    Notification.UpdateDatabase.UpdatingDatabase(instance, database, versao, path);
        //}
    }
}
