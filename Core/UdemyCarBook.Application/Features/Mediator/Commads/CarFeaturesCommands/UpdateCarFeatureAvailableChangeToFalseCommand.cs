using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commads.CarFeaturesCommands
{
    public class UpdateCarFeatureAvailableChangeToFalseCommand:IRequest
    {
        public UpdateCarFeatureAvailableChangeToFalseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
