using System;

namespace Core.Entities.Flow
{
    public class Action : Entity
    {
        public string Name { get; set; }

        public Guid NodeId { get; set; }

        public Guid TransferId { get; set; }

        public ActionTypeEnum Type { get; set; }

        public ActionAllocationEnum? AllocationType { get; set; }

        public string Method { get; set; }

        public virtual Node Node { get; set; }

        public virtual Node Transfer { get; set; }
    }
}
