using sach_model;
using Sach_value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sach_Controller
{
    public class GioHangController
    {
        private GioHangModel GioHang = null;
        public GioHangController()
        {
            GioHang = new GioHangModel();
        }

        public DonHangValue KiemTraTkTrongDonHang(Guid ID)
        {
            return GioHang.KiemTraTkTrongDonHang(ID);
        }

        public List<ThongTinGioHang> DanhSachSpTrongGio(Guid IDDonHang)
        {
            return GioHang.DanhSachSpTrongGio(IDDonHang);
        }

        public bool CapNhatDonHang(DonHangValue DH)
        {
            return GioHang.CapNhatDonHang(DH);
        }

        public bool ThemDonHang(DonHangValue DH)
        {
            return GioHang.ThemDonHang(DH);
        }

        public bool UpdateGiohang(GioHangValue Gh)
        {
            return GioHang.UpdateGiohang(Gh);
        }

        public bool ThemGioHang(GioHangValue Gh)
        {
            return GioHang.ThemGioHang(Gh);
        }
        public bool XoaSPGioHang(Guid IdGioHang)
        {
            return GioHang.XoaSPGioHang(IdGioHang);
        }

        public decimal? TongTien(Guid IDDonHang)
        {
            return GioHang.TongTien(IDDonHang);
        }
    }
}
