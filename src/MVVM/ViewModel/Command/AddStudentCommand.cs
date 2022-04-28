using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentSystem.MVVM.ViewModel.Command
{
    internal class AddStudentCommand : ICommand
    {
        private AddStudentViewModel _viewModel;
        public AddStudentCommand(AddStudentViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.CanExecute();
        }

        public void Execute(object parameter)
        {
            _viewModel.AddStudent();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
