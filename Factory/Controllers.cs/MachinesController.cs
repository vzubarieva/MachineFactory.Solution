using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
    public class MachinesController : Controller
    {
        private readonly FactoryContext _db;

        public MachinesController(FactoryContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Machines.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Machine machine, int EngineerId)
        {
            _db.Machines.Add(machine);
            _db.SaveChanges();
            if (EngineerId != 0)
            {
                _db.EngineerMachine.Add(
                    new EngineerMachine() { EngineerId = EngineerId, MachineId = machine.MachineId }
                );
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisMachine = _db.Machines
                .Include(machine => machine.JoinEntities)
                .ThenInclude(join => join.Engineer)
                .FirstOrDefault(machine => machine.MachineId == id);
            return View(thisMachine);
        }

        public ActionResult Edit(int id)
        {
            var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
            ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
            return View(thisMachine);
        }

        [HttpPost]
        public ActionResult Edit(Machine machine, int EngineerId)
        {
            if (EngineerId != 0)
            {
                _db.EngineerMachine.Add(
                    new EngineerMachine() { EngineerId = EngineerId, MachineId = machine.MachineId }
                );
            }
            _db.Entry(machine).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddEngineer(int id)
        {
            var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
            ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
            return View(thisMachine);
        }

        [HttpPost]
        public ActionResult AddEngineer(Machine machine, int EngineerId)
        {
            if (EngineerId != 0)
            {
                _db.EngineerMachine.Add(
                    new EngineerMachine() { EngineerId = EngineerId, MachineId = machine.MachineId }
                );
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //         public ActionResult Delete(int id)
        //         {
        //             var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
        //             return View(thisCuisine);
        //         }

        //         [HttpPost, ActionName("Delete")]
        //         public ActionResult DeleteConfirmed(int id)
        //         {
        //             var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
        //             _db.Cuisines.Remove(thisCuisine);
        //             _db.SaveChanges();
        //             return RedirectToAction("Index");
        //         }
    }
}
