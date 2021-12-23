namespace CinemaTicketReservationSystem.WebApi.Models.Abstract
{
    public interface IResponse
    {
        public int Code { get; set; }

        public bool Success { get; set; }
    }
}