using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TestimonialResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryByIdHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialQueryByIdResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryByIdHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialQueryByIdResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.Id);
            return new GetTestimonialQueryByIdResult
            {
                Comment = values.Comment,
                ImageUrl = values.ImageUrl,
                Name = values.Name,
                TestimonialID = values.TestimonialID,
                Title = values.Title
            };
        }
    }
}
