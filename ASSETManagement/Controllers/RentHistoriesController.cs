using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASSETManagement.Data;
using ASSETManagement.Models;
using AppContext = ASSETManagement.Data.AppContext;

namespace ASSETManagement.Controllers
{
    public class RentHistoriesController : Controller
    {
        private AppContext db = new AppContext();

        // GET: RentHistories
        public ActionResult Index(Guid? assetID)
        {
            if (assetID == null)
            {
                return View(db.RentHistories.ToList());
            }
            else
            {
                Session["AssetID"] = assetID;
                ViewData["AssetName"] = db.Assets.Find(assetID).Name;
                return View(db.RentHistories
                    .Include(x => x.Asset)
                    .Where(x => x. AssetID == assetID)
                    .ToList());
            }
        }


        // GET: RentHistories/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentHistory rentHistory = db.RentHistories.Find(id);
            if (rentHistory == null)
            {
                return HttpNotFound();
            }
            return View(rentHistory);
        }

        // GET: RentHistories/Create
        public ActionResult Create()
        {
            var assets = db.Assets.ToList();
            assets.Insert(0, null);
            ViewBag.AssetID = new SelectList(assets, "AssetID", "Name", 0);
            return View();
        }

        // POST: RentHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NegotiatedOn,Details")] RentHistory rentHistory)
        {
            if (ModelState.IsValid)
            {
                rentHistory.ID = Guid.NewGuid();
                db.RentHistories.Add(rentHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentHistory);
        }

        // GET: RentHistories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentHistory rentHistory = db.RentHistories.Find(id);
            if (rentHistory == null)
            {
                return HttpNotFound();
            }
            return View(rentHistory);
        }

        // POST: RentHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NegotiatedOn,Details")] RentHistory rentHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "RentHistorise", new { id = rentHistory.AssetID });
            }
            return View(rentHistory);
        }

        // GET: RentHistories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentHistory rentHistory = db.RentHistories.Find(id);
            if (rentHistory == null)
            {
                return HttpNotFound();
            }
            return View(rentHistory);
        }

        // POST: RentHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RentHistory rentHistory = db.RentHistories.Find(id);
            db.RentHistories.Remove(rentHistory);
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
