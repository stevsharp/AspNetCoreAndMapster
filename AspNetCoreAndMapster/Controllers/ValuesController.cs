using AspNetCoreAndMapster.Models;

using Mapster;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAndMapster.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // GET: api/items
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems()
    {

        var items = await _context.Items
            .ProjectToType<ItemDto>()
            .ToListAsync();

        return Ok(items);
    }

    // POST: api/items
    [HttpPost]
    public async Task<ActionResult<ItemDto>> CreateItem(ItemDto itemDto)
    {
        var item = itemDto.Adapt<Item>();

        _context.Items.Add(item);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetItems), new { id = item.Id }, item.Adapt<ItemDto>());
    }
}