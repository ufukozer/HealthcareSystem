using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Business.Dto
{
    public class AppointmentDto : BaseDto
    {
        public PatientDto? Patient { get; set; }
        public DoctorDto Doctor { get; set; }
        public HospitalDto Hospital { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}
