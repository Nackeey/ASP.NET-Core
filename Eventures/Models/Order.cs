using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public Guid EventId { get; set; }
        public Event Event { get; set; }

        public Guid CustomerId { get; set; }
        public EventureUser Customer { get; set; }

        public int Tickets { get; set; }
    }
}
