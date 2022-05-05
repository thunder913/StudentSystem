using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using StudentSystemCommon.Controls;
using StudentSystemWinForms.MVVM.View;
using StudentSystemWinForms.MVVM.ViewModel;
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


            username.DataContext = _model;
            //username.comboBox.bindin.DataBindings.Add("Items", _model.Suggestions, nameof(_model.Suggestions), false, DataSourceUpdateMode.OnPropertyChanged);

            username.Placeholder = "Потребителско име";

            username.SetBinding(SuggestTextBox.AutoSuggestProperty, new Binding()
            {
                Mode = BindingMode.TwoWay,
                Source = _model,
                Path = new PropertyPath(nameof(_model.BestSuggestionUsername))
            });

            username.SetBinding(SuggestTextBox.TextProperty, new Binding()
            {
                Mode = BindingMode.TwoWay,
                Source = _model,
                Path = new PropertyPath(nameof(_model.SuggestionEntry))
            });

            username.SetBinding(SuggestTextBox.ValueMemberProperty, new Binding()
            {
                Mode = BindingMode.TwoWay,
                Source = _model,
                Path = new PropertyPath(nameof(_model.UserKeyPair))
            });

            username.SetBinding(SuggestTextBox.ItemsProperty, new Binding()
            {
                Mode = BindingMode.TwoWay,
                Source = _model,
                Path = new PropertyPath(nameof(_model.Suggestions))
            });

            password.Placeholder = "Парола";

            password.SetBinding(SuggestTextBox.AutoSuggestProperty, new Binding()
            {
                Mode = BindingMode.TwoWay,
                Source = _model,
                Path = new PropertyPath(nameof(_model.BestSuggestionPassword))
            });

            password.SetBinding(SuggestTextBox.TextProperty, new Binding()
            {
                Mode = BindingMode.TwoWay,
                Source = _model,
                Path = new PropertyPath(nameof(_model.SuggestionEntry))
            });
            
            password.SetBinding(SuggestTextBox.ValueMemberProperty, new Binding()
            {
                Mode = BindingMode.TwoWay,
                Source = _model,
                Path = new PropertyPath(nameof(_model.PassKeyPair))
            });

            password.SetBinding(SuggestTextBox.ItemsProperty, new Binding()
            {
                Mode = BindingMode.TwoWay,
                Source = _model,
                Path = new PropertyPath(nameof(_model.Suggestions))
            });
        }
    }
}
