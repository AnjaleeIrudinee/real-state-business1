using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace business.Models
{
    [Table("Rent_tbl")]
    public class Rent
    {
        [Key]
        public string PropertyNo { get; set; }
        public string PropertyStreet { get; set; }
        public string City { get; set; }
        public string Ptype { get; set; }
        public int Rooms { get; set; }
        [ForeignKey("Owner")]
        public string OwnerNo_Ref { get; set; }
        [ForeignKey("Staff")]
       public string StaffNo_Ref { get; set; }
        [ForeignKey("Branch")]
        public string BranchNo_Ref { get; set; }
        public int rent1 { get; set; }
       
       public Owner Owner { get; set; }
        public Staff Staff { get; set; }
        public Branch Branch { get; set; }
    }
}