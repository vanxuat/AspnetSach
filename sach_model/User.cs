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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.DonHangs = new HashSet<DonHang>();
        }
    
        public System.Guid id { get; set; }
        public string nguoidung { get; set; }
        public string matkhau { get; set; }
        public string email { get; set; }
        public string dienthoai { get; set; }
        public string hinhanh { get; set; }
        public Nullable<int> Quyen { get; set; }
        public string GoogleID { get; set; }
        public string FaceBookID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
