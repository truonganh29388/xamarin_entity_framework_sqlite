using Autofac;
using TaskManager.IocContainer;
using TaskManager.ViewModels;
using Xamarin.Forms;

namespace TaskManager.Pages
{
    public class ViewPage<T> : ContentPage where T : IViewModel
    {
        public T ViewModel { get; private set; }

        public ViewPage()
        {
            using (var scope = AppContainer.Container.BeginLifetimeScope())
            {
                ViewModel = AppContainer.Container.Resolve<T>();
            }
            BindingContext = ViewModel;
        }
    }
}
