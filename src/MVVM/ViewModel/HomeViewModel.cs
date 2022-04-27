using StudentSystem.Core;
using StudentSystem.DAL;
using StudentSystem.MVVM.ViewModel.Command;
using StudentSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentSystem.MVVM.ViewModel
{
    public class HomeViewModel : ObservableObject, IViewModel
    {
        private readonly UserService _userService;
        public ICommand UpdateSettingsCommand { get; set; }

        private string _username { get; set; } = "Pesho!";

        public bool AutoComplete
        {
            get => _autoComplete;
            set
            {
                _autoComplete = value;
                OnPropertyChanged();
            }

        }

        public List<string> DateIntervalSettingsList
        {
            get => _dateIntervalSettingsList;
            set
            {
                _dateIntervalSettingsList = value;
                OnPropertyChanged();
            }
        }

        public int SuggestionCount
        {
            get => _suggestionCount;
            set
            {
                _suggestionCount = value;
                OnPropertyChanged();
            }
        }

        public int InputLengthSuggestions
        {
            get => UserInfo.CurrentUser.Settings.InputLengthThreshold;
            set
            {
                UserInfo.CurrentUser.Settings.InputLengthThreshold = value;
                OnPropertyChanged();
            }
        }

        public string SelectedDateInterval
        {
            get => _selectedDateInterval;
            set
            {
                _selectedDateInterval = value;
                OnPropertyChanged();
            }
        }
        public string Username
        {
            get => _username; set
            {
                _username = value;
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

        public HomeViewModel()
        {
            this.Username = UserInfo.CurrentUser.Username;
            AutoComplete = UserInfo.CurrentUser.Settings.AutoComplete;
            UpdateSettingsCommand = new UpdateSettingsCommand(this);
            SuggestionCount = UserInfo.CurrentUser.Settings.SuggestionsCount;
            _userService = new UserService(new StudentContext());
        }
        private IViewModel _currentViewModel;
        private IViewModel _currentViewModelParent;
        private int _suggestionCount;
        private bool _hasStatus;
        private string _statusMessage;
        private string _selectedDateInterval;
        private List<string> _dateIntervalSettingsList;
        private bool _autoComplete;

        public bool CanExecute()
        {
            return _suggestionCount >= 0;
        }

        public void Execute()
        {
            var user = UserInfo.CurrentUser;
            var settings = user.Settings;
            settings.AutoComplete = _autoComplete;
            settings.SuggestionsCount = _suggestionCount;
            _userService.UpdateUserSettings(user.UserId, settings);
            HasStatus = true;
            StatusMessage = "Настройките са запазени!";
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        public bool HasStatus
        {
            get => _hasStatus;
            set
            {
                _hasStatus = value;
                OnPropertyChanged();
            }
        }
    }
}
