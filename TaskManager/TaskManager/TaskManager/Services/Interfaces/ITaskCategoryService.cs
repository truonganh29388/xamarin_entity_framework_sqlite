using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Entities;

namespace TaskManager.Services
{
   public interface ITaskCategoryService
    {
        Task<IList<TaskCategory>> GetAll();
    }
}
