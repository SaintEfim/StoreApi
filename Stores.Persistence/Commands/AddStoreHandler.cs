using MediatR;
using Stores.Application.Commands;
using Stores.Application.Common.Exceptions;
using Stores.Application.Interfaces;

namespace Stores.Persistence.Commands;

public class AddStoreHandler : IRequestHandler<AddStoreCommand, Unit>
{
    private readonly IStoreRepository _storeRepository;

    public AddStoreHandler(IStoreRepository storeRepository) 
    {
        _storeRepository = storeRepository;
    }

    public async Task<Unit> Handle(AddStoreCommand request, CancellationToken cancellationToken)
    {
        var entity = await _storeRepository.GetStoreAsync(request.Store.StoreId, cancellationToken);
        
        if (entity == null)
        {
            throw new NotFoundException(nameof(entity), request.Store.StoreId);
        }
        
        await _storeRepository.InsertStoreAsync(request.Store, cancellationToken);
        return Unit.Value;
    }
}