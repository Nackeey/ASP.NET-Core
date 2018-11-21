using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Data;
using Eventures.ViewModels.EventViewModels;
using Eventures.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eventures.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext applicationDb;
        private readonly ILogger logger;

        public EventController(ApplicationDbContext applicationDb, ILoggerFactory logger)
        {
            this.applicationDb = applicationDb;
            this.logger = logger.CreateLogger<EventController>();
        }

        public IActionResult AllEvents()
        {
            var events = this.applicationDb.Events.ToList();

            var allEvents = new AllEventsViewModel
            {
                Events = events
            };

            return View("AllEvents", allEvents);
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
                var newEvent = new Event
                {
                    Name = model.Name,
                    Place = model.Place,
                    Start = model.Start,
                    End = model.End,
                    TotalTickets = model.TotalTickets,
                    PricePerTicket = model.PricePerTicket,
                };

                this.applicationDb.Events.Add(newEvent);
                this.applicationDb.SaveChanges();

                this.logger.LogInformation($"{this.User.Identity.Name} created a new event with start date {model.Start}");
                return RedirectToAction("AllEvents");
            }

            return this.View(model);
        }
    }
}