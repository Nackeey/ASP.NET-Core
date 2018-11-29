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
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext applicationDb;
        private readonly ILogger logger;

        public EventsController(ApplicationDbContext applicationDb, ILoggerFactory logger)
        {
            this.applicationDb = applicationDb;
            this.logger = logger.CreateLogger<EventsController>();
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
                    Tickets = x.Tickets
                });

            return this.View(myEvents);
        }

        public IActionResult AllEvents()
        {
            var events = this.applicationDb.Events.Select
                (x => new EventViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Start = x.Start,
                    End = x.End,
                });

            return this.View(events);
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