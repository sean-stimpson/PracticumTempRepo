using System.ComponentModel.DataAnnotations;

namespace AAS.Data.Models
{
    public class Library : AuditModel<int>
    {
        [MaxLength(Constants.MaximumLengths.StringColumn)]
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
