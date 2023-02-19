using AutoMapper;
using HealthcareSystem.Business.Abstracts;
using HealthcareSystem.Business.Dto;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Infrastructure.Abstracts;
using HealthcareSystem.Infrastructure.Persistence;
using static System.Net.Mime.MediaTypeNames;

namespace HealthcareSystem.Business.Service
{
    public class PoliclinicDoctorsService : BaseService<PoliclinicDoctors, PoliclinicDoctorsDto>, IPoliclinicDoctorsService
    {
        private readonly IRepository<PoliclinicDoctors, BaseDbContext> _repository;
        private readonly IMapper _mapper;

        public PoliclinicDoctorsService(IRepository<PoliclinicDoctors, BaseDbContext> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}
