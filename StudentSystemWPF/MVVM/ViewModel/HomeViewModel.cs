using StudentSystemCommon.Core;
using StudentSystemCommon.DAL;
using StudentSystem.MVVM.ViewModel.Command;
using StudentSystemCommon.Utils;
using System.Collections.Generic;
using System.Windows.Input;

namespace StudentSystem.MVVM.ViewModel
{
    public class HomeViewModel : ObservableObject, IViewModel
    {
        #region PrivateProperties
        private IViewModel _currentViewModel;
        private IViewModel _currentViewModelParent;
        private int _suggestionCount;
        private bool _hasStatus;
        private string _statusMessage;
        private string _selectedDateInterval;
        private List<string> _dateIntervalSettingsList;
        private readonly UserService _userService;
        private string _username { get; set; } = "Pesho!";
        #endregion
        #region PublicProperties
        public ICommand UpdateSettingsCommand { get; set; }
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
        #endregion
        public HomeViewModel()
        {
            this.Username = UserInfo.CurrentUser.Username;
            UpdateSettingsCommand = new UpdateSettingsCommand(this);
            SuggestionCount = UserInfo.CurrentUser.Settings.SuggestionsCount;
            _userService = new UserService(new StudentContext());
        }

        #region Methods
        public bool CanExecute()
        {
            return _suggestionCount >= 0;
        }

        public void Execute()
        {
            var user = UserInfo.CurrentUser;
            var settings = user.Settings;
            settings.SuggestionsCount = _suggestionCount;
            _userService.UpdateUserSettings(user.UserId, settings);
        }
        #endregion
    }
}
