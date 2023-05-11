using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           return View();
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
            var tk = "adminns";
            var mk = "ns.123456";
            if (TaiKhoan == tk && MatKhau == mk) { return Redirect("~/Home/Index"); }
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