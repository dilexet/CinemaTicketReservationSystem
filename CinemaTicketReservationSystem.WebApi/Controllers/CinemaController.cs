﻿using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.CinemaModels;
using CinemaTicketReservationSystem.WebApi.Models.Response.Cinema;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Cinema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "ManagerRole")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;
        private readonly IMapper _mapper;

        public CinemaController(ICinemaService cinemaService, IMapper mapper)
        {
            _cinemaService = cinemaService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddCinema([FromRoute] AddCinemaRequestWrapper addCinemaRequestWrapper)
        {
            var cinemaResult =
                await _cinemaService.AddCinema(_mapper.Map<CinemaModel>(addCinemaRequestWrapper.CinemaRequest));
            var response = _mapper.Map<CinemaResponse>(cinemaResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCinemaInfo(
            [FromRoute] UpdateCinemaRequestWrapper updateCinemaRequestWrapper)
        {
            var cinemaResult = await _cinemaService.UpdateCinemaInfo(
                updateCinemaRequestWrapper.Id,
                _mapper.Map<CinemaModel>(updateCinemaRequestWrapper.CinemaRequest));
            var response = _mapper.Map<CinemaResponse>(cinemaResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCinema([FromRoute] CinemaRequestWrapper cinemaRequestWrapper)
        {
            var cinemaResult = await _cinemaService.RemoveCinema(cinemaRequestWrapper.Id);
            var response = _mapper.Map<CinemaRemoveResponse>(cinemaResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCinemaById([FromRoute] CinemaRequestWrapper cinemaRequestWrapper)
        {
            var cinemaResult = await _cinemaService.GetCinemaById(cinemaRequestWrapper.Id);
            var response = _mapper.Map<CinemaResponse>(cinemaResult);

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCinemas()
        {
            var cinemaResult = await _cinemaService.GetCinemas();
            var response = _mapper.Map<CinemaGetAllResponse>(cinemaResult);

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }
    }
}