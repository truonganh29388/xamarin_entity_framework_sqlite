using Microsoft.EntityFrameworkCore;
using System.IO;
using TaskManager.Entities;

namespace TaskManager.EntityFramework.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var fileName = "taskmamanger.db";
            var dbFullPath = Path.Combine(dbFolder, fileName);
            optionsBuilder.UseSqlite($"Filename={dbFullPath}");
        }
    }
}