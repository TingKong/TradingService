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
    [Authorize]

    public class TradersController : Controller
    {
        private TradeServicesEntities db = new TradeServicesEntities();

        // GET: Traders
        public ActionResult Index()
        {
            var traderjob = (from ts in db.TradeSkills
                             join person in db.Traders on ts.TraderID equals person.ID
                             join cat in db.Categories on ts.CategoryID equals cat.ID
                             where ts.TraderID == person.ID && ts.CategoryID == cat.ID && person.AuthKey == User.Identity.Name
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
            Trader trader = new Trader();
            trader.AuthKey = User.Identity.Name;
            return View(trader);
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
                trader.AuthKey = User.Identity.Name;
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

        public ActionResult Admin2()
        {
            return View(db.Traders.ToList());

        }
        public ActionResult ListTrader(int? id)
        {
      

            var traderCat = (from person in db.Traders 
                            join ts in db.TradeSkills on person.ID equals ts.TraderID
                            join jobT in db.Jobs on person.ID equals jobT.TraderID
                            where jobT.ID == id
                            select person).FirstOrDefault();

            if (traderCat == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var jobCat = from j in db.Jobs
                         where j.ID == id
                         select j;
            traderCat.Jobs = jobCat.ToList();

            return View(traderCat);
        }
    }
}
