using Autofac;
using Microsoft.EntityFrameworkCore;
using TaskManager.IocContainer;

namespace TaskManager.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public BaseService()
        {
            using (var scope = AppContainer.Container.BeginLifetimeScope())
            {
                _unitOfWork = AppContainer.Container.Resolve<IUnitOfWork>();
            }
        }
    }
}
