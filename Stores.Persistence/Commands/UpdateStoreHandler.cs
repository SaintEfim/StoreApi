using MediatR;
using Stores.Application.Commands;
using Stores.Application.Common.Exceptions;
using Stores.Application.Interfaces.Repository;

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
        await _storeRepository.UpdateStoreAsync(request.Store, cancellationToken);
        
        var entity = await _storeRepository.GetStoreAsync(request.Store.StoreId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(entity), request.Store.StoreId);
        }
        
        return Unit.Value;
    }
}