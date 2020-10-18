using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace business.Models
{
    public class Staff
    {
        [Key]
        public string StaffNo { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Position { get; set; }
        public DateTime DOB { get; set; }
        public int Salary { get; set; }
        [ForeignKey("Branch")]
        public string RefBranchNo { get; set; }
    }
}