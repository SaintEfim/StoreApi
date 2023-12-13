using Microsoft.AspNetCore.Mvc;
using Stores.Application.Interfaces;
using Stores.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Stores.Api.Models.Store;
using Microsoft.AspNetCore.Authorization;

namespace Stores.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreController(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [ProducesResponseType(typeof(List<StoreDto>), 200)]
        public async Task<ActionResult<List<CreateStoreDto>>> GetStores()
        {
            var stores = await _storeRepository.GetStoresAsync();
            var storesDtos = stores.Select(x => _mapper.Map<StoreDto>(x)).ToList();
            return Ok(storesDtos);
        }


        [HttpGet("{id}")]
        //[Authorize]
        [ProducesResponseType(typeof(StoreDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<StoreDto>> GetStore(int id)
        {
            var store = await _storeRepository.GetStoreAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            var storeDto = _mapper.Map<StoreDto>(store);
            return Ok(storeDto);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(CreateResultStoreDto), 201)]
        public async Task<ActionResult> CreateStore(CreateStoreDto storeDto)
        {
            var store = _mapper.Map<Store>(storeDto);
            await _storeRepository.InsertStoreAsync(store);
            var result = _mapper.Map<CreateResultStoreDto>(store);
            return CreatedAtAction(nameof(GetStore), new { id = store.StoreId }, result);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateStore(int id, StoreDto storeDto)
        {
            var store = _mapper.Map<Store>(storeDto);
            if (id != store.StoreId)
            {
                return BadRequest();
            }
            await _storeRepository.UpdateStoreAsync(store);
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> DeleteStore(int id)
        {
            await _storeRepository.DeleteStoreAsync(id);
            return NoContent();
        }
    }
}
