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
            if (movieExist == null)
            {
                return new MovieServiceRemoveResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Movie is not exists"
                    }
                };
            }

            if (!await _movieRepository.RemoveAsync(movieExist))
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

            if (!string.IsNullOrEmpty(filter.SearchQuery))
            {
                var searQuery = filter.SearchQuery.ToLower();
                movies = movies.Where(movie =>
                    movie.Name.ToLower().Contains(searQuery) ||
                    movie.MovieDescription.Description.ToLower().Contains(searQuery));
            }

            if (!string.IsNullOrEmpty(filter.SortBy))
            {
                switch (filter.SortBy)
                {
                    case "name":
                        movies = movies?.OrderBy(movie => movie.Name);
                        break;
                    case "release_date":
                        movies = movies?.OrderBy(movie => movie.MovieDescription.ReleaseDate);
                        break;
                }
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
            if (movie == null)
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

            var movieModel = _mapper.Map<MovieModel>(movie);

            return new MovieServiceResult()
            {
                Success = true,
                MovieModel = movieModel
            };
        }
    }
}