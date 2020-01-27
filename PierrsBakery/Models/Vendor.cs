using System.Collections.Generic; 

namespace PierrsBakery.Models
{
    public class Vendor
    {
     public int VendorId {get;set;}
     public string VendorName {get;set;}
     public string VendorDescription {get;set;}
     public string VendorPhone {get;set;}
     public int VendorZip {get;set;}
     public virtual ICollection<Order> Orders {get;set;}
     public Vendor(string VendorName, string VendorDescription, string VendorPhone, int VendorZip)
     {
         this.VendorName = VendorName;
         this.VendorDescription = VendorDescription;
         this.VendorPhone = VendorPhone;
         this.VendorZip = VendorZip;
         this.Orders = new HashSet<Order>();
     }
    public Vendor()
    {
        this.Orders = new HashSet<Order>();
    }



    }
}