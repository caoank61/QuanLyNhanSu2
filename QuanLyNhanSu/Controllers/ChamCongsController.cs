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
    public class ChamCongsController : Controller
    {
        private Data db = new Data();

        // GET: ChamCongs
        public ActionResult Index()
        {
            var chamCongs = db.ChamCongs.Include(c => c.NhanVien);
            return View(chamCongs.ToList());
        }

        // GET: ChamCongs/Details/5
        public ActionResult Details(DateTime ngay,int id)
        {
            if (id == 0&& ngay== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = db.ChamCongs.Find(ngay,id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            return View(chamCong);
        }

        // GET: ChamCongs/Create
        public ActionResult Create()
        {
            ViewBag.IdNV = new SelectList(db.NhanViens, "IdNV", "HoTen");
            return View();
        }

        // POST: ChamCongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NgayChamCong,IdNV")] ChamCong chamCong)
        {
            if (ModelState.IsValid)
            {
                db.ChamCongs.Add(chamCong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdNV = new SelectList(db.NhanViens, "IdNV", "HoTen", chamCong.IdNV);
            return View(chamCong);
        }

        // GET: ChamCongs/Edit/5
        public ActionResult Edit(DateTime ngay,int? id)
        {
            var ngayc = ngay.ToString("dd/MM/yyyy");
            if (id == null && ngay == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ngay = ngay.ToString("dd/MM/yyyy");
            ViewBag.id = id;
            ChamCong chamCong = db.ChamCongs.Where(p => p.IdNV == id && Convert.ToString(p.NgayChamCong)  == ngayc).FirstOrDefault();

            if (chamCong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdNV = new SelectList(db.NhanViens, "IdNV", "HoTen", chamCong.IdNV);
            return View(chamCong);

        }

        // POST: ChamCongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NgayChamCong,IdNV")] ChamCong chamCong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamCong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdNV = new SelectList(db.NhanViens, "IdNV", "HoTen", chamCong.IdNV);
            return View(chamCong);
        }

        // GET: ChamCongs/Delete/5
        public ActionResult Delete(DateTime ngay,int id)
        {
            if (id == 0 && ngay == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = db.ChamCongs.Find(ngay, id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            return View(chamCong);
        }

        // POST: ChamCongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime ngay,int id)
        {
            ChamCong chamCong = db.ChamCongs.Find(ngay, id);
            db.ChamCongs.Remove(chamCong);
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
