using business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace business.Controllers
{
    public class OwnerController : Controller
    {
        private BusinessContext businessContext = new BusinessContext();
        // GET: Owner
        public ActionResult Index()
        {
            List<Owner> Owners = businessContext.Owners.ToList();
            return View(Owners);
        }
        public ActionResult Details(string id)
        {
            Owner owners = businessContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owners);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            businessContext.Owners.Add(owner);
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            Owner owner = businessContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            ViewBag.OwnerDetails = new SelectList(businessContext.Owners, "OwnerNo", "OwnerNo");
            return View(owner);
        }
        [HttpPost]
        public ActionResult Edit(string id,Owner updateOwner)
        {
            Owner owner = businessContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            owner.OwnerNo = updateOwner.OwnerNo;
            owner.OwnerFname = updateOwner.OwnerFname;
            owner.OwnerLname = updateOwner.OwnerLname;
            owner.Address = updateOwner.Address;
            owner.TelNo = updateOwner.TelNo;
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            Owner owner = businessContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }
        public ActionResult DeleteOwner(string id2)
        {
            Owner owner = businessContext.Owners.SingleOrDefault(x => x.OwnerNo == id2);
            businessContext.Owners.Remove(owner);
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}