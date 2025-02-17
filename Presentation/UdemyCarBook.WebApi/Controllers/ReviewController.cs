using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commads.ReviewCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.ReviewQuaries;
using UdemyCarBook.Application.Validators.ReviewValidators;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("id")]
        public async Task<IActionResult> ReviewListByCarId(int id)
        {
            var values = await _mediator.Send(new GetReviewByCarIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            CreateReviewValidators validator=new CreateReviewValidators();
            var validationResult=validator.Validate(command);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            else
            {
                await _mediator.Send(command);
                return Ok("Ekleme İşlemi Gerçekleşti");
            }
           
        }
        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme İşlemi Gerçekleşti");
        }
    }
}
