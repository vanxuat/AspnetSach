//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sach_model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            this.GioHangs = new HashSet<GioHang>();
        }
    
        public System.Guid id { get; set; }
        public string Tensach { get; set; }
        public string TacGia { get; set; }
        public Nullable<decimal> Gia { get; set; }
        public Nullable<int> sotrang { get; set; }
        public string hinhanh { get; set; }
        public string kho { get; set; }
        public string nhaxuatban { get; set; }
        public Nullable<System.Guid> tusach { get; set; }
        public Nullable<System.DateTime> NgayPhatHanh { get; set; }
    
        public virtual TuSach TuSach1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}
