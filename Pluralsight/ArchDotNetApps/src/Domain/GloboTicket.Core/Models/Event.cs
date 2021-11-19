using System;
using GloboTicket.Common;
namespace GloboTicket.Core.Models
{
    public class Event : AuditableEntityBase
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public DateTime Date { get; set; }
    }
}