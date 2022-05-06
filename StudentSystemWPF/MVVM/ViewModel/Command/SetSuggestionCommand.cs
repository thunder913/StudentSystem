using System;
using System.Windows.Input;

namespace StudentSystem.MVVM.ViewModel.Command
{
    public class SetSuggestionCommand : ICommand
    {
        private AddStudentViewModel _viewModel;
        public SetSuggestionCommand(AddStudentViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.SetStudentSuggestion();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
