using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Business.Dto
{
    public class PoliclinicDto : BaseDto
    {
        public string Name { get; set; }
        public ICollection<DoctorDto> Doctors { get; set; }
    }
}
