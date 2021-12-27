using CinemaTicketReservationSystem.DAL.Enums;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema
{
    public class SeatRequest
    {
        public uint NumberSeat { get; set; }

        public string SeatType { get; set; }
    }
}