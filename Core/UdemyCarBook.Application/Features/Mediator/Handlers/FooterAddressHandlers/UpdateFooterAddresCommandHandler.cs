﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commads.FooterAddressCommand;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddresCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddresCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.FooterAddressID);
            values.Phone=request.Phone;
            values.Address=request.Address;
            values.Description=request.Description;
            values.Email=request.Email;  
            await _repository.UpdatedAsync(values);
        }
    }
}
