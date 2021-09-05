using ProjectQuestionPaper.Core.Models;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectQuestionPaper.Contracts.Services;
using static ProjectQuestionPaper.Core.Models.Miscellaneous;

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

        private string _popupmessage;
        public string PopupMessage
        {
            get => _popupmessage;
            set => SetProperty(ref _popupmessage, value);
        }

        private bool _popupitem;
        public bool PopupItem
        {
            get => _popupitem;
            set => SetProperty(ref _popupitem, value);
        }

        public void Loaded()
        {
            if (LoginSession)
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
                    LoginSession = true;
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
