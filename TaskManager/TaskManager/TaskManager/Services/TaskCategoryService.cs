using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Entities;

namespace TaskManager.Services
{
    public class TaskCategoryService : ITaskCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IList<TaskCategory>> GetAll()
        {
            return await _unitOfWork.GetRepository<TaskCategory>().GetAll().ToListAsync();
        }
    }
}
