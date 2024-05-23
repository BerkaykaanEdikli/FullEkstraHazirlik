using FullEkstraHazirlik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FullEkstraHazirlik.Controllers
{
    public class SinifController : Controller
    {
        HazirlikDbContext baglanti = new HazirlikDbContext();
        public IActionResult Index()
        {
            return View(baglanti.Siniflar.ToList());
        }

        public IActionResult Sil(int? id)
        {
            Sinif sinif = baglanti.Siniflar.Find(id);
            baglanti.Siniflar.Remove(sinif);
            baglanti.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Ekle(Sinif sinif)
        {
            baglanti.Siniflar.Add(sinif);
            baglanti.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Ekle()
        {
            return View();
        }

        public IActionResult Guncelle(int id)
        {
            Sinif sinif = baglanti.Siniflar.Find(id);
            return View(sinif);
        }

        [HttpPost]
        public IActionResult Guncelle(Sinif sinif)
        {
            baglanti.Entry<Sinif>(sinif).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            baglanti.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
