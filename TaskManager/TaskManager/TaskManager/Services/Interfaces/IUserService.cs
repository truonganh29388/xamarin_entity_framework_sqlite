using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Entities;
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface IUserService
    {
        Task<IList<User>> GetAll();
        Task<IPagedList<User>> Search(SearchModel model);
    }
}
