//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace aanchalibookshop_
{
    using System;
    using System.Collections.Generic;
    
    public partial class productdetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public productdetail()
        {
            this.orderdetails = new HashSet<orderdetail>();
            this.productimages = new HashSet<productimage>();
        }
    
        public int p_id { get; set; }
        public string p_name { get; set; }
        public decimal p_price { get; set; }
        public int p_qty { get; set; }
        public string p_detail { get; set; }
        public int cat_id { get; set; }
    
        public virtual category category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderdetail> orderdetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productimage> productimages { get; set; }
    }
}
