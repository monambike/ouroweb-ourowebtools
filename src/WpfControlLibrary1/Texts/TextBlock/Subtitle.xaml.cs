using System.Windows.Controls;

namespace Common.UserControls
{
    public partial class Subtitle : UserControl
    {
        private string title;
        public string Text { get => title; set => title = txtTitle.Text = value; }

        public Subtitle() => InitializeComponent();
    }
}
