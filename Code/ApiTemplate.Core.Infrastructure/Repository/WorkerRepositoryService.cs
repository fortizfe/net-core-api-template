using ApiTemplate.Core.Domain.Models;
using ApiTemplate.Core.Infrastructure.EntityFramework.Contexts;
using System.Linq;

namespace ApiTemplate.Core.Infrastructure.Repository
{
    public interface IWorkerRepositoryService : IRepositoryService<int, Worker>
    {
        /// <summary>
        /// Obtiene un trabajador por nombre de usuario
        /// </summary>
        /// <param name="username">Nombre de usuario a buscar</param>
        /// <returns>Objeto del trabajador/></returns>
        Worker GetByUsername(string username);
    }

    public class WorkerRepositoryService : AbstractRepositoryService<int, Worker>, IWorkerRepositoryService
    {
        public WorkerRepositoryService(ApiTemplateContext context)
            : base(context)
        {
        }

        public Worker GetByUsername(string username)
        {
            return Query(w => w.Username == username).FirstOrDefault();
        }
    }
}