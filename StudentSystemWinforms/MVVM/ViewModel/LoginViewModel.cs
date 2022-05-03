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
        private string _username;
        private string _password;
        private UserService _userService;
        private List<UserLoginSuggestion> loginSuggestions { get; set; } = new List<UserLoginSuggestion>();
        private SuggestionFileManager _suggestionFileManager;
        public AutoCompleteStringCollection AutoCompleteCollection { get; set; }
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Username)));
            }

        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Password)));
            }
        }
        public LoginViewModel()
        {
            _suggestionFileManager = new SuggestionFileManager();
            AutoCompleteCollection = new AutoCompleteStringCollection();
            loginSuggestions = _suggestionFileManager.GetLoginSuggestions();
            AutoCompleteCollection.AddRange(loginSuggestions.Select(x => x.Username).ToArray());
            _userService = new UserService(new StudentContext());
        }

        public void Login(Action redirect)
        {
            if (_userService.Login(Username, Password))
            {
                _suggestionFileManager.AddLoginSuggestion(new UserLoginSuggestion(Username, Password));
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
                _userService.Register(Username, Password);
                MessageBox.Show("Успешно се регистрирахте!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }


        internal void HandleKeyPressed(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (AutoCompleteCollection.Contains(textBox.Text))
            {
                var suggestion = loginSuggestions.FirstOrDefault(x => x.Username == textBox.Text);
                Username = textBox.Text;
                Password = suggestion.Password;
            }
        }
    }
}
