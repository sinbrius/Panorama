using HaritaWeb.Entities.Models;

namespace HaritaWeb.UI.Models
{
    public class IlcePanoramaViewModel
    {
        public List<Ilce> Ilce { get; set; } = new(); // ✅ boş liste atanıyor
        public List<Panorama> Panorama { get; set; } = new();
        public List<PanoramaKategori> Categories { get; set; } = new();
        
    }
}