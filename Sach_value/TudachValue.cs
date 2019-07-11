using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sach_value
{
   public class TudachValue
    {
        public System.Guid ID { get; set; }
        [Display(Name = "Tên Tủ Sách")]
        public string TenTuSach { get; set; }
    }
}
