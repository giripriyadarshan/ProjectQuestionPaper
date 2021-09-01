using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using ProjectQuestionPaper.ViewModels;
using ProjectQuestionPaper.Core.Models;
using System.Linq;

namespace ProjectQuestionPaper.Views
{
    public sealed partial class AdminPage : Page
    {
        public AdminViewModel ViewModel { get; }

        public AdminPage()
        {
            ViewModel = Ioc.Default.GetService<AdminViewModel>();
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            using var context = new Context();

            if (context.Admins
                .Where(u => u.Username == UsernameInput.Text.Trim())
                .Where(p => p.Password == PasswordInput.Password)
                .Any())
            {
                // set login session
                _ = Frame.Navigate(typeof(PostLoginPage));
            }
            else
            {
                if (!PopupItem.IsOpen)
                {
                    PopupItem.IsOpen = true;
                }
            }
        }
    }

}
