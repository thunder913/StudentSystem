using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentSystem.MVVM.ViewModel.Command
{
    internal class SearchCommand : ICommand
    {
        private SearchStudentViewModel _viewModel;
        public SearchCommand(SearchStudentViewModel viewmodel)
        {
            this._viewModel = viewmodel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.Search();
        }
    }
}
