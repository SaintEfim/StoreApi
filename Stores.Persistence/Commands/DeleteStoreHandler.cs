using MediatR;
using Stores.Application.Commands;
using Stores.Application.Interfaces;

namespace Stores.Persistence.Commands;

public class DeleteStoreHandler : IRequestHandler<DeleteStoreCommand, Unit>
{
    private readonly IStoreRepository _storeRepository;

    public DeleteStoreHandler(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task<Unit> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
    {
        await _storeRepository.DeleteStoreAsync(request.Id);
        return Unit.Value;
    }
}