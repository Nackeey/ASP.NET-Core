using AutoMapper;
using Eventures.Data;
using Eventures.Models;
using Eventures.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Eventures.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public OrdersController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult All()
        {
            var orders = this.context.Orders.Select(x => new OrderViewModel
            {
                EventName = x.Event.Name,
                Customer = x.Customer.UserName,
                OrderedOn = x.OrderedOn,
            });

            return this.View(orders);
        }
            
        public IActionResult CreateOrder()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult CreateOrder(Guid eventId, int tickets, OrderViewModel model)
        {
            var requestedEvent = this.context.Events.FirstOrDefault(e => e.Id == eventId);

            if (requestedEvent == null)
            {
                return this.BadRequest("Invalid event id.");
            }

            if (requestedEvent.TotalTickets < tickets)
            {
                return this.BadRequest("We don't have enough tickets to complete your order.");
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

            requestedEvent.TotalTickets -= tickets;

            this.context.Orders.Add(order);
            this.context.SaveChanges();

            return this.RedirectToAction("MyEvents", "Events");
        }
    }
}
