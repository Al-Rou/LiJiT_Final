using System;
namespace LiJiT.Model
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
