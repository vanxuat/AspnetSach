using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sach_value
{
    public class sachvalue
    {
        public System.Guid id { get; set; }
        [Display(Name = "Tên Sách")]
        public string Tensach { get; set; }
        [Display(Name = "Tác Giả")]
        public string Tacgia { get; set; }
        
        [Display(Name = "Giá")]
        public decimal? Gia { get; set; }
        [Display(Name = "Số Trang")]
        public int?  SoTrang  { get; set; }
        [Display( Name = "Hình Ảnh")]
        public string HinhAnh { get; set; }
        [Display(Name = "Khổ")]
        public string Kho { get; set; }
        [Display(Name = "Nhà Xuất Bản")]
        public string NhaXuatBan { get; set; }
        [Display(Name = "Tên Tủ Sách")]
        public string TenTuSach { get; set; }
        [Display(Name = "Ngày Phát Hành")]
        public DateTime? NgayPhatHanh { get; set; }
        public System.Guid? idtusach { get; set; }
    }
}
