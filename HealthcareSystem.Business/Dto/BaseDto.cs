using HealthcareSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthcareSystem.Business.Dto
{
    public class BaseDto
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime? LastUpdateDate { get; set; }
        [JsonIgnore]
        public State State { get; set; }
    }
}
