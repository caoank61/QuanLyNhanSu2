using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Controllers
{
    public class HomeController : Controller
    {
        private Data db = new Data();
        public ActionResult Index()
        {
            if (Session["user_id"] != null)
            {
                ViewBag.NV = db.NhanViens.AsQueryable().ToList().Count();
                ViewBag.PB = db.PhongBans.AsQueryable().ToList().Count();
                return View();
                //Lấy Thông tin user đăng nhập  db.NhanViens.Where(p => p.IdNV == Convert.ToInt32( Session["user_id"]));
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        //đăng nhập, đăng xuất
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string TaiKhoan, string MatKhau)
        {
            MatKhau = Helper.ComputeSha256Hash(MatKhau);
            var user = db.NhanViens.Where(p => p.Email == TaiKhoan).Where(p => p.Password == MatKhau).FirstOrDefault();
            if (user != null)
            {
                Session["user_id"] = user.IdNV;
                Session["HoTen_user"] = user.HoTen;
                Session["isAdmin"] = user.IsAdmin;//db.NhanViens.Where(p => p.IdNV == Convert.ToInt32(Session["user_id"]));
                return RedirectToAction("Index", "Home");
            }
            else ViewBag.error = "Thông tin đăng nhập không hợp lệ!!!";
            return View();

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}