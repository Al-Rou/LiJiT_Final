using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiJiT.Model
{
    public class Reviews : AuditableEntity<int>
    {
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(250)]
        [Required]
        public string Comment { get; set; }
        [StringLength(50)]
        [Required]
        public string Fullname { get; set; }
        [StringLength(100)]
        [Required]
        public string Email { get; set; }
        [Required]
        public float Rate { get; set; }
        [ForeignKey("ObjectTypeId")]
        public Int16 ObjectTypeId { get; set; }
        public virtual ObjectType ObjectType {get; set;}

        public int ObjectId { get; set; }

    }
}
