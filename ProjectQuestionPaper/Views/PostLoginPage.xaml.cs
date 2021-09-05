using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using ProjectQuestionPaper.ViewModels;
using static ProjectQuestionPaper.Models.LoginSession;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjectQuestionPaper.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PostLoginPage : Page
    {
        public PostLoginViewModel ViewModel { get; set; }

        public PostLoginPage()
        {
            ViewModel = Ioc.Default.GetService<PostLoginViewModel>();
            InitializeComponent();
        }

        private void AddPapers_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            _ = Frame.Navigate(typeof(AddContentsPage));
        }

        private void GoBack_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            LoginSessionState = false;
            _ = Frame.Navigate(typeof(AdminPage));
        }

        private void DeletePapers_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
