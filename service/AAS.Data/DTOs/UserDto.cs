using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AAS.Data.DTOs
{
    public class UserDto : AuditDto<int>
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Username))
            {
                yield return new ValidationResult("A username must be chosen.");
            }
        }
    }
}