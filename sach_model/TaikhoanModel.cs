using Sach_value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sach_model
{
    public class TaikhoanModel:BaseModel<taikhoan>
    {
        public override bool InsertElement(taikhoan ot)
        {
            var result = websach.ThemNguoiDung(ot.nguoidung, ot.matkhau, ot.email, ot.dienthoai, 1);
            if (result == 1)
            {
                return true;
            }
            return false;
        }

        public override taikhoan CheckElement(taikhoan ot)
        {
            var result = websach.Kiemtrataikhoan(ot.nguoidung, ot.matkhau).SingleOrDefault();
            taikhoan tk = null;
            if(result != null)
            {
                tk = new taikhoan()
                {
                    id=result.id,
                    nguoidung=result.nguoidung,
                    dienthoai=result.dienthoai,
                    email=result.email,
                    matkhau=result.matkhau,
                    hinhanh=result.hinhanh,
                    FaceBookID=result.FaceBookID,
                    GoogleID=result.GoogleID,
                    Quyen=result.Quyen
                };
                return tk;
            }
            return null;
        }

        public bool logingoogle(taikhoan tk)
        {
            var result = websach.dangnhapGoogle(tk.email, tk.hinhanh, tk.GoogleID);
            if (result == 1)
            {
                return true;
            }
            return false;
        }

        public taikhoan CheckGoole(string googelid)
        {
            var resl = websach.KiemTraTaiKhoanGoogle(googelid).SingleOrDefault();
            taikhoan taik = null;

            if (resl != null)
            {
                taik = new taikhoan()
                {
                    id = resl.id,
                    GoogleID = resl.GoogleID,
                    email = resl.email,
                    hinhanh=resl.hinhanh
                    
                };
                return taik;
            }
            return null;
        }

        public  bool UpdateTaikhoan(taikhoan ot)
        {
            var result = websach.Update_Taikhoan(ot.id, ot.email, ot.dienthoai);
            if (result == 1)
            {
               return true;
            }
            return false;
        }

        public bool UpdateMatKhau(taikhoan ot)
        {
            var result = websach.DoiMat_Khau(ot.id, ot.matkhau);
            if (result == 1)
            {
                return true;
            }
            return false;
        }

        public bool UpdateHinhAnh(taikhoan ot)
        {
            var resut = websach.Update_HinhAh(ot.id, ot.hinhanh);
            if (resut == 1)
            {
                return true;
            }
            return false;
        }


        public bool KiemTraTenDangKi(string Ten)
        {
            var reault = websach.KiemTraTkDangKi(Ten).SingleOrDefault();

            if(reault != null)
            {
                return true;
            }
            return false;
        }

        public bool DangKiUserKhach(taikhoan tk)
        {
            var result = websach.ThemNguoiDungKhach(tk.id, tk.nguoidung, tk.matkhau, tk.email, tk.dienthoai, tk.Quyen);
            if(result != 0)
            {
                return true;
            }
            return false;
        }

        public bool CapNhatQuyen(Guid ID)
        {
            var resutt = websach.UpdateQuenUser(ID);
            if (resutt != 0)
            {
                return true;

            }
            return false;
        }
    }
}
