using System.ComponentModel.DataAnnotations.Schema;


namespace CleanArch.Domain.Common
{
    public class BaseEntity
    {
        public virtual DateTime? CreatedAt { get; set; }
        public virtual string CreatedBy { get; set; } = string.Empty;
        public virtual DateTime? ModifiedAt { get; set; }
        public virtual string ModifiedBy { get; set; } = string.Empty;

        public virtual int Estado { get; set; }

        public virtual long Id { get; set; }

    }
}
