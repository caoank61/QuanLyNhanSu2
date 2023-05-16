Create database QuanLy
use QuanLy

Create table PhongBan(
	IdPB int primary key not null identity (1,1),
	TenPhong nvarchar (50),
	SDT varchar (10),
);
Create table ChucVu (
	IdCV int primary key not null identity (1,1),
	TenCV nvarchar (20),
);

Create table NhanVien (
	IdNV int primary key not null identity (1,1),
	HoTen nvarchar (50),
	Email varchar (100),
	Password varchar (100),
	IsAdmin bit,
	SDT varchar (10),
	GioiTinh nvarchar (3),
	NgaySinh date,
	QueQuan nvarchar (200),
	DanToc nvarchar (20),
	ChuyenNganh nvarchar (50),
	IdPB int,
	IdCV int,
	TrinhDoHV nvarchar (20),
	LuongCB float,
	CONSTRAINT fk_PhongBan foreign key (IdPB) references PhongBan (IdPB),
	CONSTRAINT fk_ChucVu foreign key (IdCV) references ChucVu (IdCV),
);
Create table ChamCong (
	IdCC int primary key not null identity (1,1),
	NgayChamCong date,
	IdNV int,
	CONSTRAINT fk_NhanVienCC foreign key (IdNV) references NhanVien (IdNV), 
);
Create table HopDong (
	IdHD int primary key not null identity (1,1),
	IdNV int,
	LoaiHD nvarchar (100),
	TuNgay date,
	DenNgay date,
	CONSTRAINT fk_NhanVienHD foreign key (IdNV) references NhanVien (IdNV),
);
/*
drop table HopDong
drop table ChamCong
drop table NhanVien
drop table PhongBan
drop table ChucVu
*/

create proc sp_TongNgayCong(
		@IdNV int,
		@ThangCong int
)
as
SELECT COUNT(*) AS NgayCong FROM ChamCong where MONTH(NgayChamCong)= @ThangCong and IdNV = @IdNV GROUP BY MONTH(NgayChamCong)

create proc sp_TinhLuong (
	@IdNV int ,
	@ThangCong int
)
as
begin 
	declare @Luong float ,@NgayCong int
	set @NgayCong = (SELECT COUNT(*) AS NgayCong FROM ChamCong where MONTH(NgayChamCong)= @ThangCong and IdNV = @IdNV GROUP BY MONTH(NgayChamCong))
	set @Luong = (select LuongCB/26 from NhanVien where IdNV = @IdNV) * @NgayCong
	select Round(@Luong,3) as TongLuong
end

-- dữ liệu đăng nhập
--1	Nguyễn Văn An	nguyenvanan1@gmail.com	8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92	True	0987564891	Nam	2002-08-04	Thành Phố Hồ Chí Minh	Kinh	Công Nghệ Thông Tin 	1	1	Đại Học	10000000
