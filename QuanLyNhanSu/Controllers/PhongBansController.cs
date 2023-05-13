using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Controllers
{
    public class PhongBansController : Controller
    {
        private Data db = new Data();

        // GET: PhongBans
        public ActionResult Index()
        {
            return View(db.PhongBans.ToList());
        }

        // GET: PhongBans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongBan phongBan = db.PhongBans.Find(id);
            if (phongBan == null)
            {
                return HttpNotFound();
            }
            return View(phongBan);
        }

        // GET: PhongBans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhongBans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPB,TenPhong,SDT")] PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                db.PhongBans.Add(phongBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phongBan);
        }

        // GET: PhongBans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongBan phongBan = db.PhongBans.Find(id);
            if (phongBan == null)
            {
                return HttpNotFound();
            }
            return View(phongBan);
        }

        // POST: PhongBans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPB,TenPhong,SDT")] PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phongBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phongBan);
        }

        // GET: PhongBans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongBan phongBan = db.PhongBans.Find(id);
            if (phongBan == null)
            {
                return HttpNotFound();
            }
            return View(phongBan);
        }

        // POST: PhongBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhongBan phongBan = db.PhongBans.Find(id);
            db.PhongBans.Remove(phongBan);
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
