using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Entities;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class UserService : BaseService,IUserService
    {
        public async Task<IList<User>> GetAll()
        {
            return await _unitOfWork.GetRepository<User>().GetAll().ToListAsync();
        }

        public async Task<IPagedList<User>> Search(SearchModel model)
        {
            return await _unitOfWork.GetRepository<User>().GetPagedListAsync();
        }
    }
}
