using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace business.Models
{
    public class Owner
    {
        [Key]
        public string OwnerNo { get; set; }
        public string OwnerFname { get; set; }
        public string OwnerLname { get; set; }
        public string Address { get; set; }
        public int TelNo { get; set; }
    }
}