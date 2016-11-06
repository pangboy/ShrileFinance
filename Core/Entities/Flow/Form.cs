namespace Core.Entities.Flow
{
    using System;
    using System.Collections.Generic;

    public class Form : Entity
    {
        public Form()
        {
            Nodes = new HashSet<FormNode>();
            Roles = new HashSet<FormRole>();
        }

        public Guid FlowId { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public byte Sort { get; set; }

        public virtual Flow Flow { get; set; }

        public virtual ICollection<FormNode> Nodes { get; set; }

        public virtual ICollection<FormRole> Roles { get; set; }
    }
}
