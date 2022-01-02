using api.Models;
using api.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Services;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class LoginController : ControllerBase
    {

        private readonly DBcontext _context;
        private TokenService ts;
        public LoginController(DBcontext context, ICon){
            _context = context;
            ts = new TokenService();
        }
        
        [HttpPost]
        public async IActionResult login([FromBody] LoginDTO loginRequest){
            Player? p = await _context.Players.FindAsync(loginRequest.Name);
            if (p != null){
                return ts.BuildToken()
            }
            else{
                return NotFound();
            }
        }

    }
}