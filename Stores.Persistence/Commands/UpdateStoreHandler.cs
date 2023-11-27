using MediatR;
using Stores.Application.Commands;
using Stores.Application.Interfaces;

namespace Stores.Persistence.Commands;

public class UpdateStoreHandler : IRequestHandler<UpdateStoreCommand, Unit>
{
    private readonly IStoreRepository _storeRepository;

    public UpdateStoreHandler(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task<Unit> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        await _storeRepository.UpdateStoreAsync(request.Store);
        return Unit.Value;
    }
}