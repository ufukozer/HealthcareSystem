using HealthcareSystem.Domain.BaseEntities;

namespace HealthcareSystem.Domain.Entities
{
    public class Hospital : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<HospitalPoliclinics> HospitalPoliclinics { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}