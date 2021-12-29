using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Domain.AdditionalServiceModels;

namespace CinemaTicketReservationSystem.BLL.Results.AdditionalService
{
    public class AdditionalServiceGetAllResult : Result
    {
        public IEnumerable<AdditionalServiceModel> AdditionalServices { get; set; }
    }
}