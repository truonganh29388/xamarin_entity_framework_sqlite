using System.Threading.Tasks;

namespace TaskManager.Database
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
