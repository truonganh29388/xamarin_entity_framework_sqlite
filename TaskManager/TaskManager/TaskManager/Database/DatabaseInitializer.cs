using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;

namespace TaskManager.Database
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationContext _context;
        public DatabaseInitializer(ApplicationContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            #region seed Task Categories

            if (!await _context.Categories.AnyAsync())
            {
                var categories = new List<TaskCategory>
                {
                    new TaskCategory
                    {
                        Name = "Call"
                    },
                    new TaskCategory
                    {
                        Name = "Email"
                    },
                     new TaskCategory
                    {
                        Name = "Do"
                    },
                };
                await _context.Categories.AddRangeAsync(categories);
                await _context.SaveChangesAsync();
            }

            #endregion
        }
    }
}
