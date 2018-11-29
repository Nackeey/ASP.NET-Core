using Eventures.Data;
using Eventures.Models;
using Eventures.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrdersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult All()
        {
            var orders = this.context.Orders.Select(x => new OrderViewModel
            {
                EventName = x.Event.Name,
                CustomerName = x.Customer.UserName,
                OrderedOn = x.OrderedOn,
            });

            return this.View(orders);
        }

        public IActionResult CreateOrder()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult CreateOrder(Guid eventId, int tickets)
        {
            var requestedEvent = this.context.Events.FirstOrDefault(e => e.Id == eventId);

            if (requestedEvent == null)
            {
                return this.BadRequest("Invalid event id.");
            }

            var customer = this.context.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            var order = new Order
            {
                Customer = customer,
                EventId = eventId,
                Event = requestedEvent,
                Tickets = tickets,
                OrderedOn = DateTime.UtcNow
            };

            this.context.Orders.Add(order);
            this.context.SaveChanges();

            return this.RedirectToAction("MyEvents", "Events");
        }
    }
}
