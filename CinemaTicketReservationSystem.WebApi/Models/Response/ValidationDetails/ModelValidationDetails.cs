using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.ValidationDetails
{
    public class ModelValidationDetails
    {
        public string Field { get; set; }

        public IEnumerable<object> Errors { get; set; }
    }
}