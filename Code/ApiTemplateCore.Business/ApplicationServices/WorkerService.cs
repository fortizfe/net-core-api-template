using ApiTemplate.Core.Business.BaseServices;
using ApiTemplate.Core.Domain.Models;
using ApiTemplate.Core.Infrastructure.Repository;
using AutoMapper;

namespace ApiTemplate.Core.Business.ApplicationServices
{
    public interface IWorkerService : ICrudService<int, Worker>
    {
    }

    public class WorkerService : CrudService<int, Worker, IWorkerRepositoryService>, IWorkerService
    {
        public WorkerService(IMapper mapper, IWorkerRepositoryService workerRepo)

            : base(mapper, workerRepo)
        {
        }
    }
}