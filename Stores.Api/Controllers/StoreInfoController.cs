using Microsoft.AspNetCore.Mvc;
using Stores.Application.Interfaces;
using Stores.Api.Models.Address;
using Stores.Api.Models.Store;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Stores.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreInfoController : ControllerBase
    {
        private readonly IStoreInfoRepository _storeService;
        private readonly IMapper _mapper;

        public StoreInfoController(IStoreInfoRepository storeService, IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }

        [HttpGet("ByType/{storeType}")]
        //[Authorize]
        public ActionResult<List<StoreDto>> GetStoresByType(string storeType)
        {
            var stores = _storeService.GetStoresByType(storeType);
            return Ok(_mapper.Map<List<StoreDto>>(stores));
        }

        [HttpGet("ByStreet/{street}")]
        //[Authorize]
        public ActionResult<List<StoreDto>> GetStoresByStreet(string street)
        {
            var stores = _storeService.GetStoresByStreet(street);
            return Ok(_mapper.Map<List<StoreDto>>(stores));
        }

        [HttpGet("ByPhoneNumber/{phoneNumber}")]
        //[Authorize]
        public ActionResult<AddressDto> GetStoreAddressByPhoneNumber(string phoneNumber)
        {
            var address = _storeService.GetStoreAddressByPhoneNumber(phoneNumber);
            return Ok(_mapper.Map<AddressDto>(address));
        }

        [HttpGet("ByTypeAndHours/{storeTypeId}/{day}/{time}")]
        //[Authorize]
        public ActionResult<StoreDto> GetStoreByWorkingHours(int storeTypeId, DayOfWeek day, TimeSpan time)
        {
            var store = _storeService.GetStoreByWorkingHours(storeTypeId, day, time);
            return Ok(_mapper.Map<StoreDto>(store));
        }

        [HttpGet("AdminsByType/{storeType}")]
        //[Authorize]
        public ActionResult<List<string>> GetAdministratorsLastNameByStoreType(string storeType)
        {
            var administrators = _storeService.GetAdministratorsLastNameByStoreType(storeType);
            return Ok(administrators);
        }

        [HttpGet("CountByType/{storeType}")]
        //[Authorize]
        public ActionResult<int> GetStoreTypeCount(string storeType)
        {
            var count = _storeService.GetStoreTypeCount(storeType);
            return Ok(count);
        }
    }
}
