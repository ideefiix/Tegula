using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Models.Dtos;
namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly DBcontext _context;

        public PlayerController(DBcontext context){
            _context = context;
        }

        [HttpGet]
        public IActionResult getPlayers()
        {
            Player[] players = _context.Players.ToArray();
            return Ok(players);
        }
        [HttpGet("{name}")]
        public IActionResult getPlayer([FromRoute] string name)
        {
            try {
            Player p = _context.Players.First(x => x.Name == name);
            return Ok(p);
            }
            catch (Exception){
            return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Player>> createPlayer([FromBody] PlayerDTO dto){
            Player p = new Player()
            {
                Name = dto.Name
            };

                _context.Players.Add(p);
                await _context.SaveChangesAsync();
                return Ok(p);
        }

        [HttpDelete("delete/{name}")]
        public async Task<ActionResult<Player>> deletePlayer([FromRoute] string name){
            try
            {
                Player p = _context.Players.First(x => x.Name == name);
                if (p == null) return NotFound();
                _context.Players.Remove(p);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e){
                return BadRequest(e);
            }
        }
    }
}