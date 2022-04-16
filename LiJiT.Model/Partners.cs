using System;
using System.ComponentModel.DataAnnotations;

namespace LiJiT.Model
{
    public class Partners : Entity<Int16>
    {
        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        public byte[] Logo { get; set; }
    }
}
