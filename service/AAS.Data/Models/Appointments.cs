using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAS.Data.Models
{
    public class Appointment : AuditModel<int>
    {
        [ForeignKey("User")]
        [Required]
        public int ClientId { get; set; }
        [ForeignKey("Business")]
        [Required]
        public int BusId { get; set; }
        [Required]
        public DateTime AppDateTime { get; set; }
        [Required]
        public bool IsValid { get; set; }
    }
}