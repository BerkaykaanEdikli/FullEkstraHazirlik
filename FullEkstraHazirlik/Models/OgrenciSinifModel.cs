namespace FullEkstraHazirlik.Models
{
    public class OgrenciSinifModel
    {
        public int OgrenciId { get; set; }
        public string? OgrenciAdi { get; set; }
        public string? OgrenciSoyadi { get; set; }

        public string SinifAdi { get; set; }
        public int SinifKodu { get; set; }
    }
}
