using AutoMapper;
using Hafta4.Odev5_6_7.Dtos.GenreOperations;
using Hafta4.Odev5_6_7.Entities;
using Hafta4.Odev5_6_7.ViewModels;

namespace Hafta4.Odev5_6_7.Mappings
{
    public class GenreMappings : Profile
    {
        public GenreMappings()
        {
            CreateMap<CreateGenreDto, Genre>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ReverseMap();

            CreateMap<UpdateGenreDto, Genre>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ReverseMap();

            CreateMap<GetGenreViewModel, Genre>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ReverseMap();

        }
    }
}
