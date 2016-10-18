namespace Core.Entities
{
    using System;
    using Interfaces;

    public class Entity : IEntity
    {
        public Guid Id { get; set; }
    }
}
