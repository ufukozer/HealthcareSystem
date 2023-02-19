using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Business.Dto
{
    public class HospitalPoliclinicsDto : BaseDto
    {
        public HospitalDto Hospital { get; set; }
        public PoliclinicDto Policlinic { get; set; }
    }
}
