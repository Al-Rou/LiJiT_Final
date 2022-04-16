using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiJiT.Model
{
    public class ListingDetails : AuditableEntity<int>
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(150)]
        [Required]
        public string Address { get; set; }
        [StringLength(150)]
        [Required]
        public string Address2 { get; set; }
        public string Description { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        public string Location { get; set; }
        public string Note { get; set; }
        [StringLength(100)]
        public string Website { get; set; }
        public float Rate { get; set; }
        [ForeignKey("ListingTypeId")]
        public Int16 ListingTypeId { get; set; }
        public virtual ListingType ListingType { get; set; }
        public bool IsHotBussiness { get; set; }
        public byte[] HomeImage { get; set; }
        [StringLength(200)]
        public string Facebook { get; set; }
        [StringLength(200)]
        public string Instagram { get; set; }
        [StringLength(200)]
        public string Youtube { get; set; }
        [StringLength(300)]
        public string ShareLink { get; set; }
        [StringLength(300)]
        public string OrderLink { get; set; }

    }
}
