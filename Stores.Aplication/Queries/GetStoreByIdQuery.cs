using MediatR;
using Stores.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stores.Application.Queries
{
    public class GetStoreByIdQuery : IRequest<Store>
    {
        public GetStoreByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
