using Microsoft.AspNetCore.Mvc;
using Stores.Application.Interfaces;
using Stores.Domain.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Stores.Api.Models.Store;
using Stores.Application.Commands;
using Stores.Application.Queries;

namespace Stores.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public StoreController(IStoreRepository storeRepository, IMapper mapper, IMediator mediator)
    {
        _storeRepository = storeRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    // [Authorize]
    [ProducesResponseType(typeof(List<StoreDto>), 200)]
    public async Task<ActionResult<List<StoreDto>>> GetStores()
    {
        var stores = await _mediator.Send(new GetStoresQuery());
        return Ok(stores.Select(x => _mapper.Map<StoreDto>(x)).ToList());
    }

    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(typeof(StoreDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<StoreDto>> GetStore(int id)
    {
        var store = await _mediator.Send(new GetStoreByIdQuery(id));
        if (store == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<StoreDto>(store));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(201)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<int>> CreateStore(CreateStoreDto storeDto)
    {
        var store = _mapper.Map<Store>(storeDto);
        await _mediator.Send(new AddStoreCommand(store));
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

        await _mediator.Send(new UpdateStoreCommand(store));
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> DeleteStore(int id)
    {
        await _mediator.Send(new DeleteStoreCommand(id));
        return NoContent();
    }
}