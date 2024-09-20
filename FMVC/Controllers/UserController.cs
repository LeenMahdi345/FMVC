using FMVC.Data;
using FMVC.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace FMVC.Controllers
{
    public class UserController : Controller
    {
      
        ApplicationDbContext context;
        public UserController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
          
            var events = context.Events.ToList();
            return View(events);


           
        }
       

        [HttpGet]
            public IActionResult EventsList()
            {
                var events = context.Events.ToList();
                return View(events);
            }

            [HttpPost]
      
       
        public IActionResult ReserveEvent(int eventId)
        {



            var userExists = context.Users.Any(u => u.UserId == User.UserId);

            var reservation = new Registration { EventId = eventId, UserId = User.UserId };
            context.Registrations.Add(reservation);
            context.SaveChanges();

            return RedirectToAction("EventsList");
        }

        [HttpGet]
     
        public IActionResult MyReservations()
        {


           


            var registration = context.Registrations
                .Where(e=> e.Id == User.UserId)
                .Include(m => m.Event).ToList();
                return View(registration);
            }

            [HttpPost]
            public IActionResult CancelReservation(int reservationId)
            {
                var reservation = context.Registrations.Find(reservationId);
                if (reservation != null)
                {
                    context.Registrations.Remove(reservation);
                    context.SaveChanges();
                }
                return RedirectToAction("MyReservations");
            }

          
        }

    }

