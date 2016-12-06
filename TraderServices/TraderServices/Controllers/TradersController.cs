using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TraderServices;

namespace TraderServices.Controllers
{
    public class TradersController : Controller
    {
        private TradeServicesEntities db = new TradeServicesEntities();

        // GET: Traders
        public ActionResult Index()
        {
            var traderjob = (from ts in db.TradeSkills
                             join person in db.Traders on ts.TraderID equals person.ID
                             join cat in db.Categories on ts.CategoryID equals cat.ID
                             where ts.TraderID == person.ID && ts.CategoryID == cat.ID
                             select person).FirstOrDefault();


            return View(traderjob);
        }

        // GET: Traders/Details/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trader trader = db.Traders.Find(id);
            if (trader == null)
            {
                return HttpNotFound();
            }
            return View(trader);
        }

        // GET: Traders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Traders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,AuthKey")] Trader trader)
        {
            if (ModelState.IsValid)
            {
                db.Traders.Add(trader);
                db.SaveChanges();
                return RedirectToAction("../TradeSkills/Create");
            }

            return View(trader);
        }

        // GET: Traders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trader trader = db.Traders.Find(id);
            if (trader == null)
            {
                return HttpNotFound();
            }
            return View(trader);
        }

        // POST: Traders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,AuthKey")] Trader trader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(trader);
        }

        // GET: Traders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trader trader = db.Traders.Find(id);
            if (trader == null)
            {
                return HttpNotFound();
            }
            return View(trader);
        }

        // POST: Traders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trader trader = db.Traders.Find(id);
            db.Traders.Remove(trader);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
