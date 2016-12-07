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

    public class TradeSkillsController : Controller
    {
        private TradeServicesEntities db = new TradeServicesEntities();

        // GET: TradeSkills
        public ActionResult Index()
        {
            var tradeSkills = db.TradeSkills.Include(t => t.Category).Include(t => t.Trader);
            return View(tradeSkills.ToList());
        }

        // GET: TradeSkills/Details/5
        public ActionResult Details(int? id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TradeSkill tradeSkill = db.TradeSkills.Find(id, id2);
            if (tradeSkill == null)
            {
                return HttpNotFound();
            }
            return View(tradeSkill);
        }

        // GET: TradeSkills/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.TraderID = new SelectList(db.Traders, "ID", "Name");
            return View();
        }

        // POST: TradeSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TraderID,CategoryID,YearsOfExp,ShortDes")] TradeSkill tradeSkill)
        {
            if (ModelState.IsValid)
            {
                db.TradeSkills.Add(tradeSkill);
                db.SaveChanges();
                return RedirectToAction("../Traders/Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", tradeSkill.CategoryID);
            ViewBag.TraderID = new SelectList(db.Traders, "ID", "Name", tradeSkill.TraderID);
            return View(tradeSkill);
        }

        // GET: TradeSkills/Edit/5
        public ActionResult Edit(int? id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TradeSkill tradeSkill = db.TradeSkills.Find(id, id2);
            if (tradeSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", tradeSkill.CategoryID);
            ViewBag.TraderID = new SelectList(db.Traders, "ID", "Name", tradeSkill.TraderID);
            return View(tradeSkill);
        }

        // POST: TradeSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TraderID,CategoryID,YearsOfExp,ShortDes")] TradeSkill tradeSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tradeSkill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", tradeSkill.CategoryID);
            ViewBag.TraderID = new SelectList(db.Traders, "ID", "Name", tradeSkill.TraderID);
            return View(tradeSkill);
        }

        // GET: TradeSkills/Delete/5
        public ActionResult Delete(int? id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TradeSkill tradeSkill = db.TradeSkills.Find(id, id2);
            if (tradeSkill == null)
            {
                return HttpNotFound();
            }
            return View(tradeSkill);
        }

        // POST: TradeSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TradeSkill tradeSkill = db.TradeSkills.Find(id);
            db.TradeSkills.Remove(tradeSkill);
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
