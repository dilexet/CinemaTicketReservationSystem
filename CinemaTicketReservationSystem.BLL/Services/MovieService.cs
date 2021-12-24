using System;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Domain.MovieModels;
using CinemaTicketReservationSystem.BLL.Results.Movie;
using CinemaTicketReservationSystem.DAL.Abstract.Movie;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieServiceResult> AddMovie(MovieModel movieModel)
        {
            var movieExist = await _movieRepository.FirstOrDefaultAsync(x => x.Name == movieModel.Name);
            if (movieExist != null)
            {
                return new MovieServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Movie is exists"
                    }
                };
            }

            var movie = _mapper.Map<Movie>(movieModel);

            if (!await _movieRepository.CreateAsync(movie))
            {
                return new MovieServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while adding to the database"
                    }
                };
            }

            MovieModel newMovieModel = _mapper.Map<MovieModel>(movie);

            return new MovieServiceResult()
            {
                Success = true,
                MovieModel = newMovieModel
            };
        }

        public async Task<MovieServiceResult> UpdateMovieInfo(Guid id, MovieModel movieModel)
        {
            if (await _movieRepository.FirstOrDefaultAsync(x => x.Name == movieModel.Name) != null)
            {
                return new MovieServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Movie with this name is exists"
                    }
                };
            }

            var movieExist = await _movieRepository.FindByIdAsync(id);
            if (movieExist == null)
            {
                return new MovieServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Movie is not exists"
                    }
                };
            }

            movieExist.Name = movieModel.Name;
            movieExist.StartDate = movieModel.StartDate;
            movieExist.EndDate = movieModel.EndDate;

            movieExist.MovieDescription.ReleaseDate = movieModel.MovieDescriptionModel.ReleaseDate;
            movieExist.MovieDescription.Description = movieModel.MovieDescriptionModel.Description;
            movieExist.MovieDescription.Countries = movieModel.MovieDescriptionModel.Countries;
            movieExist.MovieDescription.Genres = movieModel.MovieDescriptionModel.Genres;
            movieExist.MovieDescription.Directors = movieModel.MovieDescriptionModel.Directors;
            movieExist.MovieDescription.Screenwriters = movieModel.MovieDescriptionModel.Screenwriters;
            movieExist.MovieDescription.Producers = movieModel.MovieDescriptionModel.Producers;
            movieExist.MovieDescription.Actors = movieModel.MovieDescriptionModel.Actors;

            if (!await _movieRepository.UpdateAsync(movieExist))
            {
                return new MovieServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while adding to the database"
                    }
                };
            }

            MovieModel newMovieModel = _mapper.Map<MovieModel>(movieExist);

            return new MovieServiceResult()
            {
                Success = true,
                MovieModel = newMovieModel
            };
        }
    }
}