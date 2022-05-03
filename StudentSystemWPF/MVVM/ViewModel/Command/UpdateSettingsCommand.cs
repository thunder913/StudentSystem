using System;
using System.Windows.Input;

namespace StudentSystem.MVVM.ViewModel.Command
{
    public class UpdateSettingsCommand : ICommand
    {
        private HomeViewModel _viewModel;
        public UpdateSettingsCommand(HomeViewModel homeViewModel)
        {
            _viewModel = homeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.CanExecute();
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.Execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}