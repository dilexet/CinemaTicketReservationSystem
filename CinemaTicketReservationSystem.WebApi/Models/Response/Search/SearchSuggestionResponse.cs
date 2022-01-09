using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Search
{
    public class SearchSuggestionResponse : Response
    {
        public IEnumerable<string> ListOfTitles { get; set; }
    }
}