using System;

namespace AAS.Data.DTOs
{
    public abstract class AuditDto<TType> : BaseDto<TType>
    {
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
