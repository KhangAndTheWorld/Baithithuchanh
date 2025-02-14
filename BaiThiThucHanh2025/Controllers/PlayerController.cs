using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaiThiThucHanh2025.Data;
using BaiThiThucHanh2025.Models;

namespace BaiThiThucHanh2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly TestContext _context;
        
        public PlayerController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<OkObjectResult> GetPlayer(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            [FromQuery] string? orderColumn = null,
            [FromQuery] string? orderDir = null)
        {
            var list = await _context.Players.ToListAsync();
            var query = list.AsQueryable(); // móc từ db.
            if (!string.IsNullOrEmpty(search))
            {
                // search theo keyword
                query = query.Where(x => x.PlayerName.Contains(search, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(orderColumn) && !string.IsNullOrEmpty(orderDir))
            {
                
            }
            var totalCount = query.Count();
            var pagedProducts = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var result = new
            {
                data = pagedProducts,
                recordsTotal = list.Count,
                recordsFiltered = totalCount,
                page = page,
                pageSize = pageSize
            };
            return Ok(result);
        }

        // GET: api/Player/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(long id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // PUT: api/Player/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(long id, Player player)
        {
            if (id != player.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Player
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayers(Player @player)
        {
            _context.Players.Add(@player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayers", new { id = @player.PlayerId }, @player);
        }

        // DELETE: api/Player/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(long id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(long id)
        {
            return _context.Players.Any(e => e.PlayerId == id);
        }
    }
}
