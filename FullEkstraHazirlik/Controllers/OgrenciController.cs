using FullEkstraHazirlik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FullEkstraHazirlik.Controllers
{
    public class OgrenciController : Controller
    {
        HazirlikDbContext baglanti = new HazirlikDbContext();
        public IActionResult Index()
        {
            var sorgu = from ogrenci in baglanti.Ogrenciler
                        join sinif in baglanti.Siniflar on ogrenci.SinifId
                        equals sinif.SinifId
                        select new OgrenciSinifModel
                        {
                            OgrenciId = ogrenci.OgrenciId,
                            OgrenciAdi = ogrenci.OgrenciAdi,
                            OgrenciSoyadi = ogrenci.OgrenciSoyadi,
                            SinifAdi = sinif.SinifAdi,
                            SinifKodu = sinif.SinifKodu
                        };
            return View(sorgu.ToList());
        }

        public IActionResult Sil(int? id)
        {
            var ogrencii = baglanti.Ogrenciler.Find(id);
            if(ogrencii != null)
            {
                baglanti.Ogrenciler.Remove(ogrencii);
                baglanti.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Ekle(Ogrenci ogrenci)
        {
            var sinifListe = baglanti.Siniflar.ToList();
            ViewBag.sinifListe = new SelectList(sinifListe, "SinifId", "Sinifadi");

            baglanti.Ogrenciler.Add(ogrenci);
            baglanti.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Ekle()
        {
            var sinifListe = baglanti.Siniflar.ToList();
            ViewBag.sinifListe = new SelectList(sinifListe, "SinifId", "SinifAdi");
            return View();
        }

        public IActionResult Guncelle(int id)
        {
            var sinifListeGuncelle = baglanti.Siniflar.ToList();
            ViewBag.sinifListeGuncelle = new SelectList(sinifListeGuncelle, "SinifId", "SinifAdi");
            var ogrenci = baglanti.Ogrenciler.Find(id);
            return View(ogrenci);
        }

        [HttpPost]
        public IActionResult Guncelle(Ogrenci ogrenci)
        {
           if(ogrenci != null)
           {
                baglanti.Entry<Ogrenci>(ogrenci).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                baglanti.SaveChanges();
           }
           return RedirectToAction("Index");
        }
    }
}
