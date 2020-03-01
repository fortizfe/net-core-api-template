using AutoMapper;
using ApiTemplate.Core.Domain.Interfaces;
using ApiTemplate.Core.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTemplate.Core.Business.BaseServices
{
    public interface ICrudService<TKey, TModel>
        where TModel : IDomainEntity<TKey>
    {
        IEnumerable<TDto> GetAll<TDto>();

        TDto Get<TDto>(TKey id);

        Task<TKey> Create<TDto>(TDto dto);

        void Update<TDto>(TKey id, TDto dto);

        void Delete(TKey id);
    }

    public abstract class CrudService<TKey, TModel, TRepoService> : ICrudService<TKey, TModel>
        where TModel : IDomainEntity<TKey>
        where TRepoService : IRepositoryService<TKey, TModel>

    {
        protected readonly IMapper _mapper;

        protected readonly TRepoService _repoSvc;

        protected CrudService(IMapper mapper, TRepoService repoSvc)
        {
            _mapper = mapper;
            _repoSvc = repoSvc;
        }

        public virtual IEnumerable<TDto> GetAll<TDto>()
        {
            return _mapper.Map<IEnumerable<TDto>>(_repoSvc.Query());
        }

        public virtual TDto Get<TDto>(TKey id)
        {
            return _mapper.Map<TDto>(_repoSvc.GetById(id));
        }

        public virtual async Task<TKey> Create<TDto>(TDto dto)
        {
            var createdId = await _repoSvc.AddAsync(_mapper.Map<TModel>(dto));
            return createdId;
        }

        public virtual void Update<TDto>(TKey id, TDto dto)
        {
            var areaUpdated = _repoSvc.GetById(id);
            _mapper.Map<TDto, IDomainEntity<TKey>>(dto, areaUpdated);
            _repoSvc.Update(areaUpdated);
        }

        public virtual void Delete(TKey id)
        {
            var modelDeleted = _repoSvc.GetById(id);
            _repoSvc.Delete(modelDeleted);
        }
    }
}