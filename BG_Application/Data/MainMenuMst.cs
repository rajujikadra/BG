//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BG_Application.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class MainMenuMst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MainMenuMst()
        {
            this.MenuMsts = new HashSet<MenuMst>();
        }
    
        public int MainMenuMstID { get; set; }
        public string MainMenuName { get; set; }
        public string Icon { get; set; }
        public Nullable<int> SortId { get; set; }
        public Nullable<bool> Active { get; set; }
        public string URL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MenuMst> MenuMsts { get; set; }
    }
}
