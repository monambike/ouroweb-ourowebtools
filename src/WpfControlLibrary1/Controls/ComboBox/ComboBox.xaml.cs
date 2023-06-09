using System.Collections;
using System.Windows.Controls;

namespace Common.UserControls
{
    public partial class ComboBox : UserControl
    {
        private string label;
        public string Label { get => label; set => label = lblLabel.LabelText = value; }

        private IEnumerable itemsSource;
        public IEnumerable ItemsSource { get => itemsSource; set => itemsSource = cmbComboBox.ItemsSource = value; }

        public ComboBox() => InitializeComponent();
    }
}
