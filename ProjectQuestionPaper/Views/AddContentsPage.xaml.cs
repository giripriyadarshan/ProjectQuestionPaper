using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using ProjectQuestionPaper.ViewModels;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjectQuestionPaper.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddContentsPage : Page
    {
        public AddContentsViewModel ViewModel { get; }

        public AddContentsPage()
        {
            ViewModel = Ioc.Default.GetService<AddContentsViewModel>();
            InitializeComponent();
        }
    }
}
