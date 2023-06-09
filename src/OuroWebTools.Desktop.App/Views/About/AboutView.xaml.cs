using System.Windows;

namespace OuroWebTools.Desktop.Views
{
    public partial class AboutView : Window
    {
        public static AboutView Instance { get; private set; }

        public static AboutView myMainWindow;

        static AboutView() => Instance = new AboutView();

        internal AboutView() => InitializeComponent();
    }
}
