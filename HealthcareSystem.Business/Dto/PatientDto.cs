using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Business.Dto
{
    public class PatientDto : BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public string MedicalHistory { get; set; }
    }
}
