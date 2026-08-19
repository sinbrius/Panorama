using AutoMapper;
using HaritaWeb.Entities.Dtos;
using HaritaWeb.Entities.Models;

namespace HaritaWeb.UI.Infrastructure.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<MapDtoForInsertion, Harita>();//senden dto istediğimde mapi vereceksin
            CreateMap<MapDtoForUpdate, Harita>().ReverseMap();
            CreateMap<PanoramaDtoForUpdate, Panorama>().ReverseMap();//panoramadtodan panoramaya dönüsüm ve panoramadan panoramadtoya dönüsüm
            CreateMap<CategoryDtoForInsertion, Kategori>();
            CreateMap<MahalleDtoForInsertion, Mahalle>();
            CreateMap<PanoramaDtoForInsertion, Panorama>();
            CreateMap<PanoramaCatDtoForInsertion, PanoramaKategori>();
            CreateMap<HotspotsDto, Hotspots>();
        }
    }
    
}