using AspNetCoreAndMapster.Models;
using AspNetCoreAndMapster.Repository;
using AspNetCoreAndMapster.Specification;
using Mapster;

using Microsoft.AspNetCore.Mvc;


namespace AspNetCoreAndMapster.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly IRepository<Item> _repository;

    public ItemsController(IRepository<Item> repository) => _repository = repository;


    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetItemsAll(CancellationToken token)
    {
        var items = await _repository.ListAsync(new NullSpecification<Item>(),token);

        var itemDtos = items.Adapt<List<ItemDto>>();

        return Ok(items);

    }

    [HttpGet("GetByCriteria")]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems([FromQuery] ItemFilter filter, CancellationToken token)
    {
        ISpecification<Item> specification;

        if (!string.IsNullOrEmpty(filter.Name))
        {
            specification = new ItemsByNameSpecification(filter.Name);
        }
        else if (filter.MinPrice.HasValue && filter.MaxPrice.HasValue)
        {
            specification = new ItemsByPriceRangeSpecification(filter.MinPrice.Value, filter.MaxPrice.Value);
        }
        else
        {
            specification = new NullSpecification<Item>();
        }

        var items = await _repository.ListAsync(specification,token);

        var itemDtos = items.Adapt<List<ItemDto>>();

        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ItemDto>> GetItem(int id, CancellationToken token)
    {
        var item = await _repository.GetByIdAsync(id,token);
        if (item == null)
        {
            return NotFound();
        }

        var itemDto = item.Adapt<ItemDto>();
        return Ok(itemDto);
    }

    [HttpPost]
    public async Task<ActionResult<ItemDto>> CreateItem(ItemDto itemDto, CancellationToken token)
    {
        var item = itemDto.Adapt<Item>();

        await _repository.AddAsync(item, token);


        var createdItemDto = item.Adapt<ItemDto>();

        return CreatedAtAction(nameof(GetItem), new { id = createdItemDto.Id }, createdItemDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, ItemDto itemDto, CancellationToken token)
    {
        if (id != itemDto.Id)
        {
            return BadRequest();
        }

        var item = await _repository.GetByIdAsync(id, token);
        if (item == null)
        {
            return NotFound();
        }

        itemDto.Adapt(item);

        await _repository.UpdateAsync(item,token);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id, CancellationToken token)
    {
        var item = await _repository.GetByIdAsync(id,token);
        if (item == null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(item, token);

        return NoContent();
    }
}