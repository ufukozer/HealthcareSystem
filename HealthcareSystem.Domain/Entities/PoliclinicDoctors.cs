using HealthcareSystem.Domain.BaseEntities;


namespace HealthcareSystem.Domain.Entities
{
    public class PoliclinicDoctors : BaseEntity
    {
        public Policlinic Policlinic { get; set; }
        public Doctor Doctor { get; set; }
    }
}
