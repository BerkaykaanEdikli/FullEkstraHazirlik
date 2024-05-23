namespace FullEkstraHazirlik.Models
{
    public class Ogrenci
    {
        public int OgrenciId { get; set; }
        public string? OgrenciAdi { get; set; }
        public string? OgrenciSoyadi { get; set; }

        public Sinif? SinifAdi { get; set; }
        public int SinifId { get; set;}
    }
}
