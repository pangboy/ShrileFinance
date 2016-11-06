namespace Core.Entities.Flow
{
    using System.Collections.Generic;

    public class Flow : Entity
    {
        public Flow()
        {
            Nodes = new HashSet<Node>();
        }

        public string Name { get; set; }

        public virtual ICollection<Node> Nodes { get; set; }
    }
}
