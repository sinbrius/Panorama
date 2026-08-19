using HaritaWeb.Entities.Dtos;
using HaritaWeb.Entities.Models;

namespace HaritaWeb.UI.Models
{
    public class MapCategoryViewModel
    {
        public List<Harita> Maps { get; set; } = new(); // ✅ boş liste atanıyor
        public List<Kategori> Categories { get; set; } = new();
    }
    public class CategoryWithMapsDto
    {
        public string? CategoryName { get; set; }
        public List<HaritaDto>? Maps { get; set; }
    }


}
