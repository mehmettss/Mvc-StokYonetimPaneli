using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models.Entity;

namespace WebApplication9.Controllers
{
    public class SatisController : Controller
    {
		// GET: Satis
		MvcDbStokEntities1 db = new MvcDbStokEntities1();
		public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p)
        {
            db.TBLSATISLARs.Add(p);
            db.SaveChanges();
            return View("index");
        }
    }
}