using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaStorage.Models
{
    public class Package
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public Guid RecipientId { get; set; }
        public PandaUser Recipient { get; set; }
    }
}
