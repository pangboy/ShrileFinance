namespace Core.Entities.Other
{
    using System;
    using Interfaces;

    /// <summary>
    /// 草稿
    /// </summary>
    public class Draft : Entity, IAggregateRoot
    {
        public Draft()
        {
            DateCreated = DateTime.Now;
        }

        public string UserId { get; set; }

        public string PageLink { get; set; }

        public string PageData { get; set; }

        public DateTime DateCreated { get; private set; }

        public virtual AppUser User { get; set; }
    }
}
