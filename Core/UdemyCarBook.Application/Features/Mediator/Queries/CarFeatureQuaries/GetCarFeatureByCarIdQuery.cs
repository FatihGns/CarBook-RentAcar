using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.CarFeatureResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQuaries
{
    public class GetCarFeatureByCarIdQuery:IRequest<List<GetCarFeatureByCarIdQueryResult>>
    {
        public GetCarFeatureByCarIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
