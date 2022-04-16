using System;
using System.ComponentModel.DataAnnotations;

namespace LiJiT.Model
{
    public abstract class AuditableEntity<T> :Entity<T>, IAuditableEntity
    {

        public DateTime CreatedDate { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        [StringLength(50)]
        public string UpdatedBy { get; set; }
    }
}
