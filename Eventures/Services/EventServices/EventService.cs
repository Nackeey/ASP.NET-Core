using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Eventures.Data;
using Eventures.Models;
using Eventures.ViewModels.EventViewModels;
using X.PagedList;
using Microsoft.Extensions.Logging;

namespace Eventures.Services.EventServices
{ 
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext applicationDb;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public EventService(ApplicationDbContext applicationDb, IMapper mapper)
        {
            this.applicationDb = applicationDb;
            this.mapper = mapper;
        }

        public IEnumerable<EventViewModel> AllEvents(int? page)
        {
            var events = this.applicationDb
                .Events
                .Select(x => this.mapper.Map<EventViewModel>(x))
                .ToList();
            
            var nextPage = page ?? 1;

            var eventsOnPage = events.ToPagedList(nextPage, 4);

            return eventsOnPage;
        }
    }
}
