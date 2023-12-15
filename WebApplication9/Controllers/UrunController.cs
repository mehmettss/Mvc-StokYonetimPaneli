using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models.Entity;

namespace WebApplication9.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLERs.ToList();
            return View(degerler);
        }

        [HttpGet] public ActionResult Yeniurun() 
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILERs.ToList() select new SelectListItem
            {
                Text = i.KATEGORIAD,
                Value =i.KATEGORIID.ToString()
            }).ToList();
            ViewBag.Degerler = degerler;
            return View();
        }
        [HttpPost] public ActionResult Yeniurun(TBLURUNLER p1)
        {
            var degerler = db.TBLKATEGORILERs.Where(m=>m.KATEGORIID==p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = degerler;

            db.TBLURUNLERs.Add(p1);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.TBLURUNLERs.Find(id);
            db.TBLURUNLERs.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Urungetir(int id)
        {
            var urun = db.TBLURUNLERs.Find(id);
			List<SelectListItem> degerler = (from i in db.TBLKATEGORILERs.ToList()
											 select new SelectListItem
											 {
												 Text = i.KATEGORIAD,
												 Value = i.KATEGORIID.ToString()
											 }).ToList();
			ViewBag.Degerler = degerler;
			return View("Urungetir", urun);
        }
        public ActionResult Guncelle(TBLURUNLER p1)
        {
            var urunn = db.TBLURUNLERs.Find(p1.ID);
            urunn.URUNAD = p1.URUNAD;
            urunn.MARKA = p1.MARKA;
            //urunn.URUNKATEGORI = p1.URUNKATEGORI;
            urunn.FIYAT = p1.FIYAT;
            urunn.STOK = p1.STOK;
			var degerler = db.TBLKATEGORILERs.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
			urunn.URUNKATEGORI = degerler.KATEGORIID;
			db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}