using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AAS.Data.DTOs
{
    public class AppointmentDto : AuditDto<int>
    {
        public int ClientId { get; set; }
        public int BusId { get; set; }
        public DateTime AppDateTime { get; set; }
        
        public bool IsValid { get; set; }
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ClientId == -1 || BusId == -1)
            {
                yield return new ValidationResult("A valid client and business Id must be entered.");
            }
        }
    }
}