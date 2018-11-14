using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaStorage.Models
{
    public class Receipt
    {
        public Guid Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime? IssuedOn { get; set; }

        public Guid RecipienId { get; set; }
        public PandaUser Recipient { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }
    }
}
