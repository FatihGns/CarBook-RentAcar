using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commads.ServiceCommands
{
    public class RemoveServiceCommand:IRequest
    {
        public RemoveServiceCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
