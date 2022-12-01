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
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<Genre> _genreRepository;
        private readonly IMapper _mapper;

        public MovieService(
            IRepository<Movie> movieRepository,
            IMapper mapper,
            IRepository<Genre> genreRepository,
            IRepository<Country> countryRepository)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _genreRepository = genreRepository;
            _countryRepository = countryRepository;
        }

        public async Task<MovieServiceResult> AddMovie(MovieModel movieModel)
        {
            var movie = _mapper.Map<Movie>(movieModel);

            var newGenres = await CreateGenres(movieModel.MovieDescriptionModel.Genres.ToList());
            var newCountries = await CreateCountries(movieModel.MovieDescriptionModel.Countries.ToList());

            movie.MovieDescription.Countries = newCountries.ToList();
            movie.MovieDescription.Genres = newGenres.ToList();

            if (!await _movieRepository.CreateAsync(movie))
            {
                return new MovieServiceResult
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while adding to the database"
                    }
                };
            }

            MovieModel newMovieModel = _mapper.Map<MovieModel>(movie);

            return new MovieServiceResult
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
            movieExist.MovieDescription.Countries =
                _mapper.Map<IEnumerable<Country>>(movieModel.MovieDescriptionModel.Countries);
            movieExist.MovieDescription.Genres =
                _mapper.Map<IEnumerable<Genre>>(movieModel.MovieDescriptionModel.Genres);

            if (!await _movieRepository.UpdateAsync(movieExist))
            {
                return new MovieServiceResult
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while adding to the database"
                    }
                };
            }

            MovieModel newMovieModel = _mapper.Map<MovieModel>(movieExist);

            return new MovieServiceResult
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
                return new MovieServiceRemoveResult
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while removing to the database"
                    }
                };
            }

            return new MovieServiceRemoveResult
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

            var moviesModel = _mapper.Map<IEnumerable<MovieModel>>(await movies.ToListAsync());

            return new MovieServiceGetMoviesResult
            {
                Success = true,
                MovieModels = moviesModel
            };
        }

        public async Task<MovieServiceResult> GetMovieById(Guid id)
        {
            var movie = await _movieRepository.FindByIdAsync(id);

            var movieModel = _mapper.Map<MovieModel>(movie);

            return new MovieServiceResult
            {
                Success = true,
                MovieModel = movieModel
            };
        }

        private async Task<IEnumerable<Genre>> CreateGenres(IList<string> genres)
        {
            var newGenres =
                genres.Except(_genreRepository.GetBy().Select(x => x.Name));

            foreach (var newGenre in newGenres)
            {
                if (!await _genreRepository.CreateAsync(new Genre { Name = newGenre.ToLower() }))
                {
                    throw new Exception("Create genres error");
                }
            }

            return _genreRepository.GetBy().ToList()
                .Where(genre => genres.Contains(genre.Name, StringComparer.OrdinalIgnoreCase));
        }

        private async Task<IEnumerable<Country>> CreateCountries(IList<string> countries)
        {
            var newCountries =
                countries.Except(_countryRepository.GetBy().Select(x => x.Name));

            foreach (var newCountry in newCountries)
            {
                if (!await _countryRepository.CreateAsync(new Country { Name = newCountry.ToLower() }))
                {
                    throw new Exception("Create countries error");
                }
            }

            return _countryRepository.GetBy().ToList()
                .Where(country => countries.Contains(country.Name, StringComparer.OrdinalIgnoreCase));
        }
    }
}