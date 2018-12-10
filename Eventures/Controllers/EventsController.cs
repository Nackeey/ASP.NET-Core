using Eventures.Data;
using Eventures.ViewModels.EventViewModels;
using Eventures.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Eventures.Services.EventServices;
using System.Linq;

namespace Eventures.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext applicationDb;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public IEventService EventService { get; set; }

        public EventsController(ApplicationDbContext applicationDb, ILoggerFactory logger, IMapper mapper, IEventService eventService)
        {
            this.applicationDb = applicationDb;
            this.logger = logger.CreateLogger<EventsController>();
            this.mapper = mapper;
            this.EventService = eventService;
        }

        public IActionResult MyEvents()
        {
            var myEvents = this.applicationDb
                 .Orders
                 .Where(x => x.Customer.UserName == this.User.Identity.Name)
                 .Select(x => new MyEventViewModel
                 {
                     Name = x.Event.Name,
                     Start = x.Event.Start,
                     End = x.Event.End,
                     TotalTickets = x.Tickets
                 });

            return this.View(myEvents);
        }

        public IActionResult AllEvents(int? page)
        {
            var eventsOnPage = this.EventService.AllEvents(page);
              
            return this.View(eventsOnPage);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newEvent = this.mapper.Map<Event>(model);

                this.applicationDb.Events.Add(newEvent);
                this.applicationDb.SaveChanges();

                this.logger.LogInformation($"{this.User.Identity.Name} created a new event with start date {model.Start}");
                return RedirectToAction("AllEvents");
            }

            return this.View(model);
        }
    }
}