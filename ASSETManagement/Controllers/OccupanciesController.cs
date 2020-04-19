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
    [Authorize]
    public class OccupanciesController : Controller
    {
        private AppContext db = new AppContext();

        // GET: Occupancies
        public ActionResult Index(Guid? assetID)
        {
            if (assetID == null)
            {
                return View(db.Occupancies
                    .GroupBy(x => x.ClientID)
                    .SelectMany(x => x)
                    .ToList());
            }
            else
            {
                ViewData["AssetName"] = db.Assets.Find(assetID).Name;
                return View(db.Occupancies
                    .Include(x => x.Client)
                    .Include(x => x.Asset)
                    .Include(x => x.Asset.Address)
                    .Where(x => x.AssetID == assetID)
                    .ToList());
            }
        }

        // GET: Occupancies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupancy occupancy = db.Occupancies.Find(id);
            if (occupancy == null)
            {
                return HttpNotFound();
            }
            return View(occupancy);
        }

        // GET: Occupancies/Create
        public ActionResult Create()
        {
            Guid customerID = (Guid)Session["customerID"];
            var assets = db.Assets
                .Where(x => x.OccupancyHistory.All(o => o.Client.ID != customerID))
                .ToList();
            assets.Insert(0, null);
            ViewBag.AssetID = new SelectList(assets, "AssetID", "Name", 0);
            return View();
        }

        // POST: Occupancies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Occupancy occupancy)
        {
            if (ModelState.IsValid)
            {
                occupancy.ClientID = (Guid)Session["customerID"];
                db.Occupancies.Add(occupancy);
                db.SaveChanges();
                return RedirectToAction("Index", "Assets", new { customerID = Session["customerID"] });
            }

            return View(occupancy);
        }

        // GET: Occupancies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupancy occupancy = db.Occupancies.Find(id);
            if (occupancy == null)
            {
                return HttpNotFound();
            }
            return View(occupancy);
        }

        // POST: Occupancies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Occupancy occupancy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(occupancy).State = EntityState.Modified;
                db.SaveChanges();
                if (Session["customerID"] == null)
                {
                    return RedirectToAction("Index", "Occupancies", new { id = occupancy.AssetID });
                }
                else
                {
                    return RedirectToAction("Index", "Assets", new { customerID = Session["customerID"] });
                }
            }
            return View(occupancy);
        }

        // GET: Occupancies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupancy occupancy = db.Occupancies.Find(id);
            if (occupancy == null)
            {
                return HttpNotFound();
            }
            return View(occupancy);
        }

        // POST: Occupancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Occupancy occupancy = db.Occupancies.Find(id);
            db.Occupancies.Remove(occupancy);
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
