create database QuanLySach
go
use QuanLySach


go


create table Users(
	id uniqueidentifier primary key,
	nguoidung char(50),
	 matkhau char(200),
	 email char(50),
	 dienthoai char(12),
	 hinhanh nvarchar(200),
	 Quyen int ,
	 GoogleID nvarchar(100),
	 FaceBookID nvarchar(100)
)

go

create table Sach(
	id uniqueidentifier primary key,
	Tensach nvarchar(50),
	TacGia nvarchar(50),
	Gia decimal(10,2),
	sotrang int,
	hinhanh nchar(200),
	kho char(50),
	nhaxuatban nvarchar(50),
	tusach uniqueidentifier,
  
)
go

ALTER TABLE Sach
ADD NgayPhatHanh date; 

go

create table TuSach
(
	id uniqueidentifier primary key  ,
	Tentusach nvarchar(100),
)

go

create table DonHang
(
	IDonHang uniqueidentifier  primary key ,
	NgayDatHang Date,
	IDNguoiMua uniqueidentifier,
	TongTien decimal(10,2),

)


go
create table GioHang
(
	id uniqueidentifier primary key ,
	IDDonHag uniqueidentifier,
	sachid uniqueidentifier,
	TamTinh decimal(10,2) ,
	soluong int,

)

go


alter table Sach add constraint FK_Sach_tusach foreign key (tusach) references TuSach(id) ON DELETE SET NULL  ON UPDATE CASCADE
alter table GioHang add constraint  FK_GioHang_DonHang foreign key (IDDonHag) references DonHang(IDonHang) on delete CASCADE
alter table GioHang add constraint FK_GioHang_Sach foreign key(sachid) references Sach(id)on delete CASCADE ON UPDATE CASCADE
alter table DonHang add constraint FK_DonHang_User foreign key(IDNguoiMua) references Users(id) on delete CASCADE ON UPDATE CASCADE
go
--Thêm giỏ hàng
create proc ThemgioHang
	@id uniqueidentifier  ,
	@IDDonHag uniqueidentifier,
	@sachid uniqueidentifier,
	@TamTinh decimal(10,2) ,
	@soluong int

as
begin

insert into dbo.GioHang(id,IDDonHag,sachid,soluong,TamTinh)
values
(
	@id,
	@IDDonHag,
	@sachid,
	@soluong,
	@TamTinh
)

end

go

--Xóa Sản Phẩm Trong Giỏ Hàng

create proc XoaSpTrogGioHang
@IdGioHang uniqueidentifier
as
begin
	delete dbo.GioHang where id=@IdGioHang
end


go
--Update so luong va so tiền
create proc UpdateSoluongGioHang
@idGioHang uniqueidentifier,
@soluong int,
@TamTinh decimal(10,2)
as
begin
update dbo.GioHang set soluong=@soluong,TamTinh=@TamTinh where id=@idGioHang

end
go
--Thêm Đơn Hàng
create proc ThemDonHang
	@IDonHang uniqueidentifier ,
	@NgayDatHang Date,
	@IDNguoiMua uniqueidentifier,
	@TongTien decimal(10,2)
as
begin
	insert dbo.DonHang(IDonHang,IDNguoiMua,NgayDatHang,TongTien)
	values
	(
		@IDonHang,
		@IDNguoiMua,
		@NgayDatHang,
		@TongTien
	)

end

go
--update Đơn hàng
create proc UpdateDonHang
@IDonHang uniqueidentifier ,
@TongTien decimal(10,2)
as 
begin
	update dbo.DonHang set TongTien=@TongTien where IDonHang=@IDonHang
end
go

--tổng tiền

create proc TongTien
@IDDonHang uniqueidentifier
as
begin
	select Sum(GH.TamTinh) as 'TongTien' from dbo.DonHang DH Join dbo.GioHang GH on GH.IDDonHag=DH.IDonHang where DH.IDonHang=@IDDonHang

end

--Lấy ra thông tin giỏ hàng
alter proc LayGioHang
@IDDonHag uniqueidentifier
as
begin
	select GH.id,GH.IDDonHag,GH.soluong,GH.TamTinh,GH.sachid as 'IDSach',S.Gia,S.hinhanh,S.Tensach from dbo.GioHang GH join dbo.Sach S on S.id =GH.sachid where GH.IDDonHag=@IDDonHag 
end


go

create proc KiemTraTaiKhoanTrongDonHang
@IDUser uniqueidentifier
as 
begin
	select * from dbo.DonHang  Where DonHang.IDNguoiMua=@IDUser
end






go
--Kết thúc phần giỏ hàng
create proc ThemNguoiDung
	 @nguoidung char(50),
	 @matkhau char(200),
	 @email char(50),
	 @dienthoai char(12),
	 @Quyen int 
as 
begin
	insert into dbo.Users(id,nguoidung,matkhau,email,dienthoai,Quyen)
	values
	(
		NEWID(),
		@nguoidung,
		@matkhau,
		@email,
		@dienthoai,
		@Quyen
	)

end

go

create proc ThemNguoiDungKhach
	@id uniqueidentifier,
	 @nguoidung char(50),
	 @matkhau char(200),
	 @email char(50),
	 @dienthoai char(12),
	 @Quyen int 
as
begin
	insert into dbo.Users(id,nguoidung,matkhau,email,dienthoai,Quyen)
	values(
		@id,
		@nguoidung,
		@matkhau,
		@email,
		@dienthoai,
		@Quyen
	)
end

go


create proc UpdateQuenUser
@id uniqueidentifier
as
begin
	update dbo.Users set Quyen=1 where id=@id
end


go
create proc dangnhapGoogle
	 @email char(50),
	 @hinhanh nvarchar(200),
	 @GoogleID nvarchar(100)
as
begin
	insert dbo.Users(id,hinhanh,GoogleID)
	values
	(
		NEWID(),
		@hinhanh,
		@GoogleID

	)

end
go

create proc KiemTraTaiKhoanGoogle
 @GoogleID nvarchar(100)
as
begin
	select * from dbo.Users where GoogleID=@GoogleID

end
go

create proc Kiemtrataikhoan
	@nguoidung char(50),
	 @matkhau char(200)
as
begin
	select * from dbo.Users where nguoidung=@nguoidung and matkhau=@matkhau
end

go

create proc KiemTraTkDangKi
@nguoiduung char(50)
as
begin
	select nguoidung from dbo.Users where dbo.Users.nguoidung like '%'+ @nguoiduung 
end




go

create proc Update_User
	@id uniqueidentifier,
	 @matkhau char(200),
	 @email char(50),
	 @dienthoai char(12),
	 @hinhanh nvarchar(200)
	
as
begin
	update dbo.Users set matkhau=@matkhau,email=@email,dienthoai=@dienthoai,hinhanh=@hinhanh where id=@id
end

go


create proc Update_Taikhoan
	@id uniqueidentifier,

	 @email char(50),
	 @dienthoai char(12)
as
begin
	update dbo.Users set dienthoai=@dienthoai,email=@email where id=@id
	
end
go

create proc DoiMat_Khau
	@id uniqueidentifier,
	 @matkhau char(200)
as
begin
	update dbo.Users set matkhau=@matkhau where id=@id
end
go

create proc Update_HinhAh
@id uniqueidentifier,
 @hinhanh nvarchar(200)
as
begin
	update dbo.Users set hinhanh=@hinhanh where id=@id
end
go






create proc XoaTaiKhoan
	@ID uniqueidentifier
as
begin
	delete from Users where id=@ID
	
end


go


create proc ThemTuSach
	@Tentusach nvarchar(100)
as
begin
	insert into dbo.TuSach(id,Tentusach)
	values
	(
		NEWID(),
		@Tentusach
	)
end

go

create proc LayTuSach
as
begin
	select * from dbo.TuSach
end

go

create proc LauTuSachID
	@id uniqueidentifier
	as
	begin
		select * from dbo.TuSach where TuSach.id=@id
	end

go
create proc XoaTuSach

	@id uniqueidentifier
	as
	begin
		delete from dbo.TuSach where TuSach.id=@id
	end


go

create proc SuaTuSach
	@id uniqueidentifier,
	@Tentusach nvarchar(100)
	as
	begin
		update dbo.TuSach set Tentusach=@Tentusach where id=@id
	end


go

create proc LaySachTheoTuS
@idtusach uniqueidentifier,
@start int,
@soluong int
as
begin
	select * from ( select S.*,ROW_NUMBER() over(order by S.Tensach desc ) as RC from dbo.Sach S join dbo.TuSach TS on TS.id=S.tusach where TS.id=@idtusach)as BM
	where BM.RC>@start and BM.RC<=@start+@soluong

end

go

create proc LaySachTheoIDTu
@idtusach uniqueidentifier
as
begin
	select * from dbo.Sach where tusach=@idtusach
end

go

create proc LaySachTuID  


go
create proc ThemSach
	@Tensach nvarchar(50),
	@TacGia nvarchar(50),
	@Gia decimal(10,2),
	@sotrang int,
	@hinhanh nchar(200),
	@kho char(50),
	@nhaxuatban nvarchar(50),
	@tusach uniqueidentifier,
	 @NgayPhatHanh date
as
 begin
 insert into dbo.Sach(id,Tensach,TacGia,Gia,sotrang,hinhanh,kho,nhaxuatban,tusach, NgayPhatHanh)
 values
 (
	NEWID(),
	@Tensach,
	@TacGia,
	@Gia,
	@sotrang,
	@hinhanh,
	@kho,
	@nhaxuatban,
	@tusach,
	@NgayPhatHanh

 )

 end




 go


create proc LayDssach
as
begin
	select s.id,s.Tensach,s.TacGia,s.Gia,s.sotrang,s.hinhanh,s.kho,s.nhaxuatban,s.tusach,ts.Tentusach,s.NgayPhatHanh from dbo.Sach  s left join dbo.TuSach ts  on s.tusach=ts.id 
end

go



create proc DanhSachTheoID
@id uniqueidentifier
as
begin
	select * from dbo.Sach where Sach.id=@id

end
go


create proc XoaSach
@id uniqueidentifier
as
begin
	delete from dbo.Sach where Sach.id=@id
end
go

create proc LaysachID
@id uniqueidentifier
as
begin
	select * from dbo.Sach where Sach.id=@id
end


go
create proc SuaSach
	@id uniqueidentifier,
	@Tensach nvarchar(50),
	@TacGia nvarchar(50),
	@Gia decimal(10,2),
	@sotrang int,
	@hinhanh nchar(200),
	@kho char(50),
	@nhaxuatban nvarchar(50),
	@NgayPhatHanh date,
	@tusach uniqueidentifier
as
begin
	update dbo.Sach 
	set Tensach=@Tensach,TacGia=@TacGia,Gia=@Gia,sotrang=@sotrang,hinhanh=@hinhanh,kho=@kho,nhaxuatban=@nhaxuatban,tusach=@tusach,NgayPhatHanh=@NgayPhatHanh where Sach.id=@id

end

go

create proc DanhSachTBSach
@batdau int,
@soluong int
as
begin
	select * from (select *,ROW_NUMBER() over(ORDER BY Gia desc ) as RC  from dbo.Sach) Danhsach where Danhsach.RC >@batdau and Danhsach.RC<= (@batdau+@soluong)

end
go

create proc TimKiemTheoTuSach
@batdau int,
@soluong int,
@IDtusach uniqueidentifier
as
begin
	select * from  (select *,ROW_NUMBER() over(order by  Gia desc) as RC  from dbo.Sach S where S.tusach=@IDtusach ) DS where RC >@batdau and RC <=@batdau+@soluong
end
go

create proc TongSoSach
as
begin

	select COUNT(*) as soluong from dbo.Sach

end

go


select * from dbo.DonHang

select * from dbo.GioHang

select * from dbo.Users
                                                      