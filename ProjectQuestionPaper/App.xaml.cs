using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

using ProjectQuestionPaper.Activation;
using ProjectQuestionPaper.Contracts.Services;
using ProjectQuestionPaper.Helpers;
using ProjectQuestionPaper.Services;
using ProjectQuestionPaper.ViewModels;
using ProjectQuestionPaper.Views;

// To learn more about WinUI3, see: https://docs.microsoft.com/windows/apps/winui/winui3/.
namespace ProjectQuestionPaper
{
    public partial class App : Application
    {
        public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName".GetLocalized() };

        public App()
        {
            InitializeComponent();
            UnhandledException += App_UnhandledException;
            Ioc.Default.ConfigureServices(ConfigureServices());
        }

        private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/windows/winui/api/microsoft.ui.xaml.unhandledexceptioneventargs
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);
            var activationService = Ioc.Default.GetService<IActivationService>();
            await activationService.ActivateAsync(args);
        }

        private System.IServiceProvider ConfigureServices()
        {
            // TODO WTS: Register your services, viewmodels and pages here
            var services = new ServiceCollection();

            // Default Activation Handler
            _ = services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            _ = services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            _ = services.AddTransient<INavigationViewService, NavigationViewService>();

            _ = services.AddSingleton<IActivationService, ActivationService>();
            _ = services.AddSingleton<IPageService, PageService>();
            _ = services.AddSingleton<INavigationService, NavigationService>();

            // Core Services

            // Views and ViewModels
            _ = services.AddTransient<ShellPage>();
            _ = services.AddTransient<ShellViewModel>();
            _ = services.AddTransient<HomeViewModel>();
            _ = services.AddTransient<HomePage>();
            _ = services.AddTransient<AdminViewModel>();
            _ = services.AddTransient<AdminPage>();
            _ = services.AddTransient<SettingsViewModel>();
            _ = services.AddTransient<SettingsPage>();

            _ = services.AddTransient<ContentsPage>();
            _ = services.AddTransient<ContentsViewModel>();
            _ = services.AddTransient<PostLoginPage>();
            _ = services.AddTransient<PostLoginViewModel>();
            _ = services.AddTransient<AddContentsPage>();
            _ = services.AddTransient<AddContentsViewModel>();
            return services.BuildServiceProvider();
        }
    }
}
