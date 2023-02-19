using HealthcareSystem.Domain.BaseEntities;


namespace HealthcareSystem.Domain.Entities
{
    public class Policlinic : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
