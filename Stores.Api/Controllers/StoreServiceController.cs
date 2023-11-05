using Microsoft.AspNetCore.Mvc;
using Stores.Domain.Interfaces;
using Stores.Api.Models.Address;
using Stores.Api.Models.Store;
using AutoMapper;

namespace Stores.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreServiceController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public StoreServiceController(IStoreService storeService, IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }

        [HttpGet("stores/type/{storeType}")]
        public ActionResult<List<StoreDto>> GetStoresByType(string storeType)
        {
            var stores = _storeService.GetStoresByType(storeType);
            return Ok(_mapper.Map<List<StoreDto>>(stores));
        }

        [HttpGet("stores/street/{street}")]
        public ActionResult<List<StoreDto>> GetStoresByStreet(string street)
        {
            var stores = _storeService.GetStoresByStreet(street);
            return Ok(_mapper.Map<List<StoreDto>>(stores));
        }

        [HttpGet("address/phone/{phoneNumber}")]
        public ActionResult<AddressDto> GetStoreAddressByPhoneNumber(string phoneNumber)
        {
            var address = _storeService.GetStoreAddressByPhoneNumber(phoneNumber);
            return Ok(_mapper.Map<AddressDto>(address));
        }

        [HttpGet("stores/workinghours/{storeTypeId}/{day}/{time}")]
        public ActionResult<StoreDto> GetStoreByWorkingHours(int storeTypeId, DayOfWeek day, TimeSpan time)
        {
            var store = _storeService.GetStoreByWorkingHours(storeTypeId, day, time);
            return Ok(_mapper.Map<StoreDto>(store));
        }

        [HttpGet("administrators/{storeType}")]
        public ActionResult<List<string>> GetAdministratorsLastNameByStoreType(string storeType)
        {
            var administrators = _storeService.GetAdministratorsLastNameByStoreType(storeType);
            return Ok(administrators);
        }

        [HttpGet("stores/count/{storeType}")]
        public ActionResult<int> GetStoreTypeCount(string storeType)
        {
            var count = _storeService.GetStoreTypeCount(storeType);
            return Ok(count);
        }
    }
}
