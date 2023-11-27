using Stores.Application.BaseCommands;
using Stores.Domain.Entity;

namespace Stores.Application.Commands;

public class AddStoreCommand : BaseStoreCommand
{
    public AddStoreCommand(Store store) : base(store)
    {
    }
}