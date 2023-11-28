using AutoMapper;
using Stores.Api.Models.Address;
using Stores.Api.Models.Administrator;
using Stores.Api.Models.Store;
using Stores.Api.Models.StoreType;
using Stores.Api.Models.WorkingHours;
using Stores.Domain.Entity;

namespace Stores.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Address, AddressDto>();
        CreateMap<AddressDto, Address>();

        CreateMap<Administrator, AdministratorDto>();
        CreateMap<AdministratorDto, Administrator>();

        CreateMap<Store, StoreDto>();
        CreateMap<StoreDto, Store>();

        CreateMap<Store, CreateStoreDto>();
        CreateMap<CreateStoreDto, Store>();

        CreateMap<StoreType, StoreTypeDto>();
        CreateMap<StoreTypeDto, StoreType>();

        CreateMap<WorkingHours, WorkingHoursDto>();
        CreateMap<WorkingHoursDto, WorkingHours>();
    }
}