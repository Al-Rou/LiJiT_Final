using System;
using System.ComponentModel.DataAnnotations;

namespace LiJiT.Model
{
    public class SocialMediaType : Entity<Int16>
    {
        [Required]
        public string Name { get; set; }
        public byte[] Icon { get; set; }
    }
}
