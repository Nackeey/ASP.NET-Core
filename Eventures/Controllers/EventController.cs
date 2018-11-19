using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Data;
using Eventures.Models;
using Eventures.ViewModels.Event;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext applicationDb;

        public EventController(ApplicationDbContext applicationDb)
        {
            this.applicationDb = applicationDb;
        }

        public IActionResult AllEvents()
        {
            return View();
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

                return RedirectToAction("AllEvents");
            }

            return this.View(model);
        }
    }
}