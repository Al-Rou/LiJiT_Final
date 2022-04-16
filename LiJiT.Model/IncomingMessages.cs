using System;
using System.ComponentModel.DataAnnotations;

namespace LiJiT.Model
{
    public class IncomingMessages : AuditableEntity<int>
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(100)]
        [Required]
        public string Email { get; set; }
        [StringLength(400)]
        [Required]
        public string Message { get; set; }

    }
}
