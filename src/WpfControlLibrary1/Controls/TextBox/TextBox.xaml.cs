using System.Windows;
using System.Windows.Controls;

namespace Common.UserControls
{
    [System.ComponentModel.DefaultBindingProperty("Text")]
    public partial class TextBox : UserControl
    {
        private string labelText;
        public string LabelText { get => labelText; set => labelText = lblLabel.LabelText = value; }

        public string Text { get => (string)GetValue(TextProperty); set => SetValue(TextProperty, value); }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextBox), new PropertyMetadata(""));

        public TextBox() => InitializeComponent();
    }


    //public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextBox), new PropertyMetadata(null));
    //public string Text { get => (string)GetValue(TextProperty); set => SetValue(TextProperty, value); }
}
