using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commads.TagCloudCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloud(int id)
        {
            var values = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket Bulutu Başarı ile Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("Etiket Bulutu Başarı ile Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket Bulutu Başarı ile Güncellendi");
        }
         [HttpGet("GetTagCloudById")]
         public async Task<IActionResult> GetTagCloudById(int id)
        {
            var values=await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return Ok(values);
        }

    }
}
