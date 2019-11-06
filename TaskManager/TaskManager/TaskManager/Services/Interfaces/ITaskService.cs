using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Entities;
using TaskManager.Models;

namespace TaskManager.Services
{
   public interface ITaskService
    {
        Task<IList<TaskToDo>> GetAll();
        Task<IPagedList<TaskToDo>> Search(SearchModel model);
        Task Create(TaskToDo entity);
        Task Update(TaskToDo entity);
        Task Delete(string id);
    }
}
