using System;
using System.Windows.Input;

namespace StudentSystemWinForms.MVVM.ViewModel.Command
{
    public class CycleSuggestionCommand : ICommand
    {
        private readonly IViewModelSuggestions _viewModel;
        public CycleSuggestionCommand(IViewModelSuggestions viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.ExecuteCycleSuggestions(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}