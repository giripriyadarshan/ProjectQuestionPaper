using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Navigation;
using ProjectQuestionPaper.Contracts.Services;
using ProjectQuestionPaper.Views;
using static ProjectQuestionPaper.Core.Models.Miscellaneous;

namespace ProjectQuestionPaper.ViewModels
{
    public class ShellViewModel : ObservableRecipient
    {
        private bool _isBackEnabled;
        private object _selected;

        public INavigationService NavigationService { get; }

        public INavigationViewService NavigationViewService { get; }

        public bool IsBackEnabled
        {
            get => _isBackEnabled;
            set => SetProperty(ref _isBackEnabled, value);
        }

        public object Selected
        {
            get => _selected;
            set => SetProperty(ref _selected, value);
        }

        public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService)
        {
            NavigationService = navigationService;
            NavigationService.Navigated += OnNavigated;
            NavigationViewService = navigationViewService;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            var pageType = e.SourcePageType;

            if (pageType == typeof(SettingsPage))
            {
                Selected = NavigationViewService.SettingsItem;
                return;
            }

            var selectedItem = NavigationViewService.GetSelectedItem(pageType);
            if (selectedItem != null)
            {
                Selected = selectedItem;
            }

            if (pageType == typeof(HomePage))
            {
                NavigationService.Frame.BackStack.Clear();
            }
            else if (pageType == typeof(AdminPage) && !LoginSession)
            {
                if (NavigationService.Frame.BackStack[NavigationService.Frame.BackStackDepth - 1].SourcePageType == typeof(PostLoginPage))
                {
                    NavigationService.Frame.BackStack.RemoveAt(NavigationService.Frame.BackStackDepth - 1);
                }
            }

            IsBackEnabled = NavigationService.CanGoBack;
        }
    }
}
