using System.Windows.Controls;

namespace Common.UserControls
{
    public partial class CheckBox : UserControl
    {
        private string label;
        public string Label { get => label; set => label = txtLabel.LabelText = value; }

        public CheckBox() => InitializeComponent();

        private void DockPanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => cmbCheckBox.IsChecked = !cmbCheckBox.IsChecked;
    }
}
