using MediatR;
using Stores.Application.Commands;
using Stores.Application.Interfaces.Repository;

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
        await _storeRepository.InsertStore(request.Store, cancellationToken);
        return Unit.Value;
    }
}