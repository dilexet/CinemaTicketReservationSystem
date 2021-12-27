namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema
{
    public class SeatRequest
    {
        public uint NumberSeat { get; set; }

        public string SeatTypeName { get; set; }
    }
}