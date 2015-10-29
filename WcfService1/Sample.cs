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
    
    public partial class Sample
    {
        public Sample()
        {
            this.StockTakeLineItem = new HashSet<StockTakeLineItem>();
            this.StockTakeVarianceLineItem = new HashSet<StockTakeVarianceLineItem>();
        }
    
        public int SampleID { get; set; }
        public int InvID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<double> Cost { get; set; }
        public string Unit { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<double> SandWeight { get; set; }
        public Nullable<double> Weightonhand { get; set; }
        public Nullable<double> Unitonhand { get; set; }
        public Nullable<double> Runnerweight { get; set; }
    
        public virtual ICollection<StockTakeLineItem> StockTakeLineItem { get; set; }
        public virtual ICollection<StockTakeVarianceLineItem> StockTakeVarianceLineItem { get; set; }
    }
}
