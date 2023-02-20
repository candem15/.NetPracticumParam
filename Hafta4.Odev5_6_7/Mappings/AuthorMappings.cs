using AutoMapper;
using Hafta4.Odev5_6_7.Dtos.AuthorOperations;
using Hafta4.Odev5_6_7.Entities;
using Hafta4.Odev5_6_7.ViewModels;

namespace Hafta4.Odev5_6_7.Mappings
{
    public class AuthorMappings : Profile
    {
        public AuthorMappings()
        {
            CreateMap<Author, GetAuthorViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                 .ReverseMap();

            CreateMap<UpdateAuthorDto, Author>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                 .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                 .ReverseMap();

            CreateMap<CreateAuthorDto, Author>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                 .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                 .ReverseMap();
        }
    }
}
