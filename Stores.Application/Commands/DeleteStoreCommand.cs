using MediatR;
using Stores.Domain.Entity;

namespace Stores.Application.Commands;

public class DeleteStoreCommand : IRequest<Unit>
{
    public DeleteStoreCommand(int id)
    {
        Id = id;
    }
    
    public int Id { get; }
}