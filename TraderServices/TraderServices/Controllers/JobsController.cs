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
    public class JobsController : Controller
    {
        private TradeServicesEntities db = new TradeServicesEntities();

        // GET: Jobs
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.Category).Include(j => j.Trader);
            
            return View(jobs.ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        [Authorize]

        // GET: Jobs/Create
        public ActionResult Create()
        {
            Job traderjob = new Job();
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.TraderID = new SelectList(db.Traders, "ID", "Name");

            var traderPerson = (from tp in db.Jobs
                             join person in db.Traders on tp.TraderID equals person.ID
                             where tp.TraderID == person.ID && person.AuthKey == User.Identity.Name
                             select person).FirstOrDefault();

            return View(traderPerson);
        }
        [Authorize]

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Names,Details,DueDate,TraderID,CategoryID")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", job.CategoryID);
            ViewBag.TraderID = new SelectList(db.Traders, "ID", "Name", job.TraderID);
            return View(job);
        }
        [Authorize]

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", job.CategoryID);
            ViewBag.TraderID = new SelectList(db.Traders, "ID", "Name", job.TraderID);
            return View(job);
        }
        [Authorize]

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Names,Details,DueDate,TraderID,CategoryID")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", job.CategoryID);
            ViewBag.TraderID = new SelectList(db.Traders, "ID", "Name", job.TraderID);
            return View(job);
        }
        [Authorize]

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        [Authorize]

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
