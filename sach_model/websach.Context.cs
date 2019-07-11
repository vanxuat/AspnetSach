﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sach_model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QuanLySachEntities : DbContext
    {
        public QuanLySachEntities()
            : base("name=QuanLySachEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TuSach> TuSaches { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
    
        public virtual ObjectResult<Kiemtrataikhoan_Result> Kiemtrataikhoan(string nguoidung, string matkhau)
        {
            var nguoidungParameter = nguoidung != null ?
                new ObjectParameter("nguoidung", nguoidung) :
                new ObjectParameter("nguoidung", typeof(string));
    
            var matkhauParameter = matkhau != null ?
                new ObjectParameter("matkhau", matkhau) :
                new ObjectParameter("matkhau", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Kiemtrataikhoan_Result>("Kiemtrataikhoan", nguoidungParameter, matkhauParameter);
        }
    
        public virtual int ThemNguoiDung(string nguoidung, string matkhau, string email, string dienthoai, Nullable<int> quyen)
        {
            var nguoidungParameter = nguoidung != null ?
                new ObjectParameter("nguoidung", nguoidung) :
                new ObjectParameter("nguoidung", typeof(string));
    
            var matkhauParameter = matkhau != null ?
                new ObjectParameter("matkhau", matkhau) :
                new ObjectParameter("matkhau", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var dienthoaiParameter = dienthoai != null ?
                new ObjectParameter("dienthoai", dienthoai) :
                new ObjectParameter("dienthoai", typeof(string));
    
            var quyenParameter = quyen.HasValue ?
                new ObjectParameter("Quyen", quyen) :
                new ObjectParameter("Quyen", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ThemNguoiDung", nguoidungParameter, matkhauParameter, emailParameter, dienthoaiParameter, quyenParameter);
        }
    
        public virtual int Update_User(Nullable<System.Guid> id, string matkhau, string email, string dienthoai, string hinhanh)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var matkhauParameter = matkhau != null ?
                new ObjectParameter("matkhau", matkhau) :
                new ObjectParameter("matkhau", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var dienthoaiParameter = dienthoai != null ?
                new ObjectParameter("dienthoai", dienthoai) :
                new ObjectParameter("dienthoai", typeof(string));
    
            var hinhanhParameter = hinhanh != null ?
                new ObjectParameter("hinhanh", hinhanh) :
                new ObjectParameter("hinhanh", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Update_User", idParameter, matkhauParameter, emailParameter, dienthoaiParameter, hinhanhParameter);
        }
    
        public virtual int XoaTaiKhoan(Nullable<System.Guid> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("XoaTaiKhoan", iDParameter);
        }
    
        public virtual int dangnhapGoogle(string email, string hinhanh, string googleID)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var hinhanhParameter = hinhanh != null ?
                new ObjectParameter("hinhanh", hinhanh) :
                new ObjectParameter("hinhanh", typeof(string));
    
            var googleIDParameter = googleID != null ?
                new ObjectParameter("GoogleID", googleID) :
                new ObjectParameter("GoogleID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dangnhapGoogle", emailParameter, hinhanhParameter, googleIDParameter);
        }
    
        public virtual ObjectResult<KiemTraTaiKhoanGoogle_Result> KiemTraTaiKhoanGoogle(string googleID)
        {
            var googleIDParameter = googleID != null ?
                new ObjectParameter("GoogleID", googleID) :
                new ObjectParameter("GoogleID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<KiemTraTaiKhoanGoogle_Result>("KiemTraTaiKhoanGoogle", googleIDParameter);
        }
    
        public virtual int DoiMat_Khau(Nullable<System.Guid> id, string matkhau)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var matkhauParameter = matkhau != null ?
                new ObjectParameter("matkhau", matkhau) :
                new ObjectParameter("matkhau", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DoiMat_Khau", idParameter, matkhauParameter);
        }
    
        public virtual int Update_HinhAh(Nullable<System.Guid> id, string hinhanh)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var hinhanhParameter = hinhanh != null ?
                new ObjectParameter("hinhanh", hinhanh) :
                new ObjectParameter("hinhanh", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Update_HinhAh", idParameter, hinhanhParameter);
        }
    
        public virtual int Update_Taikhoan(Nullable<System.Guid> id, string email, string dienthoai)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var dienthoaiParameter = dienthoai != null ?
                new ObjectParameter("dienthoai", dienthoai) :
                new ObjectParameter("dienthoai", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Update_Taikhoan", idParameter, emailParameter, dienthoaiParameter);
        }
    
        public virtual ObjectResult<LayDssach_Result> LayDssach()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LayDssach_Result>("LayDssach");
        }
    
        public virtual ObjectResult<LayTuSach_Result> LayTuSach()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LayTuSach_Result>("LayTuSach");
        }
    
        public virtual int ThemSach(string tensach, string tacGia, Nullable<decimal> gia, Nullable<int> sotrang, string hinhanh, string kho, string nhaxuatban, Nullable<System.Guid> tusach, Nullable<System.DateTime> ngayPhatHanh)
        {
            var tensachParameter = tensach != null ?
                new ObjectParameter("Tensach", tensach) :
                new ObjectParameter("Tensach", typeof(string));
    
            var tacGiaParameter = tacGia != null ?
                new ObjectParameter("TacGia", tacGia) :
                new ObjectParameter("TacGia", typeof(string));
    
            var giaParameter = gia.HasValue ?
                new ObjectParameter("Gia", gia) :
                new ObjectParameter("Gia", typeof(decimal));
    
            var sotrangParameter = sotrang.HasValue ?
                new ObjectParameter("sotrang", sotrang) :
                new ObjectParameter("sotrang", typeof(int));
    
            var hinhanhParameter = hinhanh != null ?
                new ObjectParameter("hinhanh", hinhanh) :
                new ObjectParameter("hinhanh", typeof(string));
    
            var khoParameter = kho != null ?
                new ObjectParameter("kho", kho) :
                new ObjectParameter("kho", typeof(string));
    
            var nhaxuatbanParameter = nhaxuatban != null ?
                new ObjectParameter("nhaxuatban", nhaxuatban) :
                new ObjectParameter("nhaxuatban", typeof(string));
    
            var tusachParameter = tusach.HasValue ?
                new ObjectParameter("tusach", tusach) :
                new ObjectParameter("tusach", typeof(System.Guid));
    
            var ngayPhatHanhParameter = ngayPhatHanh.HasValue ?
                new ObjectParameter("NgayPhatHanh", ngayPhatHanh) :
                new ObjectParameter("NgayPhatHanh", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ThemSach", tensachParameter, tacGiaParameter, giaParameter, sotrangParameter, hinhanhParameter, khoParameter, nhaxuatbanParameter, tusachParameter, ngayPhatHanhParameter);
        }
    
        public virtual int ThemTuSach(string tentusach)
        {
            var tentusachParameter = tentusach != null ?
                new ObjectParameter("Tentusach", tentusach) :
                new ObjectParameter("Tentusach", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ThemTuSach", tentusachParameter);
        }
    
        public virtual ObjectResult<DanhSachTheoID_Result> DanhSachTheoID(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DanhSachTheoID_Result>("DanhSachTheoID", idParameter);
        }
    
        public virtual int SuaSach(Nullable<System.Guid> id, string tensach, string tacGia, Nullable<decimal> gia, Nullable<int> sotrang, string hinhanh, string kho, string nhaxuatban, Nullable<System.DateTime> ngayPhatHanh, Nullable<System.Guid> tusach)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var tensachParameter = tensach != null ?
                new ObjectParameter("Tensach", tensach) :
                new ObjectParameter("Tensach", typeof(string));
    
            var tacGiaParameter = tacGia != null ?
                new ObjectParameter("TacGia", tacGia) :
                new ObjectParameter("TacGia", typeof(string));
    
            var giaParameter = gia.HasValue ?
                new ObjectParameter("Gia", gia) :
                new ObjectParameter("Gia", typeof(decimal));
    
            var sotrangParameter = sotrang.HasValue ?
                new ObjectParameter("sotrang", sotrang) :
                new ObjectParameter("sotrang", typeof(int));
    
            var hinhanhParameter = hinhanh != null ?
                new ObjectParameter("hinhanh", hinhanh) :
                new ObjectParameter("hinhanh", typeof(string));
    
            var khoParameter = kho != null ?
                new ObjectParameter("kho", kho) :
                new ObjectParameter("kho", typeof(string));
    
            var nhaxuatbanParameter = nhaxuatban != null ?
                new ObjectParameter("nhaxuatban", nhaxuatban) :
                new ObjectParameter("nhaxuatban", typeof(string));
    
            var ngayPhatHanhParameter = ngayPhatHanh.HasValue ?
                new ObjectParameter("NgayPhatHanh", ngayPhatHanh) :
                new ObjectParameter("NgayPhatHanh", typeof(System.DateTime));
    
            var tusachParameter = tusach.HasValue ?
                new ObjectParameter("tusach", tusach) :
                new ObjectParameter("tusach", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SuaSach", idParameter, tensachParameter, tacGiaParameter, giaParameter, sotrangParameter, hinhanhParameter, khoParameter, nhaxuatbanParameter, ngayPhatHanhParameter, tusachParameter);
        }
    
        public virtual int SuaTuSach(Nullable<System.Guid> id, string tentusach)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var tentusachParameter = tentusach != null ?
                new ObjectParameter("Tentusach", tentusach) :
                new ObjectParameter("Tentusach", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SuaTuSach", idParameter, tentusachParameter);
        }
    
        public virtual int XoaSach(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("XoaSach", idParameter);
        }
    
        public virtual int XoaTuSach(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("XoaTuSach", idParameter);
        }
    
        public virtual ObjectResult<LauTuSachID_Result> LauTuSachID(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LauTuSachID_Result>("LauTuSachID", idParameter);
        }
    
        public virtual ObjectResult<LaysachID_Result> LaysachID(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LaysachID_Result>("LaysachID", idParameter);
        }
    
        public virtual ObjectResult<DanhSachTBSach_Result> DanhSachTBSach(Nullable<int> batdau, Nullable<int> soluong)
        {
            var batdauParameter = batdau.HasValue ?
                new ObjectParameter("batdau", batdau) :
                new ObjectParameter("batdau", typeof(int));
    
            var soluongParameter = soluong.HasValue ?
                new ObjectParameter("soluong", soluong) :
                new ObjectParameter("soluong", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DanhSachTBSach_Result>("DanhSachTBSach", batdauParameter, soluongParameter);
        }
    
        public virtual ObjectResult<TimKiemTheoTuSach_Result> TimKiemTheoTuSach(Nullable<int> batdau, Nullable<int> soluong, Nullable<System.Guid> iDtusach)
        {
            var batdauParameter = batdau.HasValue ?
                new ObjectParameter("batdau", batdau) :
                new ObjectParameter("batdau", typeof(int));
    
            var soluongParameter = soluong.HasValue ?
                new ObjectParameter("soluong", soluong) :
                new ObjectParameter("soluong", typeof(int));
    
            var iDtusachParameter = iDtusach.HasValue ?
                new ObjectParameter("IDtusach", iDtusach) :
                new ObjectParameter("IDtusach", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TimKiemTheoTuSach_Result>("TimKiemTheoTuSach", batdauParameter, soluongParameter, iDtusachParameter);
        }
    
        public virtual ObjectResult<TongSoSach_Result> TongSoSach()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TongSoSach_Result>("TongSoSach");
        }
    
        public virtual ObjectResult<string> KiemTraTkDangKi(string nguoiduung)
        {
            var nguoiduungParameter = nguoiduung != null ?
                new ObjectParameter("nguoiduung", nguoiduung) :
                new ObjectParameter("nguoiduung", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("KiemTraTkDangKi", nguoiduungParameter);
        }
    
        public virtual int ThemNguoiDungKhach(Nullable<System.Guid> id, string nguoidung, string matkhau, string email, string dienthoai, Nullable<int> quyen)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var nguoidungParameter = nguoidung != null ?
                new ObjectParameter("nguoidung", nguoidung) :
                new ObjectParameter("nguoidung", typeof(string));
    
            var matkhauParameter = matkhau != null ?
                new ObjectParameter("matkhau", matkhau) :
                new ObjectParameter("matkhau", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var dienthoaiParameter = dienthoai != null ?
                new ObjectParameter("dienthoai", dienthoai) :
                new ObjectParameter("dienthoai", typeof(string));
    
            var quyenParameter = quyen.HasValue ?
                new ObjectParameter("Quyen", quyen) :
                new ObjectParameter("Quyen", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ThemNguoiDungKhach", idParameter, nguoidungParameter, matkhauParameter, emailParameter, dienthoaiParameter, quyenParameter);
        }
    
        public virtual int UpdateQuenUser(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateQuenUser", idParameter);
        }
    
        public virtual ObjectResult<LaySachTheoTuS_Result> LaySachTheoTuS(Nullable<System.Guid> idtusach, Nullable<int> start, Nullable<int> soluong)
        {
            var idtusachParameter = idtusach.HasValue ?
                new ObjectParameter("idtusach", idtusach) :
                new ObjectParameter("idtusach", typeof(System.Guid));
    
            var startParameter = start.HasValue ?
                new ObjectParameter("start", start) :
                new ObjectParameter("start", typeof(int));
    
            var soluongParameter = soluong.HasValue ?
                new ObjectParameter("soluong", soluong) :
                new ObjectParameter("soluong", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LaySachTheoTuS_Result>("LaySachTheoTuS", idtusachParameter, startParameter, soluongParameter);
        }
    
        public virtual ObjectResult<LaySachTheoIDTu_Result> LaySachTheoIDTu(Nullable<System.Guid> idtusach)
        {
            var idtusachParameter = idtusach.HasValue ?
                new ObjectParameter("idtusach", idtusach) :
                new ObjectParameter("idtusach", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LaySachTheoIDTu_Result>("LaySachTheoIDTu", idtusachParameter);
        }
    
        public virtual ObjectResult<LayGioHang_Result> LayGioHang(Nullable<System.Guid> iDDonHag)
        {
            var iDDonHagParameter = iDDonHag.HasValue ?
                new ObjectParameter("IDDonHag", iDDonHag) :
                new ObjectParameter("IDDonHag", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LayGioHang_Result>("LayGioHang", iDDonHagParameter);
        }
    
        public virtual int ThemDonHang(Nullable<System.Guid> iDonHang, Nullable<System.DateTime> ngayDatHang, Nullable<System.Guid> iDNguoiMua, Nullable<decimal> tongTien)
        {
            var iDonHangParameter = iDonHang.HasValue ?
                new ObjectParameter("IDonHang", iDonHang) :
                new ObjectParameter("IDonHang", typeof(System.Guid));
    
            var ngayDatHangParameter = ngayDatHang.HasValue ?
                new ObjectParameter("NgayDatHang", ngayDatHang) :
                new ObjectParameter("NgayDatHang", typeof(System.DateTime));
    
            var iDNguoiMuaParameter = iDNguoiMua.HasValue ?
                new ObjectParameter("IDNguoiMua", iDNguoiMua) :
                new ObjectParameter("IDNguoiMua", typeof(System.Guid));
    
            var tongTienParameter = tongTien.HasValue ?
                new ObjectParameter("TongTien", tongTien) :
                new ObjectParameter("TongTien", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ThemDonHang", iDonHangParameter, ngayDatHangParameter, iDNguoiMuaParameter, tongTienParameter);
        }
    
        public virtual int ThemgioHang(Nullable<System.Guid> id, Nullable<System.Guid> iDDonHag, Nullable<System.Guid> sachid, Nullable<decimal> tamTinh, Nullable<int> soluong)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var iDDonHagParameter = iDDonHag.HasValue ?
                new ObjectParameter("IDDonHag", iDDonHag) :
                new ObjectParameter("IDDonHag", typeof(System.Guid));
    
            var sachidParameter = sachid.HasValue ?
                new ObjectParameter("sachid", sachid) :
                new ObjectParameter("sachid", typeof(System.Guid));
    
            var tamTinhParameter = tamTinh.HasValue ?
                new ObjectParameter("TamTinh", tamTinh) :
                new ObjectParameter("TamTinh", typeof(decimal));
    
            var soluongParameter = soluong.HasValue ?
                new ObjectParameter("soluong", soluong) :
                new ObjectParameter("soluong", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ThemgioHang", idParameter, iDDonHagParameter, sachidParameter, tamTinhParameter, soluongParameter);
        }
    
        public virtual int UpdateDonHang(Nullable<System.Guid> iDonHang, Nullable<decimal> tongTien)
        {
            var iDonHangParameter = iDonHang.HasValue ?
                new ObjectParameter("IDonHang", iDonHang) :
                new ObjectParameter("IDonHang", typeof(System.Guid));
    
            var tongTienParameter = tongTien.HasValue ?
                new ObjectParameter("TongTien", tongTien) :
                new ObjectParameter("TongTien", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateDonHang", iDonHangParameter, tongTienParameter);
        }
    
        public virtual int UpdateSoluongGioHang(Nullable<System.Guid> idGioHang, Nullable<int> soluong, Nullable<decimal> tamTinh)
        {
            var idGioHangParameter = idGioHang.HasValue ?
                new ObjectParameter("idGioHang", idGioHang) :
                new ObjectParameter("idGioHang", typeof(System.Guid));
    
            var soluongParameter = soluong.HasValue ?
                new ObjectParameter("soluong", soluong) :
                new ObjectParameter("soluong", typeof(int));
    
            var tamTinhParameter = tamTinh.HasValue ?
                new ObjectParameter("TamTinh", tamTinh) :
                new ObjectParameter("TamTinh", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateSoluongGioHang", idGioHangParameter, soluongParameter, tamTinhParameter);
        }
    
        public virtual ObjectResult<KiemTraTaiKhoanTrongDonHang_Result> KiemTraTaiKhoanTrongDonHang(Nullable<System.Guid> iDUser)
        {
            var iDUserParameter = iDUser.HasValue ?
                new ObjectParameter("IDUser", iDUser) :
                new ObjectParameter("IDUser", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<KiemTraTaiKhoanTrongDonHang_Result>("KiemTraTaiKhoanTrongDonHang", iDUserParameter);
        }
    
        public virtual int XoaSpTrogGioHang(Nullable<System.Guid> idGioHang)
        {
            var idGioHangParameter = idGioHang.HasValue ?
                new ObjectParameter("IdGioHang", idGioHang) :
                new ObjectParameter("IdGioHang", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("XoaSpTrogGioHang", idGioHangParameter);
        }
    
        public virtual ObjectResult<TongTien_Result> TongTien(Nullable<System.Guid> iDDonHang)
        {
            var iDDonHangParameter = iDDonHang.HasValue ?
                new ObjectParameter("IDDonHang", iDDonHang) :
                new ObjectParameter("IDDonHang", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TongTien_Result>("TongTien", iDDonHangParameter);
        }
    }
}
