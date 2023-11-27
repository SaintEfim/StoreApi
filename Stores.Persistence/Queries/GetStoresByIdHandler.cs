using MediatR;
using Stores.Application.Interfaces;
using Stores.Application.Queries;
using Stores.Domain.Entity;

namespace Stores.Persistence.Queries;

public class GetStoreByIdHandler : IRequestHandler<GetStoreByIdQuery, Store>
{
    private readonly IStoreRepository _storeRepository;

    public GetStoreByIdHandler(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task<Store> Handle(GetStoreByIdQuery query, CancellationToken cancellationToken)
    {
        var stores = await _storeRepository.GetStoreAsync(query.Id);

        return stores;
    }
}