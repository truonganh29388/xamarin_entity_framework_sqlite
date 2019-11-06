using Autofac;
using TaskManager.Droid.Services;
using TaskManager.IocContainer;
using TaskManager.Services;

namespace TaskManager.Droid
{
    public class Setup : AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder cb)
        {
            cb.RegisterType<OtpService>().As<IOtpService>();
            base.RegisterDependencies(cb);
        }
    }
}