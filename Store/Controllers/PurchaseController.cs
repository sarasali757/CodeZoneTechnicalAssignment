using Store.Models;
using Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Store.Controllers
{
    public class PurchaseController : Controller
    {
        StoreDbContext db = new StoreDbContext();
        // GET: Purchase
        public ActionResult Index()
        {
            List<Purchase> purchases = db.purchases.Include(a => a.item).ToList();
            return View(purchases);
        }
        // get : purchase/add
        public ActionResult Add() {

            PurchaseItems purchaseItems = new PurchaseItems();

            purchaseItems.items = db.items.ToList();

            return View(purchaseItems);
        }

        [HttpPost]
        public ActionResult Add(PurchaseItems purchaseItem)
        {
            if (!ModelState.IsValid) {
                return RedirectToAction(nameof(Add));
            }
            db.purchases.Add(purchaseItem.purchase);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id) {

            Purchase purchase = db.purchases.Include(a=>a.item).FirstOrDefault(a=>a.id == id);
            Item item = db.items.Find(purchase.itemId);
            item.quantity -= purchase.quantity;
            db.purchases.Remove(purchase);
            db.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }
    }

}