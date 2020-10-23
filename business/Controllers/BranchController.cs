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

    }
}