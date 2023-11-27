using Stores.Application.BaseCommands;
using Stores.Domain.Entity;

namespace Stores.Application.Commands;

public class UpdateStoreCommand : BaseStoreCommand
{
    public UpdateStoreCommand(Store store) : base(store)
    {
    }
}