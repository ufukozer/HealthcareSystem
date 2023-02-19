using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Business.Dto
{
    public class HospitalDto : BaseDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<HospitalPoliclinicsDto> HospitalPoliclinics { get; set; }
        public ICollection<DoctorDto> Doctors { get; set; }
    }
}
