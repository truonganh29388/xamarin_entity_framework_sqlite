using System.Collections.Generic;
using TaskManager.Entities;
using TaskManager.Services;

namespace TaskManager.ViewModels
{
    public class HomeViewModel : IViewModel
    {
        private IUserService _userService;
        public HomeViewModel(IUserService userService)
        {
            Users = userService.GetAll().ConfigureAwait(true).GetAwaiter().GetResult();
        }

        public IList<User> Users { get; set; }
    }
}
