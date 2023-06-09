using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Controls;

namespace Common.UserControls
{
    public partial class ComboListBox : UserControl
    {
        private string description;
        public string Description { get => description; set => description = txtBody.Text = value; }

        private IEnumerable comboBoxItemsSource;
        public IEnumerable ComboBoxItemsSource { get => comboBoxItemsSource; set => comboBoxItemsSource = cmbComboBox.ItemsSource = value; }

        private IEnumerable listBoxItemsSource;
        public IEnumerable ListBoxItemsSource { get => listBoxItemsSource; set => listBoxItemsSource = lstListBox.ItemsSource = value; }

        public ComboListBox() => InitializeComponent();

        private void ListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) => Delete();

        private void Delete() { }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when ComboBox value selection has changed")]
        public event EventHandler<SelectionChangedEventArgs> ComboBoxSelectionChanged;
        protected void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => ComboBoxSelectionChanged?.Invoke(this, e);
    }
}
