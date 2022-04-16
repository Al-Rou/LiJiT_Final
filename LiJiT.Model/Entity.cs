using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LiJiT.Model
{
    [DataContract(IsReference = true)]
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        [Key]
        public virtual T Id { get; set; }
    }


}
