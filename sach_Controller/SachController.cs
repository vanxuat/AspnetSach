using sach_model;
using Sach_value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sach_Controller
{
    public class SachController : BaseController<sachvalue>
    {
        private sachModel SachModel = null;


        public SachController()
        {
            SachModel = new sachModel();

        }


        public override bool InsertElement(sachvalue ot)
        {
            return SachModel.InsertElement(ot);
        }

        public override List<sachvalue> getElements()
        {
            return SachModel.getElements();
        }
        public bool XoaSachTheoID(Guid id)
        {
            return SachModel.XoaSachTheoID(id);
        }

        public bool SuaSach(sachvalue s)
        {
            return SachModel.SuaSach(s);
        }
        public sachvalue LaySachTheoID(Guid id)
        {
            return SachModel.LaySachTheoID(id);
        }
        public List<sachvalue> DanhsachPTrang(int batdau, int soluong)
        {
            return SachModel.DanhsachPTrang(batdau, soluong);
        }

        public List<sachvalue> LsachtheoTusach(int batdau, int soluong, Guid ID)
        {
            return SachModel.LsachtheoTusach(batdau, soluong, ID);
        }
        public int TongSoSach()
        {
            return SachModel.TongSoSach();
        }


        public List<sachvalue> LaySachTheoIDTPhanTrang(Guid IDTuSach, int batdau, int soluong)
        {
            return SachModel.LaySachTheoIDTPhanTrang(IDTuSach, batdau, soluong);
        }

        public List<sachvalue> LaySachTheoIDTu(Guid ID)
        {
            return SachModel.LaySachTheoIDTu(ID);
        }
    }
}
