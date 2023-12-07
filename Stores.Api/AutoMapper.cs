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
        CreateMap<AddressDto, Address>().ReverseMap();

        CreateMap<AdministratorDto, Administrator>().ReverseMap();

        CreateMap<Store, StoreDto>();

        CreateMap<CreateStoreDto, Store>().ReverseMap();

        CreateMap<StoreTypeDto, StoreType>().ReverseMap();

        CreateMap<WorkingHoursDto, WorkingHours>().ReverseMap();
    }
}