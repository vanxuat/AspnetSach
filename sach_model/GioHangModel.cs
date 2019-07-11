using Sach_value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sach_model
{
    public class GioHangModel
    {
        private QuanLySachEntities QuanLy = null;

        public GioHangModel()
        {
            QuanLy = new QuanLySachEntities();

        }

        public DonHangValue KiemTraTkTrongDonHang(Guid ID)
        {
            var data = QuanLy.KiemTraTaiKhoanTrongDonHang(ID).SingleOrDefault();
            if(data != null)
            {
                DonHangValue dh = new DonHangValue()
                {
                    IdDonHang = data.IDonHang,
                    IdNguoiMua = data.IDNguoiMua,
                    NgayDatHang = data.NgayDatHang,
                    TongTien = data.TongTien

                };
                return dh;
            }
            return null;
        }


        public List<ThongTinGioHang> DanhSachSpTrongGio(Guid IDDonHang)
        {
            var data = QuanLy.LayGioHang(IDDonHang);
            List<ThongTinGioHang> DanhsachSptrongGio = new List<ThongTinGioHang>();
            if(data != null)
            {
                foreach (var item in data)
                {
                    ThongTinGioHang GioHang = new ThongTinGioHang()
                    {
                        IDDonHang = item.IDDonHag,
                        IdSach = item.IDSach,
                        Gia = item.Gia,
                        Hinhanh = item.hinhanh,
                        IDGioHang = item.id,
                        SoLuong = item.soluong,
                        TamTinh = item.TamTinh,
                        TenSach=item.Tensach
                       
                    };
                    DanhsachSptrongGio.Add(GioHang);

                }

                return DanhsachSptrongGio;
            }
            return null;
        }

        public bool CapNhatDonHang(DonHangValue DH)
        {
            var data = QuanLy.UpdateDonHang(DH.IdDonHang, DH.TongTien);
            if(data != 0)
            {
                return true;
            }
            return false;
        }

        public bool ThemDonHang(DonHangValue DH)
        {
            var data = QuanLy.ThemDonHang(DH.IdDonHang, DH.NgayDatHang, DH.IdNguoiMua, DH.TongTien);
            if(data != 0)
            {
                return true;
            }
            return false;
        }


        public bool UpdateGiohang(GioHangValue Gh)
        {
            var data = QuanLy.UpdateSoluongGioHang(Gh.IdGioHang, Gh.Soluong, Gh.Tamtinh);
            if(data != 0)
            {
                return true;
            }
            return false;
        }

        public bool ThemGioHang(GioHangValue Gh)
        {
            var data = QuanLy.ThemgioHang(Gh.IdGioHang, Gh.IdDonHang,Gh.IdSach, Gh.Tamtinh, Gh.Soluong);
            if(data != 0)
            {
                return true;
            }
            return false;
        }


        public bool XoaSPGioHang(Guid IdGioHang)
        {
            int kq = QuanLy.XoaSpTrogGioHang(IdGioHang);

            if(kq != 0)
            {
                return true;
            }
            return false;


        }


        public decimal? TongTien(Guid IDDonHang)
        {
            var data = QuanLy.TongTien(IDDonHang).SingleOrDefault();

            return data.TongTien;



        }


    }
}
