using HealthcareSystem.Domain.Abstracts;
using HealthcareSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Domain.BaseEntities
{
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public State State { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }

    }

}
