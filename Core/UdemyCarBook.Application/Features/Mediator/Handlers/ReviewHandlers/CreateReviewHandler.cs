﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commads.LocationCommands;
using UdemyCarBook.Application.Features.Mediator.Commads.ReviewCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public CreateReviewHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
              await _repository.CreatedAsync(new Review
            {
                Comment = request.Comment,
                CarID = request.CarID,
                CustomerImage = request.CustomerImage,
                CustomerName = request.CustomerName,
                RaytingValue = request.RaytingValue,
                ReviewDate=DateTime.Parse(DateTime.Now.ToShortDateString()),
       
                
            });
        }
    }
}
