using System.Windows;

namespace WorkTimeNote.TrayIcon
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void Application_Startup(object sender, StartupEventArgs e)
        {
            CreateNewTrayIconInstance();
        }

        public static void CreateNewTrayIconInstance()
        {
            TrayIcon trayIcon = new TrayIcon();
        }
    }
}
