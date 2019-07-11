using sach_model;
using Sach_value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sach_Controller
{
    public class TusachController:BaseController<TudachValue>
    {
        private TusachModel TsModel = null;

        public TusachController()
        {
            TsModel = new TusachModel();
        }

        public override bool InsertElement(TudachValue ot)
        {
            return TsModel.InsertElement(ot); 
        }

        public override List<TudachValue> getElements()
        {
            return TsModel.getElements();
        }

        public bool XoaTuSachTheoID(Guid id)
        {
            return TsModel.XoaTuSachTheoID(id);
        }

        public bool SuaTuSach(TudachValue ts)
        {
            return TsModel.SuaTuSach(ts);
        }

        public TudachValue LayTuSachID(Guid ID)
        {
            return TsModel.LayTuSachID(ID);
        }
    }
}
