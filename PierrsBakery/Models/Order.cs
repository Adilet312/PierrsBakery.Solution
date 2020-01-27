
using System;
namespace PierrsBakery.Models
{
    public class Order
    {
        public int OrderId {get;set;}
        public int VendorId {get;set;}
        public string OrderTitle {get;set;}
        public string OrderDescription {get;set;}
        public double OrderPrice {get; set;}
        public DateTime OrderDate {get; set;}
        public virtual Vendor Vendor {get;set;}
 
     public Order()
     {

     }


        

    }
}