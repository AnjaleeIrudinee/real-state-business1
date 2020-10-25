using business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace business.Controllers
{
    public class RentController : Controller
    {
        private BusinessContext businessContext = new BusinessContext();
        // GET: Rent
        public ActionResult Index()
        {
            List<Rent> allrent = businessContext.Rents.ToList();
            return View(allrent);
        }
        public ActionResult Create()
        {
            ViewBag.OwnerDetails=businessContext.Owners;
            ViewBag.StaffDetails = businessContext.Staffs;
            ViewBag.BranchDetails = businessContext.Branchs;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Rent rent)
        {
            ViewBag.OwnerDetails = businessContext.Owners;
            ViewBag.StaffDetails = businessContext.Staffs;
            ViewBag.BranchDetails = businessContext.Branchs;
            businessContext.Rents.Add(rent);
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            Rent rent = businessContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }
        public ActionResult Edit(string id)
        {
            Rent rent = businessContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            ViewBag.OwnerDetails = new SelectList(businessContext.Rents, "OwnerNo_Ref", "OwnerNo_Ref");
            ViewBag.StaffDetails = new SelectList(businessContext.Rents, "StaffNo_Ref", "StaffNo_Ref");
            ViewBag.BranchDetails = new SelectList(businessContext.Rents, "BranchNo_Ref", "BranchNo_Ref");
            return View(rent);
        }
        [HttpPost]
        public ActionResult Edit(string id,Rent updateRent)
        {
            Rent rent = businessContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            rent.PropertyNo = updateRent.PropertyNo;
            rent.PropertyStreet = updateRent.PropertyStreet;
            rent.City = updateRent.City;
            rent.Ptype = updateRent.Ptype;
            rent.Rooms = updateRent.Rooms;
            rent.OwnerNo_Ref = updateRent.OwnerNo_Ref;
            rent.StaffNo_Ref = updateRent.StaffNo_Ref;
            rent.BranchNo_Ref = updateRent.BranchNo_Ref;
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            Rent rent = businessContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteRent(string id)
        {
            Rent rent = businessContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            businessContext.Rents.Remove(rent);
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}