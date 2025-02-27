﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commads.LocationCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            var values = await _mediator.Send(new GetLocationQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var values = await _mediator.Send(new GetLocationQueryById(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location Başarı ile Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Location Başarı ile Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location Başarı ile Güncellendi");
        }

    }
}
