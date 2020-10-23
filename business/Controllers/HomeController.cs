using business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace business.Controllers
{
    public class HomeController : Controller
    {
        private BusinessContext businessContext = new BusinessContext();
        // GET: Home
        public ActionResult IndexB()
        {
            List<Branch> Branchs = businessContext.Branchs.ToList();
            return View(Branchs);
        }
        public ActionResult IndexO()
        {
            List<Owner> Owners = businessContext.Owners.ToList();
            return View(Owners);
        }
        public ActionResult IndexR()
        {
            List<Rent> Rents = businessContext.Rents.ToList();
            return View(Rents);
        }
        public ActionResult IndexS()
        {
            List<Staff> Staffs = businessContext.Staffs.ToList();
            return View(Staffs);
        }
    }
}