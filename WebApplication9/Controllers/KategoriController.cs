using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models.Entity;

namespace WebApplication9.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILERs.ToList();
            return View(degerler);
        }
        [HttpGet] public ActionResult Yenikategori() 
        {
            return View();
        }
        [HttpPost] 
        public ActionResult Yenikategori(TBLKATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Yenikategori");
            }
            db.TBLKATEGORILERs.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.TBLKATEGORILERs.Find(id);
            db.TBLKATEGORILERs.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORILERs.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var ktg = db.TBLKATEGORILERs.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    

    }
}