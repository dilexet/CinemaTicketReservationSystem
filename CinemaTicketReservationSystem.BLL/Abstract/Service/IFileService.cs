﻿using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Models.Results.File;
using Microsoft.AspNetCore.Http;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IFileService
    {
        public Task<FileServiceResult> UploadImage(IFormFile file);
    }
}