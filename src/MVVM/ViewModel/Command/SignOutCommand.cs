using StudentSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentSystem.MVVM.ViewModel.Command
{
    internal class SignOutCommand : ICommand
    {
        private MainViewModel _viewModel;
        public SignOutCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }        

        public bool CanExecute(object parameter)
        {
            return UserInfo.CurrentUser is not null;
        }

        public void Execute(object parameter)
        {
            _viewModel.SignOut();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
