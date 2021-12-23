using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.Abstract;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Validation
{
    public class ModelValidationResponse : IResponse
    {
        public int Code { get; set; }

        public bool Success { get; set; }

        public IDictionary<string, IEnumerable<object>> Errors { get; set; }
    }
}