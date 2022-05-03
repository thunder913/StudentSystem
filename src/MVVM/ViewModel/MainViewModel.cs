using StudentSystemCommon.Core;
using StudentSystem.MVVM.ViewModel.Command;
using System.Collections.Generic;
using System.Windows.Input;

namespace StudentSystem.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject, IViewModelSuggestions
    {
        private IViewModel _currentViewModel;

        private IViewModel _currentViewModelParent;
        private KeyValuePair<object, string> _itemKeyPair;

        public ICommand HomeCommand { get; set; }
        public ICommand AddStudentCommand { get; set; }
        public ICommand SearchStudentCommand { get; set; }
        public ICommand CycleSuggestionCommand { get; set; }
        public int SuggestionIndex { get; set; } = -1;
        public bool IsCycling { get; set; }

        public KeyValuePair<object, string> ItemKeyPair
        {
            get => _itemKeyPair;
            set
            {
                _itemKeyPair = value;
                OnPropertyChanged();
            }
        }
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
        public MainViewModel()
        {
            HomeCommand = new NavigationCommand<HomeViewModel>(this);
            SearchStudentCommand = new NavigationCommand<SearchStudentViewModel>(this);
            AddStudentCommand = new NavigationCommand<AddStudentViewModel>(this);
            CycleSuggestionCommand = new CycleSuggestionCommand(this);
            CurrentViewModel = new HomeViewModel();
        }

        public void ExecuteCycleSuggestions(object parameter)
        {
        }

        //public void SignOut()
        //{
        //    UserInfo.CurrentUser = null;
        //    CurrentViewModel = new LoginViewModel();
        //}
    }
}
