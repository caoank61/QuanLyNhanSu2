Create database DuLieuQuanLy
use DuLieuQuanLy

Create table PhongBan(
	IdPB int primary key not null,
	TenPhong nvarchar (50),
	SDT varchar (10),
);
Create table ChucVu (
	IdCV int primary key not null,
	TenCV nvarchar (20)
);
Create table NhanVien (
	IdNV int primary key not null,
	HoTen nvarchar (50),
	Email varchar (100),
	SDT varchar (10),
	GioiTinh nvarchar (3),
	NgaySinh date,
	QueQuan nvarchar (200),
	DanToc nvarchar (20),
	ChuyenNganh nvarchar (50),
	IdPB int,
	IdCV int,
	--NganHang varchar (20),
	--STK varchar (12),
	--IdTDHV int,
	TrinhDoHV nvarchar (20),
	HeSoLuong float,
	LuongCB float,
	TongLuong float,
	CONSTRAINT fk_PhongBan foreign key (IdPB) references PhongBan (IdPB),
	CONSTRAINT fk_ChucVu foreign key (IdCV) references ChucVu (IdCV),
	--CONSTRAINT fk_TDHV foreign key (IdPB) references TrinhDoHocVan (IdTDHV),
);
Create table ChamCong (
	NgayChamCong date,
	IdNV int,
	TongNgayCong int,
	CONSTRAINT fk_NhanVien foreign key (IdNV) references NhanVien (IdNV), 
);
drop table NhanVien
drop table PhongBan
drop table ChucVu
drop table TrinhDoHocVan