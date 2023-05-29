using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Common.UserControls
{
    public partial class SuggestionTextBox : UserControl
    {
        private string label;
        public string Label { get => label; set => label = lblLabel.LabelText = value; }

        private string text;
        public string Text { get => text; set => text = txtSuggestionTextBox.Text = value; }

        private string _suggestionTextBoxText = "";
        private string _suggestionTextBoxSuggestion = "";

        private List<string> suggestionItemSource;
        public List<string> SuggestionItemSource { get => suggestionItemSource; set => suggestionItemSource = value; }

        public SuggestionTextBox()
        {
            InitializeComponent();

            txtSuggestionTextBox.TextChanged += SuggestionTextBoxOnTextChanged;
        }

        private void SuggestionTextBoxOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var input = txtSuggestionTextBox.Text;

            if (input.Length > _suggestionTextBoxText.Length && input != _suggestionTextBoxSuggestion)
            {
                _suggestionTextBoxSuggestion = GetSuggestionOnItemSource(input);

                if (_suggestionTextBoxSuggestion != null) SetSuggestionToTextBox(input);
            }
            _suggestionTextBoxText = input;
        }

        private string GetSuggestionOnItemSource(string inputText)
        {
            var suggestion = SuggestionItemSource.LastOrDefault(firstItem =>
                firstItem.ToLower().StartsWith(inputText.ToLower()));

            return suggestion;
        }

        private void SetSuggestionToTextBox(string suggestion)
        {
            var _selectionStart = suggestion.Length;
            var _selectionLength = _suggestionTextBoxSuggestion.Length - suggestion.Length;

            txtSuggestionTextBox.Text = _suggestionTextBoxSuggestion;
            txtSuggestionTextBox.Select(_selectionStart, _selectionLength);
        }
    }
}
