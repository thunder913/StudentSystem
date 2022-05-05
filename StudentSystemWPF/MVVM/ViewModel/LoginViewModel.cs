using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using StudentSystemCommon.Core;
using StudentSystemCommon.DAL;
using StudentSystemCommon.MVVM.Model;
using StudentSystem.MVVM.ViewModel.Command;
using StudentSystemCommon.Utils;
using System;

namespace StudentSystem.MVVM.ViewModel
{
    public class LoginViewModel : ObservableObject, IViewModelSuggestions
    {
        private UserService _userService;
        private IViewModel _currentViewModel;
        private IViewModel _currentViewModelParent;
        private List<UserLoginSuggestion> _suggestions;
        private List<UserLoginSuggestion> _allSuggestions;
        private readonly SuggestionFileManager _suggestionFileManager;
        private KeyValuePair<object, string> _userKeyPair;
        private KeyValuePair<object, string> _passKeyPair;
        private UserLoginSuggestion _suggestionEntry;
        private string _bestSuggestionUsername;
        private string _bestSuggestionPassword;

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public KeyValuePair<object, string> UserKeyPair
        {
            get => _userKeyPair;
            set
            {
                _userKeyPair = value;
                OnPropertyChanged();
            }
        }
        public KeyValuePair<object, string> PassKeyPair
        {
            get => _passKeyPair;
            set
            {
                _passKeyPair = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel()
        {
            _suggestionFileManager = new SuggestionFileManager();
            _allSuggestions = _suggestionFileManager.GetLoginSuggestions();
            SuggestionEntry = new UserLoginSuggestion();
            UserKeyPair =
                new KeyValuePair<object, string>(_suggestionEntry, "Username");
            PassKeyPair =
                new KeyValuePair<object, string>(_suggestionEntry, "Password");
            CurrentViewModelParent = this;
            CurrentViewModel = null;
            LoginCommand = new LoginCommand(this);
            RegisterCommand = new RegisterCommand(this);
            _userService = new UserService(new StudentContext());
        }

        public bool CanExecute()
        {
            return SuggestionEntry != null
                   && !string.IsNullOrEmpty(SuggestionEntry.Username) 
                   && !string.IsNullOrEmpty(SuggestionEntry.Password);
        }
        public void Login(object parameter)
        {
            if (_userService.Login(SuggestionEntry.Username, SuggestionEntry.Password))
            {
                _suggestionFileManager.AddLoginSuggestion(new UserLoginSuggestion(SuggestionEntry.Username, SuggestionEntry.Password));
                CurrentViewModelParent = new MainViewModel();
            }
            else
            {
                MessageBox.Show("Невалидно потребителско име или парола!", "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Register(object parameter)
        {
            try
            {
                _userService.Register(SuggestionEntry.Username, SuggestionEntry.Password);
                MessageBox.Show("Успешно се регистрирахте!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
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

        public ICommand CycleSuggestionCommand { get; set; }
        public int SuggestionIndex { get; set; }
        public bool IsCycling { get; set; }
        public void ExecuteCycleSuggestions(object parameter)
        {
        }

        public UserLoginSuggestion SuggestionEntry
        {
            get => _suggestionEntry;
            set
            {
                _suggestionEntry = value;
                if (_suggestionEntry != null)
                {
                    if (_suggestionEntry.Username != null)
                        Suggestions = _allSuggestions.Where(s => s.Username.ToLower().Contains(_suggestionEntry.Username.ToLower())).ToList();
                    if (_suggestionEntry.Password != null)
                        Suggestions = _allSuggestions.Where(s => s.Password.ToLower().Contains(_suggestionEntry.Password.ToLower())).ToList();
                }
                
                OnPropertyChanged();
            }
        }

        public List<UserLoginSuggestion> Suggestions
        {
            get => _suggestions;
            set
            {
                _suggestions = value;
                OnPropertyChanged();
                if (!_suggestions.Any())
                {
                    BestSuggestionUsername = null;
                    BestSuggestionPassword = null;
                    return;
                }
                var first = _suggestions.First();
                var inputLengthThreshold =
                    UserInfo.CurrentUser == null ? 1 : UserInfo.CurrentUser.Settings.InputLengthThreshold;
                BestSuggestionUsername = SuggestionEntry?.Username?.Length >= inputLengthThreshold ? first.Username : string.Empty;
                BestSuggestionPassword = SuggestionEntry?.Password?.Length >= inputLengthThreshold ? first.Password : string.Empty;
            }
        }

        public string BestSuggestionPassword
        {
            get => _bestSuggestionPassword;
            set
            {
                _bestSuggestionPassword = value;
                OnPropertyChanged();
            }
        }

        public string BestSuggestionUsername
        {
            get => _bestSuggestionUsername;
            set
            {
                _bestSuggestionUsername = value;
                OnPropertyChanged();
            }
        }
    }
}
