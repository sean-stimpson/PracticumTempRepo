using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AAS.Data.Models
{
    public class User : AuditModel<int>
    {
        [MaxLength(Constants.MaximumLengths.StringColumn)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
