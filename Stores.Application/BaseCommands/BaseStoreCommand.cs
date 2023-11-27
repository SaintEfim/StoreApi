using MediatR;
using Stores.Domain.Entity;

namespace Stores.Application.BaseCommands;

public abstract class BaseStoreCommand : IRequest<Unit>
{
    protected BaseStoreCommand(Store store)
    {
        Store = store;
    }

    public Store Store { get; }
}