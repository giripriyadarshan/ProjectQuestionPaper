using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using ProjectQuestionPaper.ViewModels;

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
    }
}
