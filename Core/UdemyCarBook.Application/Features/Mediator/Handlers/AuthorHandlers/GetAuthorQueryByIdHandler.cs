using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AuthorResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

public class GetAuthorQueryByIdHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
{
    private readonly IRepository<Author> _repository;

    public GetAuthorQueryByIdHandler(IRepository<Author> repository)
    {
        _repository = repository;
    }

    public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        // Veritabanından Author nesnesini al
        var author = await _repository.GetByIdAsync(request.Id);

        // Null kontrolü
        if (author == null)
        {
            throw new Exception($"Author with ID {request.Id} not found.");
        }

        // Author özelliklerini döndür
        return new GetAuthorByIdQueryResult
        {
            AuthorID = author.AuthorID,
            Name = author.Name,
            Description = author.Description, // Diğer alanları da ekleyin
            ImageUrl= author.ImageUrl
        };
    }
}
