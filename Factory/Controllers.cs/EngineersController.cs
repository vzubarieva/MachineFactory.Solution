using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
    public class EngineersController : Controller
    {
        private readonly FactoryContext _db;

        public EngineersController(FactoryContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Engineers.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Type");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Engineer engineer, int MachineId)
        {
            _db.Engineers.Add(engineer);
            _db.SaveChanges();
            if (MachineId != 0)
            {
                _db.EngineerMachine.Add(
                    new EngineerMachine()
                    {
                        MachineId = MachineId,
                        EngineerId = engineer.EngineerId
                    }
                );
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisEngineer = _db.Engineers
                .Include(engineer => engineer.JoinEntities)
                .ThenInclude(join => join.Machine)
                .FirstOrDefault(engineer => engineer.EngineerId == id);
            return View(thisEngineer);
        }

        public ActionResult Edit(int id)
        {
            var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
            ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
            return View(thisEngineer);
        }

        [HttpPost]
        public ActionResult Edit(Engineer engineer, int MachineId)
        {
            if (MachineId != 0)
            {
                _db.EngineerMachine.Add(
                    new EngineerMachine()
                    {
                        MachineId = MachineId,
                        EngineerId = engineer.EngineerId
                    }
                );
            }
            _db.Entry(engineer).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // public ActionResult Delete(int id)
        // {
        //     var thisRestaurant = _db.Restaurants.FirstOrDefault(
        //         restaurant => restaurant.RestaurantId == id
        //     );
        //     return View(thisRestaurant);
        // }

        // [HttpPost, ActionName("Delete")]
        // public ActionResult DeleteConfirmed(int id)
        // {
        //     var thisRestaurant = _db.Restaurants.FirstOrDefault(
        //         restaurant => restaurant.RestaurantId == id
        //     );
        //     _db.Restaurants.Remove(thisRestaurant);
        //     _db.SaveChanges();
        //     return RedirectToAction("Index");
        // }
    }
}
