using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sach_value
{
    public class DonHangValue
    {
        public Guid IdDonHang { get; set; }

        public Guid? IdNguoiMua { get; set; }

        public DateTime? NgayDatHang { get; set; }

        public Decimal? TongTien { get; set; }
    }
}
