using WebApiRecep.Data;
using WebApiRecep.Entities.MaliyetEntity;

namespace WebApiRecep.GenericRepositories.Repositories
{
    public class EfCoreAlisTipiRepository : GenericRepository<AlisTipi, MaliyetDbContext>
    {
        public EfCoreAlisTipiRepository(MaliyetDbContext context) : base(context)
        {
        }


    }
}
