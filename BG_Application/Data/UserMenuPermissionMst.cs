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
    
    public partial class UserMenuPermissionMst
    {
        public int ID { get; set; }
        public Nullable<int> MainMenuMstId { get; set; }
        public Nullable<int> MenuMstId { get; set; }
        public string UserId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual MainMenuMst MainMenuMst { get; set; }
        public virtual MenuMst MenuMst { get; set; }
    }
}
