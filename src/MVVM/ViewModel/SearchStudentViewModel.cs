using StudentSystem.Core;
using StudentSystem.MVVM.Model;
using StudentSystem.MVVM.Model.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.MVVM.ViewModel
{
    internal class SearchStudentViewModel : ObservableObject, IViewModel
    {
        private IViewModel _currentViewModel;
        private IViewModel _currentViewModelParent;
        public Student Student { get; set; }
        public ObservableCollection<StudentSearchResult> StudentsResults { get; set; } = new ObservableCollection<StudentSearchResult>() { new StudentSearchResult();
        public IViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public IViewModel CurrentViewModelParent
        {
            get => _currentViewModelParent;
            set
            {
                _currentViewModelParent = value;
                OnPropertyChanged();
            }
        }
    }
}
