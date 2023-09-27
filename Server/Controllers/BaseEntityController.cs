using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroBlazorWebApp.Server.Models.Context;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroBlazorWebApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseEntityController<TEntity, TContext> : ControllerBase
        where TEntity : class, new()
        where TContext : DbContext
    {
        protected readonly TContext _context;

        public BaseEntityController(TContext context)
        {
            _context = context;
        }

        [HttpGet]
        public virtual IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        [HttpGet("{id}")]
        public virtual async Task<TEntity?> Get(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Create([FromBody] TEntity entity)
        {
            if (entity is null)
            {
                return BadRequest();
            }

            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return Ok(entity);
        }

        [HttpPost("{id}")]
        public virtual async Task<ActionResult<TEntity>> Update([FromRoute] int id, [FromBody] TEntity entity)
        {
            var dbEntity = await _context.Set<TEntity>().FindAsync(id);
            if (dbEntity == null)
            {
                return NotFound();
            }

            _context.Entry(dbEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();

            return Ok(dbEntity);
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete([FromRoute] int id)
        {
            var dbEntity = await _context.Set<TEntity>().FindAsync(id);
            if (dbEntity == null)
            {
                return NotFound();
            }

            _context.Set<TEntity>().Remove(dbEntity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
