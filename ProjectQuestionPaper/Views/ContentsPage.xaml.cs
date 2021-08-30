using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using ProjectQuestionPaper.ViewModels;
using ProjectQuestionPaper.Core.Models;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectQuestionPaper.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContentsPage : Page
    {
        public ContentsViewModel ViewModel { get; }
        private readonly ObservableCollection<MenuItem> TreeViewDataSource;

        public ContentsPage()
        {
            ViewModel = Ioc.Default.GetService<ContentsViewModel>();
            InitializeComponent();

            var pageData = new ContentsItems();
            pageData.GetTreeViewControl();
            TreeViewDataSource = pageData.TreeViewControl;
            pageData.GetListBoxControl();
            FilesList.ItemsSource = pageData.ListBoxControl.ItemsSource;
        }
    }
}