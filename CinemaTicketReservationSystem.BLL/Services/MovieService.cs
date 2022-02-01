using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.MovieModels;
using CinemaTicketReservationSystem.BLL.Models.FilterModel;
using CinemaTicketReservationSystem.BLL.Models.Results.Movie;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IRepository<Movie> movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieServiceResult> AddMovie(MovieModel movieModel)
        {
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
            var movieExist = await _movieRepository.FindByIdAsync(id);

            movieExist.Name = movieModel.Name;
            movieExist.StartDate = movieModel.StartDate;
            movieExist.EndDate = movieModel.EndDate;

            movieExist.PosterUrl = movieModel.PosterUrl;

            movieExist.MovieDescription.ReleaseDate = movieModel.MovieDescriptionModel.ReleaseDate;
            movieExist.MovieDescription.Description = movieModel.MovieDescriptionModel.Description;
            movieExist.MovieDescription.Countries = movieModel.MovieDescriptionModel.Countries;
            movieExist.MovieDescription.Genres = movieModel.MovieDescriptionModel.Genres;

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

        public async Task<MovieServiceRemoveResult> RemoveMovie(Guid id)
        {
            var movieExist = await _movieRepository.FindByIdAsync(id);

            if (!await _movieRepository.RemoveAndSaveAsync(movieExist))
            {
                return new MovieServiceRemoveResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while removing to the database"
                    }
                };
            }

            return new MovieServiceRemoveResult()
            {
                Success = true,
                Id = id
            };
        }

        public async Task<MovieServiceGetMoviesResult> GetMovies(FilterParametersModel filter)
        {
            IQueryable<Movie> movies = _movieRepository.GetBy();

            if (filter.FromDate != null)
            {
                movies = movies.Where(movie =>
                    movie.StartDate >= filter.FromDate);
            }

            if (filter.ToDate != null)
            {
                movies = movies.Where(movie =>
                    movie.EndDate <= filter.ToDate);
            }

            if (filter.StillShowing == true)
            {
                DateTime now = DateTime.Now;
                movies = movies.Where(movie => movie.EndDate >= now);
            }

            if (movies == null || !movies.Any())
            {
                return new MovieServiceGetMoviesResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "No movies found"
                    }
                };
            }

            var moviesModel = _mapper.Map<IEnumerable<MovieModel>>(await movies.ToListAsync());

            return new MovieServiceGetMoviesResult()
            {
                Success = true,
                MovieModels = moviesModel
            };
        }

        public async Task<MovieServiceResult> GetMovieById(Guid id)
        {
            var movie = await _movieRepository.FindByIdAsync(id);

            var movieModel = _mapper.Map<MovieModel>(movie);

            return new MovieServiceResult()
            {
                Success = true,
                MovieModel = movieModel
            };
        }
    }
}