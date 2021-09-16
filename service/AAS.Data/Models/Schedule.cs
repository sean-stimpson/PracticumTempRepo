using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAS.Data.Models
{
    public class Schedule : AuditModel<int>
    {
        [ForeignKey("Business")]
        public int BusId { get; set; }
        [Required]
        public int SunOpen { get; set; }
        [Required]
        public int SunClose { get; set; }
        [Required]
        public int MonOpen { get; set; }
        [Required]
        public int MonClose { get; set; }
        [Required]
        public int TueOpen { get; set; }
        [Required]
        public int TueClose { get; set; }
        [Required]
        public int WedOpen { get; set; }
        [Required]
        public int WedClose { get; set; }
        [Required]
        public int ThuOpen { get; set; }
        [Required]
        public int ThuClose { get; set; }
        [Required]
        public int FriOpen { get; set; }
        [Required]
        public int FriClose { get; set; }
        [Required]
        public int SatOpen { get; set; }
        [Required]
        public int SatClose { get; set; }
        [Required]
        public int MinuteIncrement { get; set; }
    }
}