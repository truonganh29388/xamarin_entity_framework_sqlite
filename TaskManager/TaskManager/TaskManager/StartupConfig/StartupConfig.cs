using System.Threading.Tasks;
using TaskManager.Database;
using Microsoft.EntityFrameworkCore;
using TaskManager.IocContainer;
using Autofac;

namespace TaskManager
{
    public static class StartupConfig
    {
        public static async Task EnsureDbCreated()
        {
            var db = AppContainer.Container.Resolve<ApplicationContext>();
            await db.Database.MigrateAsync();
            await db.Database.EnsureCreatedAsync();
        }

        public static async Task SeedDb()
        {
            var dbInitializer = AppContainer.Container.Resolve<IDatabaseInitializer>();
            await dbInitializer.SeedAsync();
        }
    }
}
