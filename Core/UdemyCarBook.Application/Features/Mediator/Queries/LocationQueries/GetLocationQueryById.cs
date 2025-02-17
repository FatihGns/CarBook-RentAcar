using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAddressResults;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationQueryById:IRequest<List<GetLocationByIdQueryResult>>
    {
        public GetLocationQueryById(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
