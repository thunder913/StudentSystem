using System.Windows.Input;

namespace StudentSystemWinForms.MVVM.ViewModel
{
    public interface IViewModelSuggestions
    {
        public ICommand CycleSuggestionCommand { get; set; }
        public int SuggestionIndex { get; set; }
        public bool IsCycling { get; set; }
        public void ExecuteCycleSuggestions(object parameter);
    }
}
