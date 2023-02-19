using AutoMapper;
using HealthcareSystem.Business.Abstracts;
using HealthcareSystem.Business.Dto;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Infrastructure.Abstracts;
using HealthcareSystem.Infrastructure.Persistence;
using static System.Net.Mime.MediaTypeNames;

namespace HealthcareSystem.Business.Service
{
    public class DoctorService : BaseService<Doctor, DoctorDto>, IDoctorService
    {
        private readonly IRepository<Doctor, BaseDbContext> _repository;
        private readonly IMapper _mapper;

        public DoctorService(IRepository<Doctor, BaseDbContext> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}
