﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commads.CarFeaturesCommands;
using UdemyCarBook.Application.Interfaces.CarFeatureInterFaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureAvailableChangeToTrueCommandHandler : IRequestHandler<UpdateCarFeatureAvailableChangeToTrueCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public UpdateCarFeatureAvailableChangeToTrueCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarFeatureAvailableChangeToTrueCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeatureAvailableToTrue(request.Id);
            //return Task.CompletedTask;
        }
    }
}
