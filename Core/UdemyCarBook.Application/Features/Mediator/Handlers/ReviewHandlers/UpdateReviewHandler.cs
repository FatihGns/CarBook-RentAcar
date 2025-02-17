using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commads.ReviewCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public UpdateReviewHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByIdAsync(request.ReviewID);
            values.CustomerName= request.CustomerName;
            values.ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            values.RaytingValue = request.RaytingValue;
            values.CustomerImage = request.CustomerImage;
            values.Comment = request.Comment;
            values.CarID = request.CarID;
            await _repository.UpdatedAsync(values);
        }
    }
}
