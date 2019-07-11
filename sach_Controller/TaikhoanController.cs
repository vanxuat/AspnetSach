using sach_model;
using Sach_value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sach_Controller
{
    public class TaikhoanController : BaseController<taikhoan>
    {
        private TaikhoanModel tk = null;
        public TaikhoanController()
        {
            tk = new TaikhoanModel();
        }
        public override bool InsertElement(taikhoan ot)
        {
            return tk.InsertElement(ot);
        }

        public override taikhoan CheckElement(taikhoan ot)
        {
            return tk.CheckElement(ot);
        }

        public bool DangNhapGoogle(taikhoan ot)
        {
            return tk.logingoogle(ot);
        }

        public taikhoan CheckGoole(string googelid)
        {
            return tk.CheckGoole(googelid);
        }

        public bool UpdateTaikhoan(taikhoan ot)
        {

            return tk.UpdateTaikhoan(ot);
        }

        public bool UpdateMatKhau(taikhoan ot)
        {
            return tk.UpdateMatKhau(ot);
        }

        public bool UpdateHinhAnh(taikhoan ot)
        {
            return tk.UpdateHinhAnh(ot);
        }
        public bool KiemTraTenDangKi(string Ten)
        {
            return tk.KiemTraTenDangKi(Ten);

        }
        public bool DangKiUserKhach(taikhoan ot)
        {
            return tk.DangKiUserKhach(ot);
        }
        public bool CapNhatQuyen(Guid ID)
        {
            return tk.CapNhatQuyen(ID);
        }

    }
}
