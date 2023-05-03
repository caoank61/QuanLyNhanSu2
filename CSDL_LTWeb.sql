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
	TrinhDoHV nvarchar (20),
	HeSoLuong float,
	LuongCB float,
	CONSTRAINT fk_PhongBan foreign key (IdPB) references PhongBan (IdPB),
	CONSTRAINT fk_ChucVu foreign key (IdCV) references ChucVu (IdCV),
);
Create table ChamCong (
	NgayChamCong date,
	IdNV int,
	CONSTRAINT fk_NhanVienCC foreign key (IdNV) references NhanVien (IdNV), 
);
Create table HopDong (
	IdHD int primary key not null,
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


create trigger Tr_ThangCong on ChamCong
for insert
as	
	begin
		declare @IdNV int,@NgayChamCong date
		select @IdNV = i.IdNV , @NgayChamCong = i.NgayChamCong from inserted i
		begin
		update ChamCong
		set ThangCong = (SELECT MONTH(NgayChamCong) FROm inserted  )
		where IdNV = @IdNV and NgayChamCong = @NgayChamCong
		end
	end

create trigger Tr_NgayCong on ChamCong
after insert
as	
	begin
		declare @IdNV int,@ThangCong int
		select @IdNV = i.IdNV ,@ThangCong = c.ThangCong from inserted i , ChamCong c where c.IdNV = i.IdNV
		begin
		update NhanVien
		SELECT NgayCong COUNT(*) FROM ChamCong GROUP BY MONTH(NgayChamCong)
		where IdNV = @IdNV 
		end
	end


insert into NhanVien (IdNV,HoTen,Email,SDT,GioiTinh,NgaySinh,QueQuan,DanToc,ChuyenNganh,IdPB,IdCV,TrinhDoHV,HeSoLuong,LuongCB) values (1001,N'Nguyễn Văn A','nguyena1001@gmail.com','0988775511',N'Nam','02-02-2002',N'Thành Phố Hồ Chí Minh',N'Kinh',N'Công Nghệ Thông Tin',2001,3001,N'Đại Học',2000000,2);


insert into ChucVu (IdCV,TenCV) values (3001,N'Quản Lý');
insert into PhongBan (IdPB,TenPhong,SDT) values (2001,N'Kế Toán','0998856421');
insert into NhanVien (IdNV,HoTen,Email,SDT,GioiTinh,NgaySinh,QueQuan,DanToc,ChuyenNganh,IdPB,IdCV,TrinhDoHV,HeSoLuong,LuongCB) values (1001,N'Nguyễn Văn A','nguyena1001@gmail.com','0988775511',N'Nam','2002-02-02',N'Hồ Chí Minh',N'Kinh',N'Công Nghệ Thông Tin',2001,3001,N'Đại học',2,10000000);
insert into HopDong (IdHD,IdNV,LoaiHD,TuNgay,DenNgay) values (4001,1001,N'1 Năm','05-03-2010','05-03-2011');
insert into ChamCong (IdNV,NgayChamCong) values (1001,'2023-03-03');
insert into ChamCong (IdNV,NgayChamCong) values (1001,'2023-03-02');
insert into ChamCong (IdNV,NgayChamCong) values (1001,'2023-03-04');
insert into ChamCong (IdNV,NgayChamCong) values (1001,'2023-03-05');
insert into ChamCong (IdNV,NgayChamCong) values (1001,'2023-04-02');
insert into ChamCong (IdNV,NgayChamCong) values (1001,'2023-04-05');


delete from ChamCong
drop trigger Tr_ThangCong
drop trigger Tr_NgayCong

select COUNT(DAY(NgayChamCong)) from ChamCong where MONTH(NgayChamCong) != 02 group by IdNV

select * from ChamCong
Select * from NhanVien

SELECT IdNV ,(MONTH(NgayChamCong)) AS month, COUNT(*) AS numberday

FROm ChamCong

GROUP BY MONTH(NgayChamCong),IdNV

ORDER BY MONTH(NgayChamCong) ASC

SELECT COUNT(*) AS numberday FROM ChamCong GROUP BY MONTH(NgayChamCong)

SELECT MONTH(NgayChamCong) FROm ChamCong GROUP BY MONTH(NgayChamCong)*/

-- PROC TÍNH SỐ NGÀY CÔNG TỪ MÃ NHÂN VIÊN VÀ THÁNG LÀM CỦA NHÂN VIÊN ĐƯỢC NHẬP TỪ BÀN PHÍM
create proc sp_TongNgayCong(
		@IdNV int,
		@ThangCong int
)
as
SELECT COUNT(*) AS NgayCong FROM ChamCong where MONTH(NgayChamCong)= @ThangCong and IdNV = @IdNV GROUP BY MONTH(NgayChamCong)


DROP PROC sp_TongNgayCong
sp_TongNgayCong 1001,4

-- PROC TÍNH LƯƠNG CỦA NHÂN VIÊN 
create proc sp_TinhLuong (
	@IdNV int ,
	@ThangCong int
)
as
begin 
	declare @Luong float ,@NgayCong int
	set @NgayCong = (SELECT COUNT(*) AS NgayCong FROM ChamCong where MONTH(NgayChamCong)= @ThangCong and IdNV = @IdNV GROUP BY MONTH(NgayChamCong))
	set @Luong = (select HeSoLuong*LuongCB/26 from NhanVien where IdNV = @IdNV) * @NgayCong
	select Round(@Luong,3) as TongLuong
end

drop proc sp_TinhLuong

sp_TinhLuong 1001,3
	


