using AutoMapper;
using HealthcareSystem.Business.Abstracts.Base;
using HealthcareSystem.Business.Results;
using HealthcareSystem.Domain.Abstracts;
using HealthcareSystem.Infrastructure.Abstracts;
using HealthcareSystem.Infrastructure.Persistence;

namespace HealthcareSystem.Business.Service
{
    public abstract class Service<T>
    {
        public GenericServiceResult<T> ServiceResult(T data, string message = "OK", bool isSuccess = true)
        {
            var result = new GenericServiceResult<T>
            {
                Data = data,
                Message = message,
                IsSuccess = isSuccess
            };
            return result;
        }
    }

    public abstract class BaseService<TEntity, TDto> : Service<TDto>, IBaseService<TDto> where TEntity : class, IBaseEntity, new()
    {
        private readonly IRepository<TEntity, BaseDbContext> _repository;
        private readonly IMapper _mapper;
        public BaseService(IRepository<TEntity, BaseDbContext> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GenericServiceResult<TDto>> Add(TDto model)
        {
            var mapped = _mapper.Map<TEntity>(model);
            var ent = await _repository.Add(mapped);
            return ServiceResult(_mapper.Map<TDto>(ent));
            // return _mapper.Map<TDto>(ent);

        }

        public async Task<TDto> Delete(Guid id)
        {
            //var mapped = _mapper.Map<TEntity>(model);
            var ent = await _repository.Delete(id);
            return _mapper.Map<TDto>(ent);
        }

        public async Task<TDto> GetById(Guid id)
        {
            var ent = await _repository.GetAsync(k => k.Id == id);
            return _mapper.Map<TDto>(ent);
        }

        public async Task<List<TDto>> Getlist()
        {
            var result = await _repository.GetListAsync();
            return _mapper.Map<List<TDto>>(result);
        }

        public async Task<TDto> Update(TDto model)
        {
            var mapped = _mapper.Map<TEntity>(model);
            var ent = await _repository.Update(mapped);
            return _mapper.Map<TDto>(ent);

        }


    }

}
