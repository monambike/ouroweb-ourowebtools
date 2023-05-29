using System.Windows.Controls;

namespace Common.UserControls
{
    public partial class Body : UserControl
    {
        private string title;
        public string Text { get => title; set => title = txtTitle.Text = value; }

        public Body() => InitializeComponent();
    }
}
