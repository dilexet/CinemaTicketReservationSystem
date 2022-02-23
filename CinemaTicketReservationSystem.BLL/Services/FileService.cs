using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Results.File;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<FileServiceResult> UploadImage(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    var directory = "/images/";
                    if (!Directory.Exists(_environment.WebRootPath + directory))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + directory);
                    }

                    var fileType = file.FileName.Split('.').Last();
                    var path = directory + Guid.NewGuid() + '.' + fileType;
                    await using FileStream fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create);
                    await file.CopyToAsync(fileStream);
                    fileStream.Flush();
                    return new FileServiceResult
                    {
                        Success = true,
                        PosterPath = path
                    };
                }
            }
            catch (IOException e)
            {
                return new FileServiceResult
                {
                    Success = false,
                    Errors = new[]
                    {
                        e.Message
                    }
                };
            }

            return new FileServiceResult
            {
                Success = false,
                Errors = new[]
                {
                    "Error while uploading file"
                }
            };
        }
    }
}