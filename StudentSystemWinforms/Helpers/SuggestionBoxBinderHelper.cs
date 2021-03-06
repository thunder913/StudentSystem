using StudentSystemCommon.Controls;
using StudentSystemWinForms.Models;
using System.Windows;
using System.Windows.Data;

namespace StudentSystemWinForms.Utils
{
    public static class SuggestionBoxBinderHelper
    {
        public static void BindPropertiesToSuggestionBox(SuggestTextBox suggestBox, ViewModelBase viewModel, string placeholderText, 
            string autoSuggestPropertyName, string textPropertyName, string valueMemberPropertyName, string itemsPropertyName, string cycleSuggestions)
        {
            suggestBox.Placeholder = placeholderText;

            suggestBox.SetBinding(SuggestTextBox.AutoSuggestProperty, new Binding()
            {
                Mode = BindingMode.TwoWay,
                Source = viewModel,
                Path = new PropertyPath(autoSuggestPropertyName)
            });

            suggestBox.SetBinding(SuggestTextBox.TextProperty, new Binding()
            {
                Mode = BindingMode.TwoWay,
                Source = viewModel,
                Path = new PropertyPath(textPropertyName)
            });

            suggestBox.SetBinding(SuggestTextBox.ValueMemberProperty, new Binding()
            {
                Mode = BindingMode.TwoWay,
                Source = viewModel,
                Path = new PropertyPath(valueMemberPropertyName)
            });

            suggestBox.SetBinding(SuggestTextBox.ItemsProperty, new Binding()
            {
                Mode = BindingMode.TwoWay,
                Source = viewModel,
                Path = new PropertyPath(itemsPropertyName)
            });

            if (cycleSuggestions != null)
            {
                suggestBox.SetBinding(SuggestTextBox.CycleSuggestionsProperty, new Binding()
                {
                    Mode = BindingMode.TwoWay,
                    Source = viewModel,
                    Path = new PropertyPath(cycleSuggestions)
                });
            }
        }
    }
}
