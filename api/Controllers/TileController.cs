using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Models.Dtos;
namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TileController : ControllerBase
    {
        private readonly DBcontext _context;

        public TileController(DBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getTiles()
        {
            Tile[] tiles = _context.Tiles.ToArray();
            return Ok(tiles);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Tile>> getTile([FromRoute] int id)
        {
            try
            {
                Tile? tile = await _context.Tiles.FindAsync(id);
                if (tile == null) return NotFound();
                return Ok(tile);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("attack/{id:int}")]
        public async Task<ActionResult<Tile>> attackTile([FromRoute] int id, [FromBody] PlayerDTO attacker)
        {
            try
            {
                Player? attackPlayer = await _context.Players.FindAsync(attacker.Name);
                Tile? tile = await _context.Tiles.FindAsync(id);
                if (tile == null) return NotFound("Did not found the tile");
                if (attackPlayer == null) return NotFound("Did not found the player");
                TimeSpan attackInterval = DateTime.Now - attackPlayer.prevAttack;

                if (attackInterval.TotalHours >= 3)
                {
                    tile.owner = attackPlayer;
                    tile.color = attackPlayer.Color;
                    attackPlayer.prevAttack = DateTime.UtcNow;
                }
                else
                {
                    return BadRequest();
                }


                await _context.SaveChangesAsync();
                return Ok(tile);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}