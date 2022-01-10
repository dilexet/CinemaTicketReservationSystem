using System.Collections.Generic;

namespace CinemaTicketReservationSystem.BLL.Models.Results.Search
{
    public class SearchSuggestionResult : Result
    {
        public IEnumerable<string> ListOfTitles { get; set; }
    }
}