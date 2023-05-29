using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;

namespace OuroWebTools.Desktop.Views
{
    public partial class MainWindow : Window
    {
        internal MainWindow()
        {
            ShutdownApplicationIfAlreadyRunning();

            InitializeComponent();
            _ = new TrayIcon(this);

            var openMainWindowOnStartup = OuroWebTools.Settings.Application.Default.OpenMainWindowOnStartup;
            if (!openMainWindowOnStartup) Close();
        }

        /// <summary>
        /// Hides window on closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Hide();
            ShowInTaskbar = false;
            e.Cancel = true;
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private static void ShutdownApplicationIfAlreadyRunning()
        {
            Process currentProcess = Process.GetCurrentProcess();
            var runningProcess = (from process in Process.GetProcesses()
                                  where
                                    process.Id != currentProcess.Id &&
                                    process.ProcessName.Equals(
                                      currentProcess.ProcessName,
                                      StringComparison.Ordinal)
                                  select process).FirstOrDefault();

            if (runningProcess != null) System.Windows.Application.Current.Shutdown();
        }
    }
}
