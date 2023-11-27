using MediatR;
using Stores.Domain.Entity;

namespace Stores.Application.Commands;

public class AddStoreCommand : IRequest<Unit>
{
    public AddStoreCommand(Store store)
    {
        Store = store;
    }

    public Store Store { get; set; }
}