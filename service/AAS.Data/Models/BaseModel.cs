using System.ComponentModel.DataAnnotations;

namespace AAS.Data.Models
{
    public abstract class BaseModel<TType>
    {
        [Key]
        public TType Id { get; set; }
    }
}
