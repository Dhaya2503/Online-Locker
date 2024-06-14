using Microsoft.EntityFrameworkCore;
using Online_Locker_System.Models;

namespace Online_Locker_System.Models
{
    public class LockerDbContext:DbContext
    {
        public LockerDbContext() { }
        public LockerDbContext(DbContextOptions<LockerDbContext>options):base(options) { }
        public DbSet<Customer_Detail> Customers { get; set; }
        public DbSet<Branch_Detail> Branchs { get; set; }
        public DbSet<Requested_Locker> Requests { get; set; }
    }
}
