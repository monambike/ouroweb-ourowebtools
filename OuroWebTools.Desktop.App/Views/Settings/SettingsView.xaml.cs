using System.Windows;
using System.Windows.Input;

namespace OuroWebTools.Desktop.Views.Settings
{
    public partial class SettingsView : Window
    {
        public static SettingsView Instance { get; private set; }

        public static SettingsView settingsView;

        static SettingsView() => Instance = new SettingsView();

        private SettingsView() => InitializeComponent();

        private void Button_Click(object sender, RoutedEventArgs e) => Close();

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }

        //private void ListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    var listBox = sender as ListBox;
        //    var selectedItemText = listBox.SelectedItem?.ToString();

        //    ViewModels.ConnectionStringViewModel.RemoveItemFromList(selectedItemText);
        //}
    }
}
