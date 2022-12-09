using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context= context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        { 
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id )
        {
            var user = await _context.Users.FindAsync(id);
            return Ok(user);
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromBody]AppUser appUser)
        { 
             await _context.AddAsync(appUser);
            _context.SaveChanges();
            return Ok(appUser);
        }
    }
}
