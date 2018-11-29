using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Models;

namespace Eventures.ViewModels.EventViewModels
{
    public class AllEventsViewModel
    {
        public IEnumerable<EventViewModel> Events { get; set; }
    }
}
