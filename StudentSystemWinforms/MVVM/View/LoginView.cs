using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using StudentSystemCommon.Controls;
using StudentSystemWinForms.MVVM.View;
using StudentSystemWinForms.MVVM.ViewModel;
using StudentSystemWinForms.Utils;

namespace StudentSystemWinForms.Views
{
    public sealed partial class LoginView : ViewBase
    {
        private LoginViewModel _model;
        public LoginView(LoginViewModel model = null)
        {
            if (model != null)
            {
                _model = model;
            }
            else
            {
                _model = new LoginViewModel();
            }

            InitializeComponent();
            PerformBinding();
        }
        public sealed override void PerformBinding()
        {

            loginButton.Click += (sender, e) => _model.Login(() => (this.Parent as Main).SwapView(new MainView()));
            registerButton.Click += (sender, e) => _model.Register();

            var username = (usernameSuggestionBox.Child as SuggestTextBox);
            var password = (passwordSuggestionBox.Child as SuggestTextBox);

            SuggestionBoxBinderHelper.BindPropertiesToSuggestionBox(username, _model, "Потребителско име", nameof(_model.BestSuggestionUsername),
                nameof(_model.SuggestionEntry), nameof(_model.UserKeyPair), nameof(_model.Suggestions));

            SuggestionBoxBinderHelper.BindPropertiesToSuggestionBox(password, _model, "Парола", nameof(_model.BestSuggestionPassword),
                nameof(_model.SuggestionEntry), nameof(_model.PassKeyPair), nameof(_model.Suggestions));

        }
    }
}
