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
            if(!await _context.Users.AnyAsync())
            {
                var users = new List<User>
                {
                    new User
                    {
                        FullName = "John Doe",
                        UserName = "johndoe@email.com",
                        Password = "Password!!"
                    },
                     new User
                    {
                        FullName = "John Doe 2",
                        UserName = "johndoe2@email.com",
                        Password = "Password!!"
                    },
                      new User
                    {
                        FullName = "John Doe 3",
                        UserName = "johndoe3@email.com",
                        Password = "Password!!"
                    },
                       new User
                    {
                        FullName = "John Doe 4",
                        UserName = "johndoe4@email.com",
                        Password = "Password!!"
                    }
                };
                await _context.Users.AddRangeAsync(users);
                await _context.SaveChangesAsync();
            }
        }
    }
}
