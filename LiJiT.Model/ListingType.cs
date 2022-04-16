using System;
using System.ComponentModel.DataAnnotations;

namespace LiJiT.Model
{
    public class ListingType : AuditableEntity<Int16>
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

    }
}
