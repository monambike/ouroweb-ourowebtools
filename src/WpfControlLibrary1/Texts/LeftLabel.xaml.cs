using System.Windows.Controls;

namespace Common.UserControls
{
    public partial class LeftLabel : UserControl
    {
        private string labelText;
        public string LabelText { get => labelText; set => labelText = lblLabel.Text = value; }

        public LeftLabel() => InitializeComponent();
    }
}
