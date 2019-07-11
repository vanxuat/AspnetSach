using Sach_value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sach_model
{
    public class sachModel : BaseModel<sachvalue>
    {
        public override bool InsertElement(sachvalue ot)
        {
            var result = websach.ThemSach(ot.Tensach, ot.Tacgia, ot.Gia, ot.SoTrang, ot.HinhAnh, ot.Kho, ot.NhaXuatBan, ot.idtusach, ot.NgayPhatHanh);
            if (result == 1)
            {
                return true;
            }
            return false;

        }

        public override List<sachvalue> getElements()
        {
            var result = websach.LayDssach();
            List<sachvalue> listsach = new List<sachvalue>();
            foreach (var item in result)
            {
                sachvalue sach = new sachvalue()
                {
                    id = item.id,
                    Tensach = item.Tensach,
                    Gia = item.Gia,
                    SoTrang = item.sotrang,
                    Kho = item.kho,
                    NhaXuatBan = item.nhaxuatban,
                    Tacgia = item.TacGia,
                    HinhAnh = item.hinhanh,
                    idtusach = item.tusach,
                    TenTuSach = item.Tentusach

                };
                listsach.Add(sach);
            }
            return listsach;
        }


        public bool XoaSachTheoID(Guid id)
        {
            int n = websach.XoaSach(id);
            if (n == 0)
            {
                return false;
            }
            return true;
        }

        public bool SuaSach(sachvalue s)
        {
            int n = websach.SuaSach(s.id, s.Tensach, s.Tacgia, s.Gia, s.SoTrang, s.HinhAnh, s.Kho, s.NhaXuatBan, s.NgayPhatHanh, s.idtusach);
            if (n == 0)
            {
                return false;
            }
            return true;
        }

        public sachvalue LaySachTheoID(Guid id)
        {
            var sach = websach.LaysachID(id).SingleOrDefault();
            if (sach != null)
            {
                sachvalue sv = new sachvalue()
                {
                    id = sach.id,
                    Tensach = sach.Tensach,
                    Gia = sach.Gia,
                    HinhAnh = sach.hinhanh,
                    Kho = sach.kho,
                    NhaXuatBan = sach.nhaxuatban,
                    SoTrang = sach.sotrang,
                    Tacgia = sach.TacGia,
                    idtusach = sach.tusach,
                    NgayPhatHanh = sach.NgayPhatHanh

                };
                return sv;
            }
            return null;
        }

        public List<sachvalue> DanhsachPTrang(int batdau, int soluong)
        {

            var data = websach.DanhSachTBSach(batdau, soluong);
            if (data != null)
            {

                List<sachvalue> lsact = new List<sachvalue>();
                foreach (var item in data)
                {
                    sachvalue sac = new sachvalue()
                    {
                        id = item.id,
                        Tensach = item.Tensach,
                        Gia = item.Gia,
                        HinhAnh = item.hinhanh,
                        Kho = item.kho,
                        NgayPhatHanh = item.NgayPhatHanh,
                        NhaXuatBan = item.nhaxuatban,
                        idtusach = item.tusach
                    };
                    lsact.Add(sac);
                }
                return lsact;

            }

            return null;
        }

        public List<sachvalue> LsachtheoTusach(int batdau,int soluong, Guid ID)
        {
            var data = websach.TimKiemTheoTuSach(batdau, soluong, ID);

            if (data != null)
            {
                List<sachvalue> lsach = new List<sachvalue>();
                foreach (var item in data)
                {
                    sachvalue sa = new sachvalue()
                    {
                        id = item.id,
                        Tensach = item.Tensach,
                        Gia = item.Gia,
                        HinhAnh = item.hinhanh,
                        Kho = item.kho,
                        NgayPhatHanh = item.NgayPhatHanh,
                        NhaXuatBan = item.nhaxuatban,
                        idtusach = item.tusach
                    };
                    lsach.Add(sa);
                }
                return lsach;
            }


            return null;
        }


        public int TongSoSach()
        {
            var  data = websach.TongSoSach().SingleOrDefault();
            int solong = (int)data.soluong;

            return solong;
        }


        public List<sachvalue>LaySachTheoIDTPhanTrang(Guid IDTuSach,int batdau,int soluong)
        {
            var data = websach.LaySachTheoTuS(IDTuSach, batdau, soluong);

            if(data != null)
            {
                List<sachvalue> ListSach = new List<sachvalue>();

                foreach (var item in data)
                {
                    sachvalue sach = new sachvalue()
                    {
                        id = item.id,
                        Tensach = item.Tensach,
                        HinhAnh = item.hinhanh,
                        Gia = item.Gia,
                        Kho = item.kho,
                        NgayPhatHanh = item.NgayPhatHanh,
                        NhaXuatBan = item.nhaxuatban,
                        SoTrang = item.sotrang,
                        Tacgia = item.TacGia,
                        idtusach = item.tusach
                    };
                    ListSach.Add(sach);
                }
                
                return ListSach;
            }
            return null;
        } 

        public List<sachvalue> LaySachTheoIDTu(Guid ID)
        {
            List<sachvalue> Listsach = new List<sachvalue>();

            var data = websach.LaySachTheoIDTu(ID);

            if(data != null)
            {
                foreach (var item in Listsach)
                {
                    sachvalue sach = new sachvalue()
                    {
                        id = item.id,
                        Gia = item.Gia,
                        HinhAnh = item.HinhAnh,
                        NgayPhatHanh = item.NgayPhatHanh,
                        TenTuSach = item.TenTuSach,
                        NhaXuatBan = item.NhaXuatBan,
                        Kho = item.Kho,
                        Tacgia = item.Tacgia,
                        SoTrang = item.SoTrang,
                        idtusach = item.idtusach
                    };
                    Listsach.Add(sach);
                }
                return Listsach;
            }
            return null;
        }



    }
}
