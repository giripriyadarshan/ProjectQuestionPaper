using ProjectQuestionPaper.Core.Models;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectQuestionPaper.Contracts.Services;
using static ProjectQuestionPaper.Models.LoginSession;

namespace ProjectQuestionPaper.ViewModels
{
    public class AdminViewModel : ObservableObject
    {
        private INavigationService NavigationService { get; }

        public AdminViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        private string _username;
        public string UsernameInput
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string PasswordInput
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string PopupMessage { get; set; }

        public bool PopupItem { get; set; }

        public void Loaded()
        {
            if (LoginSessionState)
            {
                _ = NavigationService.Frame.Navigate(typeof(Views.PostLoginPage));
            }
        }

        public void Login()
        {
            using var context = new Context();

            var admin = context.Admins
                .FirstOrDefault(u => u.Username == UsernameInput);

            if (admin != null)
            {
                if (admin.Password == PasswordInput)
                {
                    LoginSessionState = true;
                    _ = NavigationService.Frame.Navigate(typeof(Views.PostLoginPage));
                }
                else
                {
                    if (!PopupItem)
                    {
                        PopupMessage = "Incorrect Password";
                        PopupItem = true;
                    }
                }
            }
            else
            {
                if (!PopupItem)
                {
                    PopupMessage = "Username does not exist";
                    PopupItem = true;
                }
            }
        }

    }
}
