using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAddressResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, List<GetFooterAddressByIdQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressByIdQueryResult>> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            // Eğer değer null ise kontrol edin
            if (value == null)
            {
                return new List<GetFooterAddressByIdQueryResult>();
            }

            return new List<GetFooterAddressByIdQueryResult>
            {
                new GetFooterAddressByIdQueryResult
                {
                    Description = value.Description,
                    Address = value.Address,
                    Email = value.Email,
                    Phone = value.Phone,
                    FooterAddressID = value.FooterAddressID
                }
            };
        }
    }
}
