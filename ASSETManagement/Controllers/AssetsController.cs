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
    public class AssetsController : Controller
    {
        private AppContext db = new AppContext();

        // GET: Assets
        public ActionResult Index(Guid? customerID)
        {
            //Shows only ASSETS currently rented by the client.
            if (customerID == null)
            {
                Session.Remove("customerID");
                ViewBag.isOwner = true;
                return View(db.Assets.ToList());
            }
            else
            {
                Session["customerID"] = customerID;
                ViewBag.isOwner = false;
                //id:customer id passed from customer index view.
                var assets = db.Assets
                    .Where(x => x.OccupancyHistory.Any(o => o.Client.ID == customerID && o.StartDate <= DateTime.Now && o.EndDate >= DateTime.Now))
                    .ToList();
                return View(assets.ToList());
            }
        }

        // GET: Assets/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Include(x => x.Services).Include(x => x.Appliances).Where(x => x.AssetID == id).FirstOrDefault();
            
            return View(asset);
        }

        // GET: Assets/Create
        public ActionResult Create()
        {
            List<Object> type = new List<Object>();
            type.Insert(0, new { Value = "" });
            type.Insert(1, new { Value = "Room" });
            type.Insert(2, new { Value = "Suite" });
            type.Insert(3, new { Value = "Parking Lot" });
            type.Insert(4, new { Value = "Locker" });
            ViewBag.Type = new SelectList(type, "Value", "Value", 0);


            var applicances = db.Appliances.ToList();
            var services = db.Services.ToList();
            applicances.Insert(0, null);
            services.Insert(0, null);

            ViewBag.ApplianceID = new SelectList(applicances, "ApplianceID", "ApplianceType", 0);

            ViewBag.ServiceID = new SelectList(services, "ServiceID", "ServiceType", 0);
                       
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Asset asset, FullAddress fullAddress)
        {
            if (ModelState.IsValid)
            {
                fullAddress.ID = Guid.NewGuid();
                asset.Address = fullAddress;

                asset.AssetID = Guid.NewGuid();
                db.Assets.Add(asset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asset);
        }

        // GET: Assets/Edit/5
        public ActionResult Edit(Guid? id, Occupancy occupancy)
        //edit button shall allow the user to specify the StartDate and EndDate signifying the date when the client will vacate the asset.
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Find(id);

            if (asset == null)
            {
                return HttpNotFound();
            }
            List<Object> type = new List<Object>();
            type.Insert(0, new { Value = asset.Type });
            type.Insert(1, new { Value = "Room" });
            type.Insert(2, new { Value = "Suite" });
            type.Insert(3, new { Value = "Parking Lot" });
            type.Insert(4, new { Value = "Locker" });
            ViewBag.Type = new SelectList(type, "Value", "Value", 0);

            var applicances = db.Appliances.ToList();
            var services = db.Services.ToList();
            applicances.Insert(0, null);
            services.Insert(0, null);

            ViewBag.ApplianceID = new SelectList(applicances, "ApplianceID", "ApplianceType", asset.ApplianceID);
            ViewBag.ServiceID = new SelectList(services, "ServiceID", "ServiceType", asset.ServiceID);

            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Asset asset, FullAddress fullAddress)
        {
            if (ModelState.IsValid)
            {
                asset.Address = fullAddress;
                db.Entry(asset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { customerID = Session["customerID"] });
            }
            return View(asset);
        }

        // GET: Assets/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Asset asset = db.Assets.Find(id);
            db.Assets.Remove(asset);
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
