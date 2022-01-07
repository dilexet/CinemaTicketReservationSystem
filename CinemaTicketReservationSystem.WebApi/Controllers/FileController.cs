using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.WebApi.Models.Response.File;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Policy = "AdminRole")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly ILogger<FileController> _logger;

        public FileController(IFileService fileService, IMapper mapper, ILogger<FileController> logger)
        {
            _fileService = fileService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var result = await _fileService.UploadImage(file);
            var response = _mapper.Map<FileResponse>(result);

            if (!response.Success)
            {
                foreach (var error in response.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }
    }
}