using Autofac;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using TaskManager.Configurations;
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
            var configuration = GetConfiguration();

            if (configuration != null)
            {
                cb.Register(c => configuration).SingleInstance();
                var httpClient = new HttpClient { BaseAddress = new Uri(configuration.ApiBaseAddress) };
                cb.RegisterInstance(httpClient).As<HttpClient>();
            }

            cb.RegisterType<Notifier>().As<INotifier>();

            // Register View Models
            cb.RegisterType<HomeViewModel>().SingleInstance();
            cb.RegisterType<LoginViewModel>().SingleInstance();
        }

        private IConfiguration GetConfiguration()
        {
            var assembly = Assembly.GetAssembly(typeof(IConfiguration));
            string[] resources = assembly.GetManifestResourceNames();

            var embeddedResourceStream = Assembly.GetAssembly(typeof(IConfiguration))
                                        .GetManifestResourceStream("TaskManager.Configurations.config.json");

            if (embeddedResourceStream == null)
                return null;

            using (var streamReader = new StreamReader(embeddedResourceStream))
            {
                var jsonString = streamReader.ReadToEnd();
                var configuration = JsonConvert.DeserializeObject<Configuration>(jsonString);

                if (configuration == null)
                    return null;


                return configuration;
            }
        }
    }
}
