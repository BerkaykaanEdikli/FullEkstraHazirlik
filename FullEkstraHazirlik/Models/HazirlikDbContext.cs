using Microsoft.EntityFrameworkCore;

namespace FullEkstraHazirlik.Models
{
    public class HazirlikDbContext : DbContext
    {
        string baglantiCumlesi = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HazirlikDB;Integrated Security=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(baglantiCumlesi);
        }
        public DbSet<Ogrenci> Ogrenciler {  get; set; }
        public  DbSet<Sinif> Siniflar {  get; set; }
    }
}
