using Library.API.Project.Data;
using Library.API.Project.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LibraryAPIContext _context;

        public UserController(LibraryAPIContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserEntity>>> GetUserEntity()
        {
            if (_context.UserEntity == null)
            {
                return NotFound();
            }
            return await _context.UserEntity.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntity>> GetUserEntity(int id)
        {
            if (_context.UserEntity == null)
            {
                return NotFound();
            }
            var userEntity = await _context.UserEntity.FindAsync(id);

            if (userEntity == null)
            {
                return NotFound();
            }

            return userEntity;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserEntity(int id, UserEntity userEntity)
        {
            if (id != userEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(userEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEntityExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserEntity>> PostUserEntity(UserEntity userEntity)
        {
            if (_context.UserEntity == null)
            {
                return Problem("Entity set 'LibraryAPIContext.UserEntity'  is null.");
            }
            _context.UserEntity.Add(userEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserEntity", new { id = userEntity.Id }, userEntity);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserEntity(int id)
        {
            if (_context.UserEntity == null)
            {
                return NotFound();
            }
            var userEntity = await _context.UserEntity.FindAsync(id);
            if (userEntity == null)
            {
                return NotFound();
            }

            _context.UserEntity.Remove(userEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserEntityExists(int id)
        {
            return (_context.UserEntity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
