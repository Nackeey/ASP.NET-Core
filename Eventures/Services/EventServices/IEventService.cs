using Eventures.ViewModels.EventViewModels;
using System.Collections.Generic;

namespace Eventures.Services.EventServices
{
    public interface IEventService
    {
        IEnumerable<EventViewModel> AllEvents(int? page);
    }
}
