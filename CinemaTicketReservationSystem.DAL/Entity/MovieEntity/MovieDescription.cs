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

        public string DirectorsString { get; set; }

        public string ScreenwritersString { get; set; }

        public string ProducersString { get; set; }

        public string ActorsString { get; set; }

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

        public IEnumerable<string> Directors
        {
            get => DirectorsString.Split(',').ToList();
            set => DirectorsString = string.Join(",", value);
        }

        public IEnumerable<string> Screenwriters
        {
            get => ScreenwritersString.Split(',').ToList();
            set => ScreenwritersString = string.Join(",", value);
        }

        public IEnumerable<string> Producers
        {
            get => ProducersString.Split(',').ToList();
            set => ProducersString = string.Join(",", value);
        }

        public IEnumerable<string> Actors
        {
            get => ActorsString.Split(',').ToList();
            set => ActorsString = string.Join(",", value);
        }
    }
}