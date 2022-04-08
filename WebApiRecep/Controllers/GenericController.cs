using Microsoft.AspNetCore.Mvc;
using WebApiRecep.Entities;
using WebApiRecep.GenericRepositories;

namespace WebApiRecep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TEntity, TRepository> : ControllerBase, IGenericController<TEntity>
          where TEntity : class, IEntity
          where TRepository : IGenericRepository<TEntity>

    {
        private readonly TRepository repository;


        public GenericController(TRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/[controller]
        [HttpGet("Generic_Method")]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {

            return await repository.GetAll();

        }

        // GET: api/[controller]/5
        [HttpGet("Generic_Method {id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var entity = await repository.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        // PUT: api/[controller]/5
        [HttpPut("Generic_Method {id}")]
        public async Task<IActionResult> Put(int id, TEntity entity)
        {

            if (id != entity.Id)
            {
                return BadRequest();
            }
            await repository.Update(entity);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost("Generic_Method")]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            await repository.Add(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: api/[controller]
        [HttpDelete("Generic_Method {id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var entity = await repository.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }
    }
}
