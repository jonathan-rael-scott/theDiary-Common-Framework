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
    
    public partial class Invoice
    {
        public Invoice()
        {
            this.InvoiceLineItem = new HashSet<InvoiceLineItem>();
        }
    
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<int> InventoryID { get; set; }
        public string CastingID { get; set; }
        public string Account { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string CheckedByOfficer { get; set; }
        public Nullable<System.DateTime> CheckedDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string Fax { get; set; }
        public string OrderNumber { get; set; }
        public string PostalCode { get; set; }
        public string ReceivedBy { get; set; }
        public Nullable<System.DateTime> ReceivedDate { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public string SupplierInvoiceNumber { get; set; }
        public string Telephone { get; set; }
        public Nullable<decimal> TotalNet { get; set; }
        public string VatNo { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual ICollection<InvoiceLineItem> InvoiceLineItem { get; set; }
    }
}
