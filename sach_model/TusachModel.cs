using Sach_value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sach_model
{
    public class TusachModel:BaseModel<TudachValue>
    {
        public override bool InsertElement(TudachValue ot)
        {
            var resutl = websach.ThemTuSach(ot.TenTuSach);
            if (resutl == 1)
            {
                return true;
            }
            return false;

        }

        public override List<TudachValue> getElements()
        {
            var result = websach.LayTuSach();
         
            List<TudachValue> tusach = new List<TudachValue>();
            foreach (var item in result)
            {
                TudachValue value = new TudachValue()
                {
                    ID = item.id,
                    TenTuSach = item.Tentusach
                };
                tusach.Add(value);
            }

            return tusach;
        }

        public bool XoaTuSachTheoID(Guid id)
        {
            int n = websach.XoaTuSach(id);
            if (n == 0)
            {
                return false;
            }
            return true;
        }

        public bool SuaTuSach(TudachValue ts)
        {
            int n = websach.SuaTuSach(ts.ID, ts.TenTuSach);
            if (n == 0)
            {
                return false;
            }
            return true;
        }

        public TudachValue LayTuSachID(Guid ID)
        {
            var data = websach.LauTuSachID(ID).SingleOrDefault();
            if(data != null)
            {
                TudachValue ts = new TudachValue()
                {
                   ID=data.id,
                   TenTuSach=data.Tentusach
                };
                return ts;
            }
            return null;

        }
    }
}
