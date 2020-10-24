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
        public ActionResult Staff_in_Branch(string branchno)
        {
            List<Staff> staffs = businessContext.Staffs.Where(x => x.BranchNo_Ref == branchno).ToList();
            return View(staffs);
        }
        public ActionResult StaffDetails(string id)
        {
            Staff staff1 = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff1);

        }
        public ActionResult OwnerProp(string id1)
        {
            Owner owner1 = businessContext.Owners.SingleOrDefault(x => x.OwnerNo == id1);
            return View(owner1);
        }
        public ActionResult PropertyDetails(string id2)
        {
            List<Rent> rent = businessContext.Rents.Where(x => x.OwnerNo_Ref == id2).ToList();
            return View(rent);
        }


    }
}