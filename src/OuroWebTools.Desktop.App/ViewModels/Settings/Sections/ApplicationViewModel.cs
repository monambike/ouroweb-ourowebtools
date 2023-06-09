using Microsoft.Win32;

namespace OuroWebTools.Desktop.ViewModels
{
    internal partial class ApplicationViewModel
    {
        private bool _startAppWithWindows;
        internal bool StartAppWithWindowsProperty
        {
            get => _startAppWithWindows;
            set
            {
                var registryKeyStartupApps = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                // Add the value in the registry so that the application runs at startup
                if (value) registryKeyStartupApps.SetValue(AssemblyInfo.Title, System.Windows.Forms.Application.ExecutablePath);
                // Remove the value from the registry so that the application doesn't start
                else registryKeyStartupApps.DeleteValue(AssemblyInfo.Title, false);

                _startAppWithWindows = Settings.Application.Default.ApplicationStartOnStartup = value;
                Settings.Application.Default.Save();
            }
        }
    }
}
