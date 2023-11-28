using MediatR;
using Stores.Application.Interfaces;
using Stores.Application.Interfaces.Repository;
using Stores.Application.Queries;
using Stores.Domain.Entity;

namespace Stores.Persistence.Queries;

public class GetStoresHandler : IRequestHandler<GetStoresQuery, ICollection<Store>>
{
    private readonly IStoreRepository _storeRepository;

    public GetStoresHandler(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task<ICollection<Store>> Handle(GetStoresQuery query, CancellationToken cancellationToken)
    {
        var stores = await _storeRepository.GetStoresAsync();

        return stores;
    }
}