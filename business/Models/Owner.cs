using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace business.Models
{
    [Table("Owner_tbl")]
    public class Owner
    {
        [Key]
        public string OwnerNo { get; set; }
        public string OwnerFname { get; set; }
        public string OwnerLname { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public string TelNo { get; set; }
       
        
    }
}