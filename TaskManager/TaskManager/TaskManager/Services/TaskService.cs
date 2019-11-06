using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Entities;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(TaskToDo entity)
        {
            await _unitOfWork.GetRepository<TaskToDo>().InsertAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            _unitOfWork.GetRepository<TaskToDo>().Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IList<TaskToDo>> GetAll()
        {
            return await _unitOfWork.GetRepository<TaskToDo>().GetAll().ToListAsync();
        }

        public async Task<IPagedList<TaskToDo>> Search(SearchModel model)
        {
            Expression<Func<TaskToDo, bool>> predicate = null;
            if (!string.IsNullOrWhiteSpace(model.SearchContent))
            {
                Func<TaskToDo, bool> func = x => x.Name.Contains(model.SearchContent);
                predicate = x => func(x);
            };

            return await _unitOfWork.GetRepository<TaskToDo>().GetPagedListAsync(
                predicate:predicate,
                include: x => x.Include(y => y.Category),
                pageIndex: model.PageIndex,
                pageSize: model.PageSize,
                orderBy: x => x.OrderBy(y => y.ExpectedFinishedTime)
                );
        }

        public async Task Update(TaskToDo entity)
        {
            _unitOfWork.GetRepository<TaskToDo>().Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
