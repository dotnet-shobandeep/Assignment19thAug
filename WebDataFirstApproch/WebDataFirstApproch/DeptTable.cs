//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebDataFirstApproch
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeptTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeptTable()
        {
            this.EmployeeTb1 = new HashSet<EmployeeTb1>();
        }
    
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeTb1> EmployeeTb1 { get; set; }
    }
}
