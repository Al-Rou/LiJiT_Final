using System;
using System.ComponentModel.DataAnnotations;

namespace LiJiT.Model
{
    public class StatusType : Entity<Int16>
    {
        [Required]
        public string Name { get; set; }
    }
}
