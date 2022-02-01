using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Validation
{
    public class ModelValidationResponse : Response
    {
        public IDictionary<string, IEnumerable<object>> ValidationErrors { get; set; }
    }
}