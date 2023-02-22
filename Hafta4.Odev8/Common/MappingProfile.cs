using AutoMapper;
using Hafta4.Odev8.DbOperations;
using Hafta4.Odev8.Entities;
using static Hafta4.Odev8.Application.ActorActressOperations.Commands.CreateActorActress.CreateActorActressCommand;
using static Hafta4.Odev8.Application.ActorActressOperations.Commands.UpdateActorActress.UpdateActorActressCommand;
using static Hafta4.Odev8.Application.ActorActressOperations.Queries.GetActorActressDetail.GetActorActressDetailQuery;
using static Hafta4.Odev8.Application.ActorActressOperations.Queries.GetActorsAndActresses.GetActorActressQuery;
using static Hafta4.Odev8.Application.CustomerOperations.CreateCustomer.CreateCustomerCommand;
using static Hafta4.Odev8.Application.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;
using static Hafta4.Odev8.Application.DirectorOperations.Commands.UpdateDirector.UpdateDirectorCommand;
using static Hafta4.Odev8.Application.DirectorOperations.Queries.GetDirectorDetails.GetDirectorDetailQuery;
using static Hafta4.Odev8.Application.DirectorOperations.Queries.GetDirectors.GetDirectorsQuery;
using static Hafta4.Odev8.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using static Hafta4.Odev8.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;
using static Hafta4.Odev8.Application.GenreOperations.Queries.GetGenreDetails.GetGenreDetailQuery;
using static Hafta4.Odev8.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;
using static Hafta4.Odev8.Application.MovieOperations.Commands.CreateMovie.CreateMovieCommand;
using static Hafta4.Odev8.Application.MovieOperations.Commands.UpdateMovie.UpdateMovieCommand;
using static Hafta4.Odev8.Application.MovieOperations.Queries.GetMovieDetails.GetMovieDetailQuery;
using static Hafta4.Odev8.Application.MovieOperations.Queries.GetMovies.GetMoviesQuery;

namespace Hafta4.Odev8.Common
{
    public class MappingProfile : Profile
    {
        public readonly IMovieStoreDbContext _dbContext;

        public MappingProfile()
        {
            //ActorActress Mapping
            CreateMap<CreateActorActressModel, ActorActress>();
            CreateMap<ActorActress, ActorActressViewModel>();
            CreateMap<ActorActress, ActorActressDetailViewModel>();
            CreateMap<UpdateActorActressModel, ActorActress>();

            //Director Mapping
            CreateMap<CreateDirectorViewModel, Director>();
            CreateMap<Director, DirectorViewModel>();
            CreateMap<Director, DirectorDetailViewModel>();
            CreateMap<UpdateDirectorViewModel, Director>();

            //Genre Mapping
            CreateMap<CreateGenreViewModel, Genre>();
            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<UpdateGenreViewModel, Genre>();

            //Movie Mapping
            CreateMap<Movie, MovieViewModel>().ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname));
            CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.GenreTitle))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.ActorActressMovieJoint.Select(x => x.actorActress.Name + " " + x.actorActress.Surname)));

            CreateMap<CreateMovieViewModel, Movie>();
            CreateMap<UpdateMovieViewModel, Movie>();

            //Customer Mapping
            CreateMap<CreateCustomerModel, Customer>();
        }
    }
}
