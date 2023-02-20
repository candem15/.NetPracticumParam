using AutoMapper;
using Hafta3.Odev3_4.Dtos.BookOperations;
using Hafta3.Odev3_4.Entities;
using Hafta3.Odev3_4.ViewModels;

namespace Hafta3.Odev3_4.Mappings
{
    public class BookMappings : Profile
    {
        public BookMappings()
        {
            CreateMap<CreateBookDto, Book>()
                .ForMember(dest => dest.PageCount, opt => opt.MapFrom(src => src.PageCount))
                 .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate))
                 .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                 .ReverseMap();

            CreateMap<UpdateBookDto, Book>()
                 .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                 .ReverseMap();

            CreateMap<GetBookViewModel, Book>()
                .ForMember(dest => dest.PageCount, opt => opt.MapFrom(src => src.PageCount))
                 .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate))
                 .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                 .ReverseMap();

        }
    }
}