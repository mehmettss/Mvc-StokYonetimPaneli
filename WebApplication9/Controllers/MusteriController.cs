using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models.Entity;

namespace WebApplication9.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        // GET: Musteri

        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLMUSTERILERs select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLMUSTERILERs.ToList();
            //return View(degerler);
        }

        [HttpGet] public ActionResult Yenimusteri() 
        {
            return View();
        }
        [HttpPost] public ActionResult Yenimusteri(TBLMUSTERILER p1)
        {
			if (!ModelState.IsValid)
			{
				return View("Yenimusteri");
			}
			db.TBLMUSTERILERs.Add(p1);
            db.SaveChanges();
            return View();
        }
		public ActionResult Sil(int id)
		{
			var musteri = db.TBLMUSTERILERs.Find(id);
			db.TBLMUSTERILERs.Remove(musteri);
			db.SaveChanges();
			return RedirectToAction("index");
		}

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERILERs.Find(id);
            return View("MusteriGetir", mus);
        }
		public ActionResult Guncelle(TBLMUSTERILER p1)
		{
            var must = db.TBLMUSTERILERs.Find(p1.MUSTERIID);
            must.MUSTERIAD = p1.MUSTERIAD;
            must.MUSTERISOYAD= p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("index");

		}

	}
}