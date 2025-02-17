﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commads.ReservationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreatedAsync(new Reservation
            {
                Age = request.Age,
                CarID = request.CarID,
                Description = request.Description,
                DriverLicenseYear = request.DriverLicenseYear,
                 DropOffLocationID=request.DropOffLOcationID,
                EMail = request.EMail,
                Name = request.Name,
                Phone = request.Phone,
                PickUpLOcationID = request.PickUpLOcationID,
                ReservationID = request.ReservationID,
                SurName = request.SurName,
                Status="Rezervasyon Alındı"
                
            });
        }
    }
}
