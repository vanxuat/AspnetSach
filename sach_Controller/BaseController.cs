using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sach_Controller
{
    public class BaseController<T>
    {
        public virtual List<T> getElements() { return null; }
        public virtual T getElementById(object id) { return default(T); }
        public virtual T getElementById(T ot) { return default(T); }
        public virtual T CheckElement(T ot) { return default(T); }
        public virtual List<T> CheckElementById(object id) { return null; }
        public virtual List<T> CheckElementByTime(DateTime dtStartTime,
                                        DateTime dtEndTime)
        { return null; }
        public virtual bool InsertElement(T ot) { return true; }
        public virtual bool InsertUpdateElement(T ot) { return true; }
        public virtual bool UpdateElement(T ot) { return true; }
        public virtual bool DeleteElement(T ot) { return true; }
    }
}
