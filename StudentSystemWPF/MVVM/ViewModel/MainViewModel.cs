using StudentSystemCommon.Core;
using StudentSystem.MVVM.ViewModel.Command;
using System.Collections.Generic;
using System.Windows.Input;

namespace StudentSystem.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject, IViewModelSuggestions
    {
        #region PrivateProperties
        private IViewModel _currentViewModel;

        private IViewModel _currentViewModelParent;
        private KeyValuePair<object, string> _itemKeyPair;
        #endregion
        #region PublicProperties
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
        #endregion
        public MainViewModel()
        {
            HomeCommand = new NavigationCommand<HomeViewModel>(this);
            SearchStudentCommand = new NavigationCommand<SearchStudentViewModel>(this);
            AddStudentCommand = new NavigationCommand<AddStudentViewModel>(this);
            CycleSuggestionCommand = new CycleSuggestionCommand(this);
            CurrentViewModel = new HomeViewModel();
        }
        #region Methods
        public void ExecuteCycleSuggestions(object parameter)
        {
        }
        #endregion
    }
}
