using FMVC.Data;
using FMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace FMVC.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext context;
        public AdminController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
         
            var events = context.Events
                                 .Include(e => e.Registrations)
                                 .ThenInclude(r => r.User)
                                 .ToList();
            return View(events); 
        }

        [HttpPost]
        public IActionResult AddEvent(Event newEvent)
        {
            context.Events.Add(newEvent);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteEvent(int id)
        {
            var evnt = context.Events.Find(id);
            if (evnt != null)
            {
                context.Events.Remove(evnt);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            var eventToEdit = context.Events.FirstOrDefault(e => e.EventId == id);

            if (eventToEdit == null)
            {
                return NotFound(); 
            }

            return View(eventToEdit); 
        }

        [HttpPost]
        public IActionResult Edit(Event updatedEvent)
        {
     
            var eventInDb = context.Events.FirstOrDefault(e => e.EventId == updatedEvent.EventId);

            if (eventInDb == null)
            {
                return NotFound(); 
            }

           
            eventInDb.EventName = updatedEvent.EventName;
            eventInDb.Description = updatedEvent.Description;
            eventInDb.Location = updatedEvent.Location;
            eventInDb.Date = updatedEvent.Date;

          
            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}