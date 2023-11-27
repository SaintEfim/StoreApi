using MediatR;
using Stores.Domain.Entity;

namespace Stores.Application.Queries;

public class GetStoreByIdQuery : IRequest<Store>
{
    public GetStoreByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}