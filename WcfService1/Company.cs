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
    
    public partial class Company
    {
        public Company()
        {
            this.CreditNote = new HashSet<CreditNote>();
            this.DeliveryNote = new HashSet<DeliveryNote>();
            this.Invoice = new HashSet<Invoice>();
            this.Quotation = new HashSet<Quotation>();
            this.WeeklyPlan = new HashSet<WeeklyPlan>();
        }
    
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
    
        public virtual ICollection<CreditNote> CreditNote { get; set; }
        public virtual ICollection<DeliveryNote> DeliveryNote { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Quotation> Quotation { get; set; }
        public virtual ICollection<WeeklyPlan> WeeklyPlan { get; set; }
    }
}
