//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfService1
{
    using System;
    using System.Collections.Generic;
    
    public partial class CreditNoteLineItem
    {
        public long CreditNoteLineItem1 { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> TotalWeight { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
    
        public virtual Casting Casting { get; set; }
        public virtual CreditNote CreditNote { get; set; }
    }
}
