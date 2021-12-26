using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTicketReservationSystem.DAL.Entity.MovieEntity
{
    public class MovieDescription : BasedEntity
    {
        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public Movie Movie { get; set; }

        public string CountriesString { get; set; }

        public string GenresString { get; set; }

        public IEnumerable<string> Countries
        {
            get => CountriesString.Split(',').ToList();
            set => CountriesString = string.Join(",", value);
        }

        public IEnumerable<string> Genres
        {
            get => GenresString.Split(',').ToList();
            set => GenresString = string.Join(",", value);
        }
    }
}