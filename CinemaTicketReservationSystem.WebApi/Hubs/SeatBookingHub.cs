using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace CinemaTicketReservationSystem.WebApi.Hubs
{
    public class SeatBookingHub : Hub
    {
        public async Task SetBlockedSeats(Guid[] seatsId)
        {
            await Clients.All.SendAsync("setBlockedSeat", seatsId);
        }

        public async Task SetBookingSeats(Guid[] seatsId)
        {
            await Clients.All.SendAsync("setBookingSeat", seatsId);
        }
    }
}