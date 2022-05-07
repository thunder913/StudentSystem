using StudentSystemCommon.DAL;
using StudentSystemWinForms.Models;
using StudentSystemCommon.MVVM.Model;
using StudentSystemCommon.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace StudentSystemWinForms.MVVM.ViewModel
{
    public sealed class LoginViewModel : ViewModelBase
    {
        #region PrivateProperties
        private UserService _userService;
        private List<UserLoginSuggestion> _suggestions = new List<UserLoginSuggestion>();
        private List<UserLoginSuggestion> _allSuggestions;
        private readonly SuggestionFileManager _suggestionFileManager;
        private KeyValuePair<object, string> _userKeyPair;
        private KeyValuePair<object, string> _passKeyPair;
        private UserLoginSuggestion _suggestionEntry;
        private string _bestSuggestionUsername;
        private string _bestSuggestionPassword;
        #endregion
        #region PublicProperties
        public UserLoginSuggestion SuggestionEntry
        {
            get => _suggestionEntry;
            set
            {
                _suggestionEntry = value;
                if (_suggestionEntry != null)
                {
                    if (_suggestionEntry.Password != null)
                        Suggestions = _allSuggestions.Where(s => s.Password.ToLower().Contains(_suggestionEntry.Password.ToLower())).ToList();
                    if (_suggestionEntry.Username != null)
                        Suggestions = _allSuggestions.Where(s => s.Username.ToLower().Contains(_suggestionEntry.Username.ToLower())).ToList();
                    if (_allSuggestions.Any(x => x.Username == _suggestionEntry.Username && x.Password == _suggestionEntry.Password))
                    {
                        BestSuggestionUsername = _suggestionEntry.Username;
                        BestSuggestionPassword = _suggestionEntry.Password;
                    }
                }

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SuggestionEntry)));
            }
        }
        public List<UserLoginSuggestion> Suggestions
        {
            get => _suggestions;
            set
            {
                _suggestions = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Suggestions)));
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
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(BestSuggestionPassword)));
            }
        }

        public string BestSuggestionUsername
        {
            get => _bestSuggestionUsername;
            set
            {
                _bestSuggestionUsername = value;
                 OnPropertyChanged(new PropertyChangedEventArgs(nameof(BestSuggestionUsername)));
            }
        }

        public KeyValuePair<object, string> UserKeyPair
        {
            get => _userKeyPair;
            set
            {
                _userKeyPair = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(UserKeyPair)));
            }
        }
        public KeyValuePair<object, string> PassKeyPair
        {
            get => _passKeyPair;
            set
            {
                _passKeyPair = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(PassKeyPair)));
            }
        }
        #endregion
        public LoginViewModel()
        {
            _suggestionFileManager = new SuggestionFileManager();
            _allSuggestions = _suggestionFileManager.GetLoginSuggestions();
            SuggestionEntry = new UserLoginSuggestion();
            UserKeyPair =
                new KeyValuePair<object, string>(_suggestionEntry, "Username");
            PassKeyPair =
                new KeyValuePair<object, string>(_suggestionEntry, "Password");
            _userService = new UserService(new StudentContext());
        }
        #region Methods
        public void Login(Action redirect)
        {
            if (_userService.Login(SuggestionEntry.Username, SuggestionEntry.Password))
            {
                _suggestionFileManager.AddLoginSuggestion(new UserLoginSuggestion(SuggestionEntry.Username, SuggestionEntry.Password));
                redirect.Invoke();
            }
            else
            {
                MessageBox.Show("Невалидно потребителско име или парола!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Register()
        {
            try
            {
                _userService.Register(SuggestionEntry.Username, SuggestionEntry.Password);
                MessageBox.Show("Успешно се регистрирахте!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
