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
            List<Machine> model = _db.Machines.ToList();
            return View(model);
        }

        //         public ActionResult Create()
        //         {
        //             ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
        //             return View();
        //         }

        //         [HttpPost]
        //         public ActionResult Create(Cuisine cuisine)
        //         {
        //             _db.Cuisines.Add(cuisine);
        //             _db.SaveChanges();
        //             return RedirectToAction("Index");
        //         }

        //         public ActionResult Details(int id)
        //         {
        //             Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
        //             return View(thisCuisine);
        //         }

        //         public ActionResult Edit(int id)
        //         {
        //             var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
        //             ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
        //             return View(thisCuisine);
        //         }

        //         [HttpPost]
        //         public ActionResult Edit(Cuisine cuisine)
        //         {
        //             _db.Entry(cuisine).State = EntityState.Modified;
        //             _db.SaveChanges();
        //             return RedirectToAction("Index");
        //         }

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