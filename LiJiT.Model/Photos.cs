using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiJiT.Model
{
    public class Photos : Entity<int>
    {
        public byte[] Image { get; set; }
        [StringLength(150)]
        public string Caption { get; set; }

        public bool isActive { get; set; }
        [ForeignKey("ObjectTypeId")]
        public Int16 ObjectTypeId { get; set; }
        public virtual ObjectType ObjectType { get; set; }

        public int ObjectId { get; set; }

    }
}
