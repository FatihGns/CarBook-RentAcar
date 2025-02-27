﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Enums;
using UdemyCarBook.Application.Features.Mediator.Commads.AppUserCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;
       public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreatedAsync(new AppUser
            {
                Password = request.Password,
                UserName = request.Username,
                AppRoleId=(int)RolesType.Member,
                Email=request.Email,
                Name=request.Name,
                SurName=request.Surname

                
            });
        }
    }
}
