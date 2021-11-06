using System;

namespace GloboTicket.Common
{
    public class AuditableEntityBase : EntityBase, IAuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}