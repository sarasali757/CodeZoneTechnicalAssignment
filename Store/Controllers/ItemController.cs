using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;


namespace Store.Controllers
{
    public class ItemController : Controller
    {
        StoreDbContext db = new StoreDbContext();
        // GET: Item
        [HttpGet]
        public ActionResult Index()
        {
            var items = db.items.Include(i => i.purchases).ToList();   

            return View(items);
        }
        [HttpGet]     
        public ActionResult Add() {

            return View();
        }
        [HttpPost]
        public ActionResult Add(Item item) {
            if (!ModelState.IsValid) {
                return View(nameof(Add));
            }
            db.items.Add(item);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Item/Details/id
        public ActionResult Details(int id)
        {
            Item item = db.items.Include(i=>i.purchases).SingleOrDefault(i=>i.id == id);
            return PartialView(item);
        }

        // item/edit/id
        public ActionResult Edit(int id)
        {
            Item item = db.items.Find(id);

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (!ModelState.IsValid) {

                return View(nameof(Edit), new Item() { id = item.id});
            }
            Item editItem = db.items.Find(item.id);
            editItem.name = item.name;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // item/delete/id
        public ActionResult Delete(int id)
        {
            Item item = db.items.Find(id);
            db.items.Remove(item);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}