using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace business.Models
{
    public class Rent
    {
        [Key]
        public int PropertyNo { get; set; }
        public string PropertyStreet { get; set; }
        public string Street { get; set; }
        public string Ptype { get; set; }
        public int Rooms { get; set; }
        [ForeignKey("Owner")]
        public int RefOwnerNo { get; set; }
        [ForeignKey("Staff")]
        public int RefStaffNo { get; set; }
        [ForeignKey("Branch")]
        public int RefBranchNo { get; set; }
        public int rent1 { get; set; }
    }
}