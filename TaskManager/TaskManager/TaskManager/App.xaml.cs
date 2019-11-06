using TaskManager.IocContainer;
using TaskManager.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TaskManager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }
        public App(AppSetup setup)
        {
            AppContainer.Container = setup.CreateContainer();
            //  StartupConfig.EnsureDbCreated().ConfigureAwait(true).GetAwaiter().GetResult();
            //   StartupConfig.SeedDb().ConfigureAwait(true).GetAwaiter().GetResult();
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
