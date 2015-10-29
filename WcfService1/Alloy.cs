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
    
    public partial class Alloy
    {
        public Alloy()
        {
            this.Casting = new HashSet<Casting>();
            this.DeliveryNoteLineItem = new HashSet<DeliveryNoteLineItem>();
            this.MonthlyAlloyCost = new HashSet<MonthlyAlloyCost>();
            this.StockTakeLineItem = new HashSet<StockTakeLineItem>();
            this.StockTakeVarianceLineItem = new HashSet<StockTakeVarianceLineItem>();
        }
    
        public int AlloyID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<decimal> SandWeight { get; set; }
        public Nullable<decimal> WeightOnHand { get; set; }
        public Nullable<decimal> Unitonhand { get; set; }
        public Nullable<decimal> Runnerweight { get; set; }
    
        public virtual ICollection<Casting> Casting { get; set; }
        public virtual ICollection<DeliveryNoteLineItem> DeliveryNoteLineItem { get; set; }
        public virtual ICollection<MonthlyAlloyCost> MonthlyAlloyCost { get; set; }
        public virtual ICollection<StockTakeLineItem> StockTakeLineItem { get; set; }
        public virtual ICollection<StockTakeVarianceLineItem> StockTakeVarianceLineItem { get; set; }
    }
}
