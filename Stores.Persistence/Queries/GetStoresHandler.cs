using AutoMapper;
using MediatR;
using Stores.Application.Interfaces;
using Stores.Application.Queries;
using Stores.Domain.Entity;

namespace Stores.Persistence.Queries
{
    public class GetStoresHandler : IRequestHandler<GetStoresQuery, ICollection<Store>>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public GetStoresHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<Store>> Handle(GetStoresQuery query, CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.GetStoresAsync();

            return stores;
        }
    }
}
