//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataService_Test
{
    using System;
    using System.Collections.Generic;
    
    public partial class Menu
    {
        public Menu()
        {
            this.Menu1 = new HashSet<Menu>();
            this.RolePermission = new HashSet<RolePermission>();
        }
    
        public System.Guid MenuId { get; set; }
        public string Header { get; set; }
        public Nullable<System.Guid> ParentId { get; set; }
        public int MenuOrder { get; set; }
    
        public virtual ICollection<Menu> Menu1 { get; set; }
        public virtual Menu Menu2 { get; set; }
        public virtual ICollection<RolePermission> RolePermission { get; set; }
    }
}