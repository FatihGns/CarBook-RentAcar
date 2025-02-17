using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationQueryById, List<GetLocationByIdQueryResult>>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationByIdQueryResult>> Handle(GetLocationQueryById request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            // Eğer değer null ise kontrol edin
            if (value == null)
            {
                return new List<GetLocationByIdQueryResult>();
            }

            return new List<GetLocationByIdQueryResult>
            {
                new GetLocationByIdQueryResult
                {
                    Name=value.Name,
                    LocationID = value.LocationID
                }
            };
        }
    }
}
