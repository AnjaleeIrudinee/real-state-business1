using business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace business.Controllers
{
    public class BranchController : Controller
    {
        private BusinessContext businessContext = new BusinessContext();
        // GET: Branch
        public ActionResult Index()
        {
            List<Branch> allBranchs = businessContext.Branchs.ToList();
            return View(allBranchs);
        }
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            businessContext.Branchs.Add(branch);
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            Branch branch = businessContext.Branchs.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }
        public ActionResult Edit(string id)
        {
            Branch branch = businessContext.Branchs.SingleOrDefault(x => x.BranchNo == id);
            ViewBag.BranchDetails = new SelectList(businessContext.Branchs, "BranchNo", "BranchNo");
            return View(branch);
        }
        [HttpPost]
        public ActionResult Edit(string id,Branch updateBranch)
        {
            Branch branch = businessContext.Branchs.SingleOrDefault(x => x.BranchNo == id);
            branch.BranchNo = updateBranch.BranchNo;
            branch.Street = updateBranch.Street;
            branch.City = updateBranch.City;
            branch.PostCode = updateBranch.PostCode;
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            Branch branch = businessContext.Branchs.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteBranch(string id)
        {
            Branch branch = businessContext.Branchs.SingleOrDefault(x => x.BranchNo == id);
            businessContext.Branchs.Remove(branch);
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}