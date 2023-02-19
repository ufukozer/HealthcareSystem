using HealthcareSystem.Domain.BaseEntities;

namespace HealthcareSystem.Domain.Entities
{
    public class Patient : BaseEntity
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