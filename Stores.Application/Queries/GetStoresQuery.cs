using MediatR;
using Stores.Domain.Entity;

namespace Stores.Application.Queries;

public class GetStoresQuery : IRequest<ICollection<Store>>
{
}