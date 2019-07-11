using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sach_value
{
    public class ThongTinGioHang
    {
        public Guid  IDGioHang { get; set; }

        public Guid? IDDonHang { get; set; }
        [Display(Name = "Số Lượng Sách")]
        public int? SoLuong { get; set; }
        [Display(Name = "Tạm Tính")]
        public decimal?  TamTinh { get; set; }

        public Guid? IdSach { get; set; }
        [Display(Name = "Giá Sách")]
        public decimal? Gia { get; set; }
        [Display(Name = "Hình Sách")]
        public string Hinhanh { get; set; }

        [Display(Name = "Tên Sách")]
        public string TenSach { get; set; }

    }
}
