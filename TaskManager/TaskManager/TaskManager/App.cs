using TaskManager.IocContainer;
using TaskManager.Pages;
using Xamarin.Forms;

namespace TaskManager
{
    public class App : Application
    {
        public App(AppSetup setup)
        {
            AppContainer.Container = setup.CreateContainer();
            StartupConfig.EnsureDbCreated().ConfigureAwait(true).GetAwaiter().GetResult();
            StartupConfig.SeedDb().ConfigureAwait(true).GetAwaiter().GetResult();
            MainPage = new NavigationPage(new HomePage());

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
