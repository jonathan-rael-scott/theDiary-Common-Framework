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
    
    public partial class Consumable
    {
        public Consumable()
        {
            this.DeliveryNoteLineItem = new HashSet<DeliveryNoteLineItem>();
        }
    
        public int ConsumableID { get; set; }
        public string MaterialType { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> Weight { get; set; }
    
        public virtual ICollection<DeliveryNoteLineItem> DeliveryNoteLineItem { get; set; }
    }
}
