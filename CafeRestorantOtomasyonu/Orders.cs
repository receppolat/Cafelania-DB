//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CafeRestorantOtomasyonu
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int OrderID { get; set; }
        public int ProductCount { get; set; }
        public string Information { get; set; }
        public bool isAlive { get; set; }
        public int TableNumber { get; set; }
        public Nullable<int> Product_ProductID { get; set; }
        public Nullable<int> Receipt_ReceiptID { get; set; }
        public virtual Products Products { get; set; }
        public virtual Receipts Receipts { get; set; }
    }
}
