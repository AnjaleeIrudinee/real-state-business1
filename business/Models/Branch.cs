using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace business.Models
{
    [Table("Branch_tbl")]
    public class Branch
    {
        [Key]
        public string BranchNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
      
    }
}