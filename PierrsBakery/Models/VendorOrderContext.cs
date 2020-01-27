using Microsoft.EntityFrameworkCore;
namespace PierrsBakery.Models
{
    public class VendorOrderContext: DbContext
    {
        public virtual DbSet<Vendor> Vendors {get;set;}
        public DbSet<Order> Orders {get;set;}
        public VendorOrderContext(DbContextOptions options):base(options){}

    }
}