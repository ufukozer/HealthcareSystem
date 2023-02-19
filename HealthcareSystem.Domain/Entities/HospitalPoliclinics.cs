using HealthcareSystem.Domain.BaseEntities;


namespace HealthcareSystem.Domain.Entities
{
    public class HospitalPoliclinics : BaseEntity
    {
        public Hospital Hospital { get; set; }
        public Policlinic Policlinic { get; set; }
    }
}
