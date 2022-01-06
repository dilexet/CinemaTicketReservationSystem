﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;

namespace CinemaTicketReservationSystem.WebApi.Hubs
{
    public class SeatBookingHub : Hub
    {
        private readonly IMemoryCache _memoryCache;

        public SeatBookingHub(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task SetBlockedSeats(Guid seatsId)
        {
            _memoryCache.Set(seatsId, seatsId, new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
            });
            await Clients.All.SendAsync("setBlockedSeat", seatsId);
        }
    }
}