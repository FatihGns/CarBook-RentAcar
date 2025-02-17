using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commads.CarFeaturesCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQuaries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> CarFeaturesListByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);

        }  
        [HttpGet("CarFeatureAvailableChangeToFalse")]
        public async Task<IActionResult> CarFeatureAvailableChangeToFalse(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("False olarak güncellendi");

        }
        [HttpGet("CarFeatureAvailableChangeToTrue")]
        public async Task<IActionResult> CarFeatureAvailableChangeToTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("True olarak güncellendi");

        }
        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByID(CreateCarFeatureByCarCommand command) 
        {
            _mediator.Send(command);
            return Ok("Ekleme Yapıldı");
        }
 

    }
}
