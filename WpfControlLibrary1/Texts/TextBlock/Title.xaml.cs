using System.Windows.Controls;

namespace Common.UserControls
{
    public partial class Title : UserControl
    {
        private string title;
        public string Text { get => title; set => title = txtTitle.Text = value; }

        public Title() => InitializeComponent();
    }
}
