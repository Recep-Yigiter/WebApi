using Microsoft.AspNetCore.Mvc;
using WebApiRecep.Entities;

namespace WebApiRecep.Controllers
{
    public interface IGenericController<TEntity> where TEntity : class, IEntity
    {
        Task<ActionResult<TEntity>> Delete(int id);
        Task<ActionResult<IEnumerable<TEntity>>> Get();
        Task<ActionResult<TEntity>> Get(int id);
        Task<ActionResult<TEntity>> Post(TEntity entity);
        Task<IActionResult> Put(int id, TEntity entity);
    }
}
