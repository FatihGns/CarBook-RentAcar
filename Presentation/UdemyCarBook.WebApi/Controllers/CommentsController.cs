using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commads.CommentCommands;
using UdemyCarBook.Application.Features.Mediator.Commads.ReservationCommands;
using UdemyCarBook.Application.Features.Repository_Pattern;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly  IMediator _mediator;

        public CommentsController(IGenericRepository<Comment> commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
            
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var values=_commentRepository.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _commentRepository.Create(comment);
            return Ok("Yorum Başarıyla Eklendi");
        }
        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var value=_commentRepository.GetById(id);
            _commentRepository.Remove(value);
            return Ok("Yorum Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentRepository.Create(comment);
            return Ok("Yorum Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var values=_commentRepository.GetById(id);
            return Ok(values);
        }

        [HttpGet("CommenListByBlog")]
        public IActionResult CommenListByBlog(int id)
        {
            var values = _commentRepository.GetCommentByBlog(id);
            return Ok(values);
        }
        [HttpGet("CommentCountByBlog")]
        public IActionResult CommentCountByBlog(int id)
        {
            var value = _commentRepository.GetCountCommentByBlog(id);
            return Ok(value);
        }
        [HttpPost("CreateCommentWithMediator")]
        public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yorum Başarı İle Eklendi");

        }
    }
}
