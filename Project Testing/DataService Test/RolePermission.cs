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
    
    public partial class RolePermission
    {
        public long PermissionID { get; set; }
        public int RoleID { get; set; }
        public System.Guid MenuId { get; set; }
        public bool Allowed { get; set; }
    
        public virtual Menu Menu { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
