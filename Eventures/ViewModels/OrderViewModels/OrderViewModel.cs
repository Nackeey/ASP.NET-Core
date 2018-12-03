using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public string EventName{ get; set; }

        public string Customer { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}
