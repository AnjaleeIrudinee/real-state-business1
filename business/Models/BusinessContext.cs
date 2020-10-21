using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace business.Models
{
    public class BusinessContext:DbContext
    {
        public DbSet<Owner> Owner_tbl { get; set; }
        public DbSet<Branch> Branch_tbl { get; set; }
        public DbSet<Staff> Staff_tbl { get; set; }
        public DbSet<Rent> Rent_tbl { get; set; }
    }
}