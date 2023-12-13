using Microsoft.AspNetCore.Mvc;
using Stores.Domain.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Stores.Api.Models.Store;
using Stores.Application.Commands;
using Stores.Application.Interfaces.Service;
using Stores.Application.Queries;

namespace Stores.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ICacheService _cacheService;

    public StoreController(IMapper mapper, IMediator mediator, ICacheService cacheService)
    {
        _mapper = mapper;
        _mediator = mediator;
        _cacheService = cacheService;
    }

    [HttpGet]
    // [Authorize]
    [ProducesResponseType(typeof(List<StoreDto>), 200)]
    public async Task<ActionResult<List<StoreDto>>> GetStores()
    {
        var cacheData = _cacheService.GetData<ICollection<Store>>(nameof(Store));

        if (cacheData != null && cacheData.Any())
            return Ok(_mapper.Map<List<StoreDto>>(cacheData));

        cacheData = await _mediator.Send(new GetStoresQuery());

        var expiryTime = DateTimeOffset.Now.AddSeconds(30);
        _cacheService.SetData(nameof(Store), cacheData, expiryTime);

        return Ok(_mapper.Map<List<StoreDto>>(cacheData));
    }

    [HttpGet("{id}")]
// [Authorize]
    [ProducesResponseType(typeof(StoreDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<StoreDto>> GetStore(int id)
    {
        var cachedStore = _cacheService.GetData<Store>($"store{id}");

        if (cachedStore != null)
            return Ok(_mapper.Map<StoreDto>(cachedStore));

        var store = await _mediator.Send(new GetStoreByIdQuery(id));

        var expiryTime = DateTimeOffset.Now.AddSeconds(30);
        _cacheService.SetData($"store{id}", store, expiryTime);
        return Ok(_mapper.Map<StoreDto>(store));
    }


    [HttpPost]
    // [Authorize(Roles = "Admin")]
    [ProducesResponseType(201)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<int>> CreateStore(CreateStoreDto storeDto)
    {
        var store = _mapper.Map<Store>(storeDto);
        await _mediator.Send(new AddStoreCommand(store));

        var expiryTime = DateTimeOffset.Now.AddSeconds(30);
        _cacheService.SetData<Store>($"stores{store.StoreId}", store, expiryTime);

        return Ok(new { Id = store.StoreId });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> UpdateStore(int id, StoreDto storeDto)
    {
        var store = _mapper.Map<Store>(storeDto);
        if (id != store.StoreId)
        {
            return BadRequest();
        }

        var expiryTime = DateTimeOffset.Now.AddSeconds(30);
        _cacheService.SetData<Store>($"stores{store.StoreId}", store, expiryTime);

        await _mediator.Send(new UpdateStoreCommand(store));
        return NoContent();
    }

    [HttpDelete("{id}")]
    // [Authorize(Roles = "Admin")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> DeleteStore(int id)
    {
        await _mediator.Send(new DeleteStoreCommand(id));
        _cacheService.RemoveData($"store{id}");
        return NoContent();
    }
}