using HealthcareSystem.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public Patient? Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Hospital Hospital { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}
