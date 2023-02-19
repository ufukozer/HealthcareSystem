using HealthcareSystem.Business.Results;

namespace HealthcareSystem.Business.Abstracts.Base
{
    public interface IBaseService<TDto>
    {
        Task<List<TDto>> Getlist();
        Task<TDto> GetById(Guid id);
        Task<GenericServiceResult<TDto>> Add(TDto model);
        Task<TDto> Update(TDto model);
        Task<TDto> Delete(Guid id);
    }
}
