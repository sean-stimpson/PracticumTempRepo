using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAS.Data.Models
{
    public class Business
    {
        [Key]
        public int BusId { get; set;}
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string BusinessName { get; set; }
        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }
        
        [Required]
        public string Field { get; set; } 
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
    }
}