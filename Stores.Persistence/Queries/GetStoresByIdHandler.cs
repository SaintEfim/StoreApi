using AutoMapper;
using MediatR;
using Stores.Application.Interfaces;
using Stores.Application.Queries;
using Stores.Application.Queries;
using Stores.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stores.Persistence.Queries
{
    public class GetStoreByIdHandler : IRequestHandler<GetStoreByIdQuery, Store>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public GetStoreByIdHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<Store> Handle(GetStoreByIdQuery query, CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.GetStoreAsync(query.Id);

            return stores;
        }
    }
}
