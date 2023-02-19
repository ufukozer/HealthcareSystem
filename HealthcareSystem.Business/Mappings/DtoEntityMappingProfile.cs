using AutoMapper;
using HealthcareSystem.Business.Dto;
using HealthcareSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Business.Mappings
{
    internal class DtoEntityMappingProfile : Profile
    {
        public DtoEntityMappingProfile()
        {
            CreateMap<Patient, PatientDto>().ReverseMap();
        }
    }
}
