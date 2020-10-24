using business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace business.Controllers
{
    public class StaffController : Controller
    {
        private BusinessContext businessContext = new BusinessContext();
        // GET: Staff
        public ActionResult Index()
        {
            List<Staff> allstaff = businessContext.Staffs.ToList();
            return View(allstaff);
        }
        public ActionResult Create()
        {
            ViewBag.BranchDetails = businessContext.Branchs;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Rent rent)
        {
            ViewBag.BranchDetails = businessContext.Branchs;
            businessContext.Rents.Add(rent);
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deatails(string id)
        {
            Staff staff = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }
        public ActionResult Edit(string id)
        {
            Staff staff = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            ViewBag.BranchDetails = new SelectList(businessContext.Staffs, "BranchNo_Ref", "BranchNo_Ref");
            return View(staff);
        }
        [HttpPost]
        public ActionResult Edit(string id,Staff updateStaff)
        {
            Staff staff = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            staff.StaffNo = updateStaff.StaffNo;
            staff.Fname = updateStaff.Fname;
            staff.Lname = updateStaff.Lname;
            staff.Position = updateStaff.Position;
            staff.DOB = updateStaff.DOB;
            staff.Salary = updateStaff.Salary;
            staff.BranchNo_Ref = updateStaff.BranchNo_Ref;
            businessContext.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult Delete(string id)
        {
            Staff staff = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteStaffs(string id2)
        {
            Staff staff = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id2);
            businessContext.Staffs.Remove(staff);
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}