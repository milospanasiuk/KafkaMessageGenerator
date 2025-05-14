using System;

namespace OrderKafkaMessageGenerator.Models.Entities
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
    }
}
