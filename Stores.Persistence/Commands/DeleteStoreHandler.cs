using MediatR;
using Stores.Application.Commands;
using Stores.Application.Common.Exceptions;
using Stores.Application.Interfaces;
using Stores.Application.Interfaces.Repository;

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
        var entity = await _storeRepository.GetStoreAsync(request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(entity), request.Id);
        }
        
        await _storeRepository.DeleteStoreAsync(request.Id, cancellationToken);

        return Unit.Value;
    }
}