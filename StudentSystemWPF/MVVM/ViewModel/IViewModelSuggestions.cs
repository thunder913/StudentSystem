using System.Windows.Input;

namespace StudentSystem.MVVM.ViewModel
{
    public interface IViewModelSuggestions : IViewModel
    {
        public ICommand CycleSuggestionCommand { get; set; }
        public int SuggestionIndex { get; set; }
        public bool IsCycling { get; set; }
        public void ExecuteCycleSuggestions(object parameter);
    }
}
