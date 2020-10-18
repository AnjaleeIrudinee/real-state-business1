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
        public int StaffNo { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Position { get; set; }
        public string DOB { get; set; }
        public int Salary { get; set; }
        [ForeignKey("Branch")]
        public int RefBranchNo { get; set; }
    }
}