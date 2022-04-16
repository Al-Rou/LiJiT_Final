using System;
using System.ComponentModel.DataAnnotations;

namespace LiJiT.Model
{
    public class ObjectType : Entity<Int16>
    {
        [Required]
        public string Name { get; set; }
    }
}
