﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commads.LocationCommands
{
    public class RemoveLocationCommand:IRequest
    {
        public RemoveLocationCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
