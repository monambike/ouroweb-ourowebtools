using System.Windows.Input;

namespace OuroWebTools.Desktop.ViewModels
{
    internal partial class MainWindowViewModel
    {
        internal ICommand WindowStateChanged { get; set; }

        internal MainWindowViewModel() => WindowStateChanged = new RelayCommand(action => { });
    }
}
