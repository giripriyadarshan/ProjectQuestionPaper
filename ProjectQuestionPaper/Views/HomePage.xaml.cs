using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using ProjectQuestionPaper.ViewModels;

namespace ProjectQuestionPaper.Views
{
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; }

        public HomePage()
        {
            ViewModel = Ioc.Default.GetService<HomeViewModel>();
            InitializeComponent();
        }

        private void Papers_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            _ = Frame.Navigate(typeof(ContentsPage));
        }
    }
}
