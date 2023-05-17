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
            /*List<ChamCong> chamCongs = null;
            int id = Convert.ToInt32(Session["user_id"]);
            if (Convert.ToBoolean(Session["isAdmin"]))
            {
                 chamCongs = db.ChamCongs.Include(c => c.NhanVien).ToList();
            }else
            {
                 chamCongs = db.ChamCongs.Where(i =>i.IdNV == id).Include(c => c.NhanVien).ToList();
            }*/
            var chamCongs = db.ChamCongs.Include(c => c.NhanVien);

            return View(chamCongs.ToList());
        }

        // GET: ChamCongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = db.ChamCongs.Find(id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            return View(chamCong);
        }

        // GET: ChamCongs/Create
        public ActionResult Create(int IdNV)
        {
            var Nhanvien = db.NhanViens.Where(i=>i.IdNV==IdNV).Include(i=>i.ChamCongs).FirstOrDefault();
            return View(Nhanvien);
        }

        // POST: ChamCongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCC,NgayChamCong,IdNV")] ChamCong chamCong)
        {
            if (ModelState.IsValid)
            {
                db.ChamCongs.Add(chamCong);
                db.SaveChanges();
                if (Convert.ToBoolean(Session["isAdmin"]))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.IdNV = new SelectList(db.NhanViens, "IdNV", "HoTen", chamCong.IdNV);
            return View(chamCong);
        }

        // GET: ChamCongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = db.ChamCongs.Find(id);
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
        public ActionResult Edit([Bind(Include = "IdCC,NgayChamCong,IdNV")] ChamCong chamCong)
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = db.ChamCongs.Find(id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            return View(chamCong);
        }

        // POST: ChamCongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChamCong chamCong = db.ChamCongs.Find(id);
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
