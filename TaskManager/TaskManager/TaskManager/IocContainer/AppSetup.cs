using Autofac;
using Microsoft.EntityFrameworkCore;
using TaskManager.Database;
using TaskManager.Services;
using TaskManager.ViewModels;

namespace TaskManager.IocContainer
{
    public class AppSetup
    {
        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            RegisterDependencies(containerBuilder);
            return containerBuilder.Build();
        }

        protected virtual void RegisterDependencies(ContainerBuilder cb)
        {
            cb.RegisterType<ApplicationContext>();
            cb.RegisterType<UnitOfWork<ApplicationContext>>().As<IUnitOfWork>();
            cb.RegisterType<DatabaseInitializer>().As<IDatabaseInitializer>();
            cb.RegisterType<UserService>().As<IUserService>();

            // Register View Models
            cb.RegisterType<HomeViewModel>().SingleInstance();
        }
    }
}
