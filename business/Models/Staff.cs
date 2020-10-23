using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace business.Models
{
    [Table("Staff_tbl")]
    public class Staff
    {
        [Key]
        public string StaffNo { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Position { get; set; }
        [Column(TypeName="Date")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [DataType(DataType.Currency)]
        public int Salary { get; set; }
        [ForeignKey("Branch")]
        public string BranchNo_Ref { get; set; }
       
        public Branch Branch { get; set; }
    }
}