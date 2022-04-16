using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiJiT.Model
{
    public class ListingDetailSocialProfiles : Entity<int>
    {
        [ForeignKey("ListingDetailsId")]
        public int ListingDetailsId { get; set; }
        public virtual ListingDetails ListingDetails { get; set; }
        [ForeignKey("SocialMediaTypeId")]
        public Int16 SocialMediaTypeId { get; set; }
        public virtual SocialMediaType SocialMediaType { get; set; }
        [StringLength(150)]
        [Required]
        public string AccountId { get; set; }
    }
}
