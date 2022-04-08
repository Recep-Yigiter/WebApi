using Microsoft.AspNetCore.Mvc;
using WebApiRecep.Entities.MaliyetEntity;
using WebApiRecep.GenericRepositories.Repositories;

namespace WebApiRecep.Controllers.MaliyetController
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlisTipisController : GenericController<AlisTipi, EfCoreAlisTipiRepository>
    {
        private readonly EfCoreAlisTipiRepository _repository;
        public AlisTipisController(EfCoreAlisTipiRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
