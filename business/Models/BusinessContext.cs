using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace business.Models
{
    public class BusinessContext:DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Rent> Rents { get; set; }
    }
}