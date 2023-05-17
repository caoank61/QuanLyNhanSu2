using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class Luong
    {
        public double TongLuong { get; set; }
        public int NgayCong { get; set; }
        public NhanVien nv { get; set; }
        public Luong(){ }
        public Luong(double TongLuong, int NgayCong, NhanVien nv) {
            this.TongLuong = TongLuong;
            this.NgayCong = NgayCong;
            this.nv = nv;
        }
    }
    

}