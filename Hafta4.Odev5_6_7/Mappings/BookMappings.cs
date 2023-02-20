using AutoMapper;
using Hafta4.Odev5_6_7.Dtos.BookOperations;
using Hafta4.Odev5_6_7.Entities;
using Hafta4.Odev5_6_7.ViewModels;

namespace Hafta4.Odev5_6_7.Mappings
{
    public class BookMappings : Profile
    {
        public BookMappings()
        {
            CreateMap<CreateBookDto, Book>()
                .ForMember(dest => dest.PageCount, opt => opt.MapFrom(src => src.PageCount))
                 .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate))
                 .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                 .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                 .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
                 .ReverseMap();

            CreateMap<UpdateBookDto, Book>()
                 .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                 .ReverseMap();

            CreateMap<Book, GetBookViewModel>()
                .ForMember(dest => dest.PageCount, opt => opt.MapFrom(src => src.PageCount))
                 .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate))
                 .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                 .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname))
                 .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                 .ReverseMap();

        }
    }
}