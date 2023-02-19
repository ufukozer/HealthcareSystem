using HealthcareSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Domain.Abstracts
{
        public interface IBaseEntity
        {
            Guid Id { get; set; }
            State State { get; set; }
            DateTime CreationDate { get; set; }
            DateTime? LastUpdateDate { get; set; }
        }
}
