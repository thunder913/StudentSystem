using StudentSystemWinForms.Core;
using StudentSystemCommon.DAL;
using StudentSystemCommon.Utils;

namespace StudentSystemWinForms.MVVM.ViewModel
{
    public class HomeViewModel : ObservableObject
    {
        #region PrivateProperties
        private int _suggestionCount;
        private readonly UserService _userService;
        public int SuggestionCount
        {
            get => _suggestionCount;
            set
            {
                _suggestionCount = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public HomeViewModel()
        {
            _userService = new UserService(new StudentContext());
            SuggestionCount = UserInfo.CurrentUser.Settings.SuggestionsCount;
        }
        #region Methods
        public void ButtonClicked()
        {
            var user = UserInfo.CurrentUser;
            var settings = user.Settings;
            settings.SuggestionsCount = _suggestionCount;
            if(_userService.UpdateUserSettings(user.UserId, settings))
            UserInfo.CurrentUser.Settings = settings;
        }
        #endregion
    }
}
