using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Controllers
{
    public class NhanViensController : Controller
    {
        private Data db = new Data();

        // GET: NhanViens
        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.Include(n => n.ChucVu).Include(n => n.PhongBan);
            return View(nhanViens.ToList());
        }

        public ActionResult TinhLuong(int? ThangCong)
        {
            List<Luong> luong = new List<Luong>();
            double tinhluong = 0.0;
            int ngaycong = 0;
            var nhanViens = db.NhanViens.Include(n => n.ChucVu).Include(n => n.PhongBan).ToList();
            foreach(var nv in nhanViens)
            {
                tinhluong =  db.sp_TinhLuong(nv.IdNV, ThangCong).FirstOrDefault().GetValueOrDefault();
                ngaycong = db.sp_TongNgayCong(nv.IdNV, ThangCong).FirstOrDefault().GetValueOrDefault();
                luong.Add(new Luong(tinhluong, ngaycong, nv));
            }
            return View(luong);
        }
        // GET: NhanViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public ActionResult Create()
        {
            ViewBag.IdCV = new SelectList(db.ChucVus, "IdCV", "TenCV");
            ViewBag.IdPB = new SelectList(db.PhongBans, "IdPB", "TenPhong");
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNV,HoTen,Email,Password,IsAdmin,SDT,GioiTinh,NgaySinh,QueQuan,DanToc,ChuyenNganh,IdPB,IdCV,TrinhDoHV,LuongCB")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                nhanVien.Password = Helper.ComputeSha256Hash(nhanVien.Password);
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCV = new SelectList(db.ChucVus, "IdCV", "TenCV", nhanVien.IdCV);
            ViewBag.IdPB = new SelectList(db.PhongBans, "IdPB", "TenPhong", nhanVien.IdPB);
            return View(nhanVien);

        }

        // GET: NhanViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCV = new SelectList(db.ChucVus, "IdCV", "TenCV", nhanVien.IdCV);
            ViewBag.IdPB = new SelectList(db.PhongBans, "IdPB", "TenPhong", nhanVien.IdPB);
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNV,HoTen,Email,Password,IsAdmin,SDT,GioiTinh,NgaySinh,QueQuan,DanToc,ChuyenNganh,IdPB,IdCV,TrinhDoHV,LuongCB")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                //nhanVien.Password = Helper.ComputeSha256Hash(nhanVien.Password);
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                if (Convert.ToBoolean(Session["isAdmin"]))
                {
                    return RedirectToAction("Index");
                }else
                {
                    return RedirectToAction("Index", "Home");
                }
                    
            }
            ViewBag.IdCV = new SelectList(db.ChucVus, "IdCV", "TenCV", nhanVien.IdCV);
            ViewBag.IdPB = new SelectList(db.PhongBans, "IdPB", "TenPhong", nhanVien.IdPB);
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
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
