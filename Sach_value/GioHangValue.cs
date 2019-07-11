using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sach_value
{
   public class GioHangValue
    {
        public Guid IdGioHang { get; set; }

        public Guid? IdDonHang { get; set; }

        public Guid? IdSach { get; set; }

        public decimal? Tamtinh { get; set; }

        public int? Soluong { get; set; }
    }
}
